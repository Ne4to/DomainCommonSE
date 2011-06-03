using System;
using System.Collections.Generic;
using DomainCommonSE.Domain;
using System.Threading;
using DomainCommonSE.DomainConfig;

namespace DomainCommonSE
{
	internal class SharedObjectRepository
	{
		ObjectRepository m_sharedObjRepository;
		object m_sharedObjRepositoryLock = new object();
		Dictionary<ObjectIdentifier, object> m_getObjectLock = new Dictionary<ObjectIdentifier, object>();
		private DomainObjectInquiry m_inquiry;
		private DomainObjectFactory m_objectFactory;

		public SharedObjectRepository(DomainObjectInquiry objectInquiry, DomainObjectFactory objectFactory)
		{
			m_sharedObjRepository = new ObjectRepository(SessionIdentifier.SHARED_SESSION, objectInquiry);
			m_objectFactory = objectFactory;
		}

		public DomainObject BeginGetObject(ObjectIdentifier objectId, SessionIdentifier sessionId)
		{
			DomainObject tempResult = null;
			bool needCloneObject = true;
			object lockObject = null;

			lock (m_sharedObjRepositoryLock)
			{
				tempResult = m_sharedObjRepository.GetObject(objectId);
				if (tempResult != null)
					return CloneObject(tempResult, sessionId);

				// сюда мы попадем если только объект еще не загружен
				lock (m_getObjectLock)
				{
					if (!m_getObjectLock.TryGetValue(objectId, out lockObject))
					{
						// если объект не заблокирован другим документом, то 
						lockObject = new object();
						m_getObjectLock.Add(objectId, lockObject);

						needCloneObject = false;
						Monitor.Enter(lockObject);
					}
				}
			}

			if (needCloneObject)
				Monitor.Enter(lockObject);

			// сюда потоки попадут в том порядке в котором они одновременно пытаются запросить объект с одним и тем же Id

			// если этот поток первый запрашивает объект, то ничего не возвращаем
			if (!needCloneObject)
				return null;

			Monitor.Exit(lockObject);
			// после того как объект материтализовался в другом документе(потоке) возвращаем его
			lock (m_sharedObjRepositoryLock)
			{
				// получаем объект из расшаренной сессии
				tempResult = m_sharedObjRepository.GetObject(objectId);
				// клонируем объект
				return CloneObject(tempResult, sessionId);
			}
		}

		public void EngGetObject(DomainObject obj)
		{
			object lockObject = null;
			lock (m_getObjectLock)
			{
				m_getObjectLock.TryGetValue(obj.ObjectId, out lockObject);
			}

			// если в списке есть элемент с этим Id, то это первый поток и надо сохранить его в глобальное хранилище
			if (lockObject != null)
			{
				lock (m_sharedObjRepositoryLock)
				{
					PutToStorage(obj);
				}

				lock (m_getObjectLock)
				{
					m_getObjectLock.Remove(obj.ObjectId);
				}

				Monitor.Exit(lockObject);
			}
		}

		public DomainLink GetLink(DomainLinkKey key)
		{
			return m_sharedObjRepository.GetLink(key);
		}

		#region Клонирование объектов логики
		private DomainObject CloneObject(DomainObject obj, SessionIdentifier newSession)
		{
			DomainPropertyCollection propertyCollection = new DomainPropertyCollection();
			//EntityLinkCollection linkCollection = new EntityLinkCollection();

			foreach (DomainProperty property in obj.Properties)
			{
				DomainProperty newProperty = CloneProperty(property, newSession);
				propertyCollection.Add(newProperty);
			}

			//foreach (EntityLink link in obj.Links)
			//{
			//    EntityLink newLink = CloneLink(link, newSession);
			//    linkCollection.Add(newLink);
			//}

			DomainObject result = m_objectFactory.CreateDomainObject(newSession, obj.ObjectId);
			result.Init(propertyCollection);

			return result;
		}

		private DomainProperty CloneProperty(DomainProperty property, SessionIdentifier newSession)
		{
			return new DomainProperty(newSession, property.m_parentId, property.Code, property.Value);
		}

		//private EntityLink CloneLink(EntityLink link, SessionIdentifier newSession)
		//{
		//    EntityLink clone = new EntityLink(newSession, link.ParentId, link.Code, link.ObjectCode, link.IsCollection, link.IsPrimary, link.IsReverseActive, link.ReverseLinkCode);

		//    clone.Changed = link.Changed;

		//    clone.Objects = link.Objects.Clone(newSession);

		//    clone.AddObject.AddRange(link.AddObject);
		//    clone.DelObject.AddRange(link.DelObject);

		//    return clone;
		//}
		#endregion

		private void PutToStorage(DomainObject obj)
		{
			DomainObject sharedObj = CloneObject(obj, SessionIdentifier.SHARED_SESSION);
			m_sharedObjRepository.Add(sharedObj);
		}


		//private void UnlockAllObjectInSession(SessionIdentifier session)
		//{
		//    List<ObjectIdentifier> unlockList = new List<ObjectIdentifier>();

		//    lock (lockedObjectStorage)
		//    {
		//        foreach (LocalObjectLockInfo info in lockedObjectStorage.Values)
		//        {
		//            if (info.Session == session)
		//            {
		//                unlockList.Add(info.ObjectId);
		//            }
		//        }

		//        foreach (ObjectIdentifier oid in unlockList)
		//        {
		//            UnlockObject(session, oid);
		//        }
		//    }
		//}

		/// <summary>
		/// Разблокировать объект
		/// </summary>
		/// <param name="session"></param>
		/// <param name="objectId"></param>
		private void UnlockObject(SessionIdentifier session, ObjectIdentifier objectId)
		{
			//LocalObjectLockInfo objectLock = null;
			//if (!lockedObjectStorage.TryGetValue(objectId, out objectLock))
			//{
			//    throw new DomainException(String.Format("Попытка разблокировать не заблокированный объект {0},{1}", session, objectId));
			//}

			//if (objectLock.Session != session)
			//{
			//    throw new DomainException(String.Format("Попытка разблокировать объект {0},{1} из сессии", objectLock.Session, objectLock.ObjectId, session));
			//}

			//lockedObjectStorage.Remove(objectId);
		}

		//public DomainObject GetObject(SessionIdentifier sessionId, ObjectIdentifier objectId)
		//{
		//    //return m_document[sessionId].GetObject(objectId);
		//}

		public void SaveRepositoryChanges(ObjectRepository objRepository)
		{
			lock (m_sharedObjRepositoryLock)
			{
				foreach (DomainObject obj in objRepository.NewObject)
				{
					DomainObject sharedObj = CloneObject(obj, SessionIdentifier.SHARED_SESSION);
					m_sharedObjRepository.Add(sharedObj);
				}

				foreach (DomainObject obj in objRepository.PropertyModifiedObject)
				{
					DomainObject sharedObj = CloneObject(obj, SessionIdentifier.SHARED_SESSION);
					m_sharedObjRepository.ChangeTo(sharedObj);
				}
			}
		}
	}

	public class LocalObjectLockInfo
	{
		public SessionIdentifier Session { get; private set; }
		public ObjectIdentifier ObjectId { get; private set; }
		public DateTime BeginLockDate { get; private set; }

		public LocalObjectLockInfo(SessionIdentifier session, ObjectIdentifier objectId, DateTime lockDate)
		{
			Session = session;
			ObjectId = objectId;
			BeginLockDate = lockDate;
		}
	}
}
