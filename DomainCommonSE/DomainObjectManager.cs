using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using DomainCommonSE.Domain;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.DbCommon;
using System.Linq;

namespace DomainCommonSE
{
	internal class DomainObjectManager
	{
		private readonly DomainObjectInquiry m_inquiry;
		private readonly IDbCommonConnection m_connection;

		public static DomainObjectManager Instance { get; private set; }
		public SharedObjectRepository SharedRepository { get; private set; }
		public DomainObjectFactory ObjectFactory { get; private set; }

		Dictionary<string, DomainObjectBroker> m_domainObjectBroker = new Dictionary<string, DomainObjectBroker>();
		Dictionary<DomainLinkKey, DomainLinkBroker> m_domainLinkBroker = new Dictionary<DomainLinkKey, DomainLinkBroker>();

		public DomainObjectManager(DomainObjectInquiry m_objectInquiry, IDbCommonConnection connection, DomainObjectFactory objectFactory)
		{
			if (m_objectInquiry == null)
				throw new ArgumentNullException("m_objectInquiry");
			m_inquiry = m_objectInquiry;

			if (connection == null)
				throw new ArgumentNullException("connection");
			m_connection = connection;

			if (objectFactory == null)
				throw new ArgumentNullException("objectFactory");
			ObjectFactory = objectFactory;

			SharedRepository = new SharedObjectRepository(m_inquiry, objectFactory);

			Instance = this;
		}

		public DomainObjectBroker GetObjectBroker(string objCode)
		{
			DomainObjectBroker result = null;
			if (m_domainObjectBroker.TryGetValue(objCode, out result))
				return result;

			var query = from link in m_inquiry.ALinks
						where (link.LeftObject.Code == objCode && link.IsLeftToRightActive) || (link.RightObject.Code == objCode && link.IsRightToLeftActive)
						select link;

			DomainObjectBrokerBuilder brokerBuilder = new DomainObjectBrokerBuilder(m_inquiry.AObject[objCode], query.ToArray(), m_connection);
			result = new DomainObjectBroker(brokerBuilder);
			m_domainObjectBroker.Add(objCode, result);

			return result;
		}

		public DomainLinkBroker GetLinkBroker(DomainLinkKey linkKey)
		{
			DomainLinkBroker result = null;
			if (m_domainLinkBroker.TryGetValue(linkKey, out result))
				return result;

			var query = from link in m_inquiry.ALinks
						where link.Key.Equals(linkKey)
						select link;

			DomainLinkBrokerBuilder brokerBuilder = new DomainLinkBrokerBuilder(query.First(), m_connection);
			result = new DomainLinkBroker(brokerBuilder);
			m_domainLinkBroker.Add(linkKey, result);

			return result;
		}

		public DomainPropertyCollection GetEmptyProperties(SessionIdentifier sessionId, ObjectIdentifier parentId)
		{
			DomainObjectConfig obj = m_inquiry.AObject[parentId.Code];
			DomainPropertyCollection result = new DomainPropertyCollection();

			foreach (DomainPropertyConfig prop in obj.Property)
			{
				DomainProperty newProperty = new DomainProperty(sessionId, parentId, prop.Code, prop.DefaultValue);
				result.Add(newProperty);
			}

			return result;
		}

		private DomainPropertyCollection LoadProperties(SessionIdentifier sessionId, ObjectIdentifier objectId)
		{
			string objCode = objectId.Code;

			DomainObjectConfig objConfig = m_inquiry.AObject[objCode];
			DomainObjectBroker broker = GetObjectBroker(objCode);

			long[] idList = new long[] { objectId.Id };

			DbCommonCommand command = broker.LoadItemsCommand;
			command["ID"].Value = idList;

			DomainPropertyCollection result = null;
			using (IDbCommonDataReader reader = command.ExecuteReader(sessionId))
			{
				if (!reader.Read())
				{
					reader.Close();
					throw new DomainException(String.Format("Объект {0} не найден в БД", objectId));
				}

				result = new DomainPropertyCollection();
				foreach (DomainPropertyConfig prop in objConfig.Property)
				{
					object value = reader.GetValue(reader.GetOrdinal(prop.Code), prop.DataType);
					DomainProperty newProperty = new DomainProperty(sessionId, objectId, prop.Code, value);
					result.Add(newProperty);
				}
				reader.Close();
			}

			return result;
		}

		private void LoadLinkedObjects(SessionIdentifier sessionId, ObjectIdentifier objectId)
		{
			string objCode = objectId.Code;

			DomainObjectBroker broker = GetObjectBroker(objCode);

			long[] idList = new long[] { objectId.Id };

			DbCommonCommand command = broker.LoadLinkedItemsCommand;
			command["ID"].Value = idList;

			using (IDbCommonDataReader reader = command.ExecuteReader(sessionId))
			{
				while (reader.Read())
				{
					long leftId = reader.GetValue<long>(0);
					long rightId = reader.GetValue<long>(1);
					string linkCode = reader.GetValue<string>(2);

					DomainLinkConfig linkConfig = broker.GetLinkConfig(linkCode);
					DomainLinkKey linkKey = new DomainLinkKey(linkConfig);
					//DomainLink link = SharedRepository.GetLink(linkKey);
					DomainLink link = DocumentManager.Instance.GetLink(sessionId, linkKey);

					link.Init(leftId, rightId);
				}

				reader.Close();
			}			
		}

		/// <summary>
		/// Load object from DB
		/// </summary>
		/// <param name="sessionId">Session identifier</param>
		/// <param name="objectId">Object identifier</param>
		/// <returns></returns>
		public DomainObject Materialize(SessionIdentifier sessionId, ObjectIdentifier objectId)
		{
			// load object properties from DB
			DomainPropertyCollection properties = LoadProperties(sessionId, objectId);
			// load linked objects identifiers
			LoadLinkedObjects(sessionId, objectId);
			// Create object by Factory
			DomainObject result = ObjectFactory.CreateDomainObject(sessionId, objectId);
			// Save properties to object and mark internal object state to Old
			result.Init(properties);
			// 
			SharedRepository.EngGetObject(result);

			return result;
		}

		//private EntityLinkCollection GetObjectLinks(SessionIdentifier sid, ObjectIdentifier oid)
		//{
		//    DomainObjectConfig obj = m_objectInquiry.AObject[oid.Code];
		//    EntityLinkCollection result = GetObjectEmptyLinks(sid, oid);

		//    string linkSql = obj.GetLinkSql(oid.Id);
		//    if (!String.IsNullOrEmpty(linkSql))
		//    {
		//        using (IDbCommonDataReader reader = m_objectInquiry.DbManager.CreateCommand(sid, linkSql).ExecuteReader())
		//        {
		//            while (reader.Read())
		//            {
		//                string linkCode = reader.GetValue<String>(2);
		//                string linkObjCode = reader.GetValue<String>(3);
		//                long linkObjId = reader.GetValue<Int64>(4);

		//                result[linkCode].Add(new ObjectIdentifier(linkObjCode, linkObjId));
		//            }
		//            reader.Close();
		//        }
		//    }

		//    return result;
		//}

		//private EntityObjectCollection<TObject> MaterializeCollection<TObject>(DomainObjectConfig objConfig, DbCommonCommand command, bool generateCollection)
		//    where TObject : EntityObject, new()
		//{
		//    string objCode = objConfig.Code;
		//    EntityObjectCollection<TObject> result = null;
		//    if (generateCollection)
		//    {
		//        result = new EntityObjectCollection<TObject>(Session, objCode);
		//    }

		//    List<ObjectIdentifier> allId = new List<ObjectIdentifier>();
		//    Dictionary<long, EntityPropertyCollection> objectProperty = new Dictionary<long, EntityPropertyCollection>();
		//    Dictionary<long, EntityLinkCollection> objectLink = new Dictionary<long, EntityLinkCollection>();
		//    Dictionary<string, int> fieldIndex = new Dictionary<string, int>();
		//    int idIndex = -1;

		//    // Выполнение запроса по получению запрашиваемых объектов
		//    using (IDbCommonDataReader reader = command.ExecuteReader())
		//    {
		//        // Получение порядковых номеров свойств в запросе
		//        idIndex = reader.GetOrdinal("ID");

		//        foreach (DomainPropertyConfig prop in objConfig.Property)
		//        {
		//            fieldIndex.Add(prop.Code, reader.GetOrdinal(prop.Code));
		//        }

		//        // Получение свойств запрашиваемых объектов
		//        while (reader.Read())
		//        {
		//            long id = reader.GetValue<Int64>(idIndex);
		//            ObjectIdentifier oid = new ObjectIdentifier(objCode, id);

		//            // Пропустить материализацию объектов в локальном хранилище
		//            if (objectStorage.ContainsKey(oid))
		//            {
		//                if (generateCollection)
		//                    result.Add(GetObject<TObject>(oid));

		//                continue;
		//            }

		//            // Если возможно загрузить объект из глобального хранилища				
		//            //RequestObjectArgs args = new RequestObjectArgs(oid);
		//            //RequestingObject(this, args);
		//            //EntityObject globalDocObj = args.Result;

		//            EntityObject globalDocObj = m_documentManager.BeginGetObject(oid, Session);

		//            if (globalDocObj != null)
		//            {						
		//                objectStorage.Add(oid, globalDocObj);

		//                if (generateCollection)
		//                    result.Add(globalDocObj);

		//                continue;
		//            }

		//            EntityPropertyCollection props = new EntityPropertyCollection();
		//            foreach (DomainPropertyConfig property in objConfig.Property)
		//            {
		//                object value = reader.GetValue(fieldIndex[property.Code], property.DataType);
		//                EntityProperty newProperty = new EntityProperty(Session, oid, property.Code, value);
		//                props.Add(newProperty);
		//            }

		//            allId.Add(oid);
		//            objectProperty.Add(id, props);
		//            objectLink.Add(id, GetObjectEmptyLinks(Session, oid));
		//        }
		//        reader.Close();
		//    }

		//    if (allId.Count == 0)
		//        return result;

		//    // Загрузка ID объектов по ссылкам
		//    string linkSql = objConfig.GetLinkSql(allId);
		//    if (!String.IsNullOrEmpty(linkSql))
		//    {
		//        using (IDbCommonDataReader linkReader = m_objectInquiry.DbManager.CreateCommand(Session, linkSql).ExecuteReader())
		//        {
		//            while (linkReader.Read())
		//            {
		//                long baseObjId = linkReader.GetValue<Int64>(1);
		//                string linkCode = linkReader.GetValue<String>(2);
		//                string linkObjCode = linkReader.GetValue<String>(3);
		//                long linkObjId = linkReader.GetValue<Int64>(4);

		//                if (linkObjId != -1)
		//                    objectLink[baseObjId][linkCode].Add(new ObjectIdentifier(linkObjCode, linkObjId));
		//            }
		//            linkReader.Close();
		//        }
		//    }

		public void CheckExist(SessionIdentifier sessionId, ObjectIdentifier objectId)
		{
			throw new NotImplementedException();
		}

		public ObjectIdentifier GetNewId(string objCode)
		{
			long newId = m_connection.NewSequence();
			return new ObjectIdentifier(objCode, newId);
		}

		public void SaveRepository(SessionIdentifier session, ObjectRepository objRepository)
		{
			SateToDB(session, objRepository);

			// Скопировать данные в глобальный репозиторий
			SharedRepository.SaveRepositoryChanges(objRepository);

			// DocumentManager.Instance.

			// Сбросить состояния объектов
			objRepository.ResetObjectState();
			// Сбросить состояния ссылок
			objRepository.ResetLinkState();

			//m_documentManager.SaveDocument(this);

			//// Записать в глобальный кеш новые объект
			//foreach (ObjectIdentifier objectId in NewObject)
			//{
			//    EntityObject obj = objectStorage[objectId];
			//}
			//// очистить коллекции созданных объектов
			//NewObject.Clear();

			//// Список id объектов уже перезаписанных в кеше
			//List<ObjectIdentifier> unlockList = new List<ObjectIdentifier>();
			//// добавить измененный объект (свойства) в список для снятия блокировки 
			//foreach (ObjectIdentifier oid in ChangedObjectProperty)
			//{
			//    unlockList.Add(oid);
			//    EntityObject obj = objectStorage[oid];
			//}
			//ChangedObjectProperty.Clear();

			//// добавить измененный объект (свойства) в список для снятия блокировки 
			//foreach (ObjectIdentifier oid in ChangedObjectLink)
			//{
			//    if (!unlockList.Contains(oid))
			//    {
			//        unlockList.Add(oid);
			//        EntityObject obj = objectStorage[oid];
			//    }
			//}
			//ChangedObjectLink.Clear();

			//// очистить из хранилища удаленные объекты
			//foreach (List<ObjectIdentifier> list in m_removeObjectList.Values)
			//{
			//    foreach (ObjectIdentifier oid in list)
			//    {
			//        objectStorage.Remove(oid);
			//    }
			//}
			//m_removeObjectList.Clear();
		}

		private void SateToDB(SessionIdentifier session, ObjectRepository objRepository)
		{
			foreach (IGrouping<string, DomainObject> newObjGroup in objRepository.NewObjectGroup)
			{
				string objCode = newObjGroup.Key;

				DomainObjectBroker objBroker = GetObjectBroker(objCode);
				DbCommonCommand saveCommand = objBroker.NewItemCommand;

				SaveObject(session, newObjGroup, saveCommand);
			}

			foreach (IGrouping<string, DomainObject> saveObjGroup in objRepository.OldChangedObjects)
			{
				string objCode = saveObjGroup.Key;

				DomainObjectBroker objBroker = GetObjectBroker(objCode);
				DbCommonCommand saveCommand = objBroker.SaveItemCommand;

				SaveObject(session, saveObjGroup, saveCommand);
			}

			foreach (IGrouping<string, DomainObject> deleteObjGroup in objRepository.DeletedObjects)
			{
				string objCode = deleteObjGroup.Key;

				DomainObjectBroker objBroker = GetObjectBroker(objCode);
				DbCommonCommand deleteCommand = objBroker.DeleteItemsCommand;

				deleteCommand[DomainObjectBroker.ObjectIdField].Value = deleteObjGroup;
				deleteCommand.ExecuteNonQuery(session, true);
			}

			foreach (KeyValuePair<DomainLink, IEnumerable<DomainLinkNode>> link in objRepository.NewLinks)
			{
				DomainLinkBroker linkBroker = GetLinkBroker(link.Key.Key);
				DbCommonCommand dbCommand = linkBroker.NewItemCommand;

				SaveLink(session, link, dbCommand);
			}

			foreach (KeyValuePair<DomainLink, IEnumerable<DomainLinkNode>> link in objRepository.DeletedLinks)
			{
				DomainLinkBroker linkBroker = GetLinkBroker(link.Key.Key);
				DbCommonCommand dbCommand = linkBroker.DeleteItemCommand;

				SaveLink(session, link, dbCommand);
			}

			m_connection.Commit(session);
		}

		private static void SaveObject(SessionIdentifier session, IGrouping<string, DomainObject> objGroup, DbCommonCommand saveCommand)
		{
			foreach (var obj in objGroup)
			{
				saveCommand[DomainObjectBroker.ObjectIdField].Value = obj.ObjectId.Id;

				foreach (DomainProperty objProperty in obj.Properties)
				{
					saveCommand[objProperty.Code].Value = objProperty.Value;
				}

				saveCommand.ExecuteNonQuery(session, true);
			}
		}

		private static void SaveLink(SessionIdentifier session, KeyValuePair<DomainLink, IEnumerable<DomainLinkNode>> link, DbCommonCommand saveCommand)
		{
			foreach (DomainLinkNode node in link.Value)
			{
				saveCommand[DomainLinkBroker.LeftObjectIdParam].Value = node.LeftObjectId.Id;
				saveCommand[DomainLinkBroker.RightObjectIdParam].Value = node.RightObjectId.Id;

				saveCommand.ExecuteNonQuery(session, true);
			}
		}
	}
}