using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using DomainCommonSE.DbCommon;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE
{
	public class InquiryDbProvider : ObjectInquiryProvider
	{
		IDbCommonConnection m_connection;

		public InquiryDbProvider(IDbCommonConnection connection)
		{
			if (connection == null)
				throw new ArgumentNullException("connection");

			m_connection = connection;

			m_loadObjectCommand = new Lazy<DbCommonCommand>(CreateLoadObjectCommand);
			m_createObjectCommand = new Lazy<DbCommonCommand>(CreateNewObjectCommand);
			m_editObjectCommand = new Lazy<DbCommonCommand>(CreateEditObjectCommand);
			m_removeObjectCommand = new Lazy<DbCommonCommand>(CreateRemoveObjectCommand);

			m_loadPropertyCommand = new Lazy<DbCommonCommand>(CreateLoadPropertyCommand);
			m_createPropertyCommand = new Lazy<DbCommonCommand>(CreateNewPropertyCommand);
			m_editPropertyCommand = new Lazy<DbCommonCommand>(CreateEditPropertyCommand);
			m_removePropertyCommand = new Lazy<DbCommonCommand>(CreateRemovePropertyCommand);

			m_loadLinkCommand = new Lazy<DbCommonCommand>(CreateLoadLinkCommand);
			m_createLinkCommand = new Lazy<DbCommonCommand>(CreateNewLinkCommand);
			m_editLinkCommand = new Lazy<DbCommonCommand>(CreateEditLinkCommand);
			m_removeLinkCommand = new Lazy<DbCommonCommand>(CreateRemoveLinkCommand);

			m_loadObjectQueryCommand = new Lazy<DbCommonCommand>(CreateLoadObjectQueryCommand);
			m_createObjectQueryCommand = new Lazy<DbCommonCommand>(CreateNewObjectQueryCommand);
			m_editObjectQueryCommand = new Lazy<DbCommonCommand>(CreateEditObjectQueryCommand);
			m_removeObjectQueryCommand = new Lazy<DbCommonCommand>(CreateRemoveObjectQueryCommand);
		}

		public override void Deploy()
		{
			m_connection.DeployORMInquiryScheme();
		}

		public override void Save() 
		{
			m_connection.Commit(SessionIdentifier.SHARED_SESSION);
		}

		Lazy<DbCommonCommand> m_loadObjectCommand;
		Lazy<DbCommonCommand> m_createObjectCommand;
		Lazy<DbCommonCommand> m_editObjectCommand;
		Lazy<DbCommonCommand> m_removeObjectCommand;

		#region Создания SQL комманд управления объектами
		private DbCommonCommand CreateLoadObjectCommand()
		{
			const string sql = "SELECT ID_ORM_CONFIG_OBJECT, CODE, DESCRIPTION, TABLE_NAME, ID_FIELD, CODE_NAME FROM ORM_CONFIG_OBJECT";
			DbCommonCommand command = new DbCommonCommand(sql, m_connection);

			return command;
		}

		private DbCommonCommand CreateNewObjectCommand()
		{
			const string sql = "INSERT INTO ORM_CONFIG_OBJECT (ID_ORM_CONFIG_OBJECT, CODE, CODE_NAME, DESCRIPTION, TABLE_NAME, ID_FIELD) VALUES (@{ID}, @{CODE}, @{CODE_NAME}, @{DESCRIPTION}, @{TABLE_NAME}, @{ID_FIELD})";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));
			command.AddParameter("CODE", typeof(string));
			command.AddParameter("CODE_NAME", typeof(string));
			command.AddParameter("DESCRIPTION", typeof(string));
			command.AddParameter("TABLE_NAME", typeof(string));
			command.AddParameter("ID_FIELD", typeof(string));

			return command;
		}

		private DbCommonCommand CreateEditObjectCommand()
		{
			const string sql = "UPDATE ORM_CONFIG_OBJECT SET CODE_NAME = @{CODE_NAME}, DESCRIPTION = @{DESCRIPTION} WHERE ID_ORM_CONFIG_OBJECT = @{ID}";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));
			command.AddParameter("CODE_NAME", typeof(string));
			command.AddParameter("DESCRIPTION", typeof(string));

			return command;
		}

		private DbCommonCommand CreateRemoveObjectCommand()
		{
			const string sql = "DELETE FROM ORM_CONFIG_OBJECT WHERE ID_ORM_CONFIG_OBJECT = @{ID}";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));

			return command;
		}
		#endregion

		Lazy<DbCommonCommand> m_loadPropertyCommand;
		Lazy<DbCommonCommand> m_createPropertyCommand;
		Lazy<DbCommonCommand> m_editPropertyCommand;
		Lazy<DbCommonCommand> m_removePropertyCommand;

		#region Создания SQL комманд управления свойствами объектов
		private DbCommonCommand CreateLoadPropertyCommand()
		{
			const string sql = "SELECT PR.ID_ORM_CONFIG_PROPERTY, PR.CODE, PR.DESCRIPTION, OBJ.CODE AS OWNER_CODE, PR.DATA_TYPE, PR.ASSEMBLY_FILE, PR.FIELD_NAME, PR.DEFAULT_VALUE, PR.FIELD_LENGTH, PR.CODE_NAME FROM ORM_CONFIG_PROPERTY PR, ORM_CONFIG_OBJECT OBJ WHERE PR.ID_ORM_CONFIG_OBJECT = OBJ.ID_ORM_CONFIG_OBJECT";
			DbCommonCommand command = new DbCommonCommand(sql, m_connection);

			return command;
		}

		private DbCommonCommand CreateNewPropertyCommand()
		{
			const string sql = "INSERT INTO ORM_CONFIG_PROPERTY (ID_ORM_CONFIG_PROPERTY, CODE, CODE_NAME, DESCRIPTION, ID_ORM_CONFIG_OBJECT, DATA_TYPE, ASSEMBLY_FILE, FIELD_NAME, DEFAULT_VALUE, FIELD_LENGTH) VALUES (@{ID}, @{CODE}, @{CODE_NAME}, @{DESCRIPTION}, @{ID_ORM_CONFIG_OBJECT}, @{DATA_TYPE}, @{ASSEMBLY_FILE}, @{FIELD_NAME}, @{DEFAULT_VALUE}, @{FIELD_LENGTH})";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);

			command.AddParameter("ID", typeof(long));
			command.AddParameter("CODE", typeof(string));
			command.AddParameter("CODE_NAME", typeof(string));
			command.AddParameter("DESCRIPTION", typeof(string));
			command.AddParameter("ID_ORM_CONFIG_OBJECT", typeof(long));
			command.AddParameter("DATA_TYPE", typeof(string));
			command.AddParameter("ASSEMBLY_FILE", typeof(string));
			command.AddParameter("FIELD_NAME", typeof(string));
			DbCommonCommandParameter defaultValueParam = command.AddParameter("DEFAULT_VALUE", typeof(object));
			defaultValueParam.AllowNull = true;
			command.AddParameter("FIELD_LENGTH", typeof(int));

			return command;
		}

		private DbCommonCommand CreateEditPropertyCommand()
		{
			const string sql = "UPDATE ORM_CONFIG_PROPERTY SET CODE_NAME = @{CODE_NAME}, DESCRIPTION = @{DESCRIPTION}, DEFAULT_VALUE = @{DEFAULT_VALUE} WHERE ID_ORM_CONFIG_PROPERTY = @{ID}";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));
			command.AddParameter("CODE_NAME", typeof(string));
			command.AddParameter("DESCRIPTION", typeof(string));
			command.AddParameter("DEFAULT_VALUE", typeof(object));

			return command;
		}

		private DbCommonCommand CreateRemovePropertyCommand()
		{
			const string sql = "DELETE FROM ORM_CONFIG_PROPERTY WHERE ID_ORM_CONFIG_PROPERTY = @{ID}";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));

			return command;
		}
		#endregion

		Lazy<DbCommonCommand> m_loadLinkCommand;
		Lazy<DbCommonCommand> m_createLinkCommand;
		Lazy<DbCommonCommand> m_editLinkCommand;
		Lazy<DbCommonCommand> m_removeLinkCommand;

		#region Создания SQL комманд управления ссылками
		private DbCommonCommand CreateLoadLinkCommand()
		{
			const string sql = "SELECT LNK.ID_ORM_CONFIG_LINK, LNK.CODE, LNK.LEFT_RELATION, LNK.RIGHT_RELATION, LO.CODE AS LEFT_OBJECT_CODE, RO.CODE AS RIGHT_OBJECT_CODE, LNK.LINK_TABLE_NAME, LNK.LEFT_ID_FIELD, LNK.RIGHT_ID_FIELD, LNK.IS_LEFT_TO_RIGHT_ACTIVE, LNK.IS_RIGHT_TO_LEFT_ACTIVE, LNK.LEFT_TO_RIGHT_DESCRIPTION, LNK.RIGHT_TO_LEFT_DESCRIPTION, LNK.LEFT_COLLECTION_NAME, LNK.RIGHT_COLLECTION_NAME FROM ORM_CONFIG_LINK LNK, ORM_CONFIG_OBJECT LO, ORM_CONFIG_OBJECT RO WHERE LO.ID_ORM_CONFIG_OBJECT = LNK.ID_LEFT_OBJECT AND RO.ID_ORM_CONFIG_OBJECT = LNK.ID_RIGHT_OBJECT";
			DbCommonCommand command = new DbCommonCommand(sql, m_connection);

			return command;
		}

		private DbCommonCommand CreateNewLinkCommand()
		{
			const string sql = "INSERT INTO ORM_CONFIG_LINK(ID_ORM_CONFIG_LINK, CODE, LEFT_RELATION, RIGHT_RELATION, ID_LEFT_OBJECT, ID_RIGHT_OBJECT, LINK_TABLE_NAME, LEFT_ID_FIELD, RIGHT_ID_FIELD) VALUES(@{ID}, @{CODE}, @{LEFT_RELATION}, @{RIGHT_RELATION}, @{ID_LEFT_OBJECT}, @{ID_RIGHT_OBJECT}, @{LINK_TABLE_NAME}, @{LEFT_ID_FIELD}, @{RIGHT_ID_FIELD})";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));
			command.AddParameter("CODE", typeof(string));
			command.AddParameter("LEFT_RELATION", typeof(string));
			command.AddParameter("RIGHT_RELATION", typeof(string));
			command.AddParameter("ID_LEFT_OBJECT", typeof(long));
			command.AddParameter("ID_RIGHT_OBJECT", typeof(long));
			command.AddParameter("LINK_TABLE_NAME", typeof(string));
			command.AddParameter("LEFT_ID_FIELD", typeof(string));
			command.AddParameter("RIGHT_ID_FIELD", typeof(string));

			return command;
		}

		private DbCommonCommand CreateEditLinkCommand()
		{
			const string sql = "UPDATE ORM_CONFIG_LINK SET IS_LEFT_TO_RIGHT_ACTIVE = @{IS_LEFT_TO_RIGHT_ACTIVE}, IS_RIGHT_TO_LEFT_ACTIVE = @{IS_RIGHT_TO_LEFT_ACTIVE}, LEFT_COLLECTION_NAME = @{LEFT_COLLECTION_NAME}, RIGHT_COLLECTION_NAME = @{RIGHT_COLLECTION_NAME}, LEFT_TO_RIGHT_DESCRIPTION = @{LEFT_TO_RIGHT_DESCRIPTION}, RIGHT_TO_LEFT_DESCRIPTION = @{RIGHT_TO_LEFT_DESCRIPTION} WHERE ID_ORM_CONFIG_LINK = @{ID}";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);

			command.AddParameter("ID", typeof(long));
			command.AddParameter("IS_LEFT_TO_RIGHT_ACTIVE", typeof(bool));
			command.AddParameter("IS_RIGHT_TO_LEFT_ACTIVE", typeof(bool));
			command.AddParameter("LEFT_COLLECTION_NAME", typeof(string));
			command.AddParameter("RIGHT_COLLECTION_NAME", typeof(string));
			command.AddParameter("LEFT_TO_RIGHT_DESCRIPTION", typeof(string));
			command.AddParameter("RIGHT_TO_LEFT_DESCRIPTION", typeof(string));

			return command;
		}

		private DbCommonCommand CreateRemoveLinkCommand()
		{
			const string sql = "DELETE FROM ORM_CONFIG_LINK WHERE ID_ORM_CONFIG_LINK = @{ID}";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));

			return command;
		}
		#endregion

		Lazy<DbCommonCommand> m_loadObjectQueryCommand;
		Lazy<DbCommonCommand> m_createObjectQueryCommand;
		Lazy<DbCommonCommand> m_editObjectQueryCommand;
		Lazy<DbCommonCommand> m_removeObjectQueryCommand;

		#region Создание SQL комманд управления объектными запросами
		private DbCommonCommand CreateLoadObjectQueryCommand()
		{
			string sql = String.Format("SELECT ID_ORM_CONFIG_QUERY, CODE, OBJECT_TYPE, SOURCE, NOTES FROM ORM_CONFIG_QUERY WHERE REMOVED = {0}", m_connection.GetTypeValue(false));
			DbCommonCommand command = new DbCommonCommand(sql, m_connection);

			return command;
		}

		private DbCommonCommand CreateNewObjectQueryCommand()
		{
			string sql = String.Format("INSERT INTO ORM_CONFIG_QUERY (ID_ORM_CONFIG_QUERY, CODE, OBJECT_TYPE, SOURCE, NOTES, REMOVED) VALUES (@{{ID}}, @{{CODE}}, @{{OBJECT_TYPE}}, @{{SOURCE}}, @{{NOTES}}, {0})", m_connection.GetTypeValue(false));

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));
			command.AddParameter("CODE", typeof(string));
			command.AddParameter("OBJECT_TYPE", typeof(string));
			command.AddParameter("SOURCE", typeof(object));
			command.AddParameter("NOTES", typeof(string));

			return command;
		}

		private DbCommonCommand CreateEditObjectQueryCommand()
		{
			const string sql = "UPDATE ORM_CONFIG_QUERY SET CODE = @{CODE}, OBJECT_TYPE = @{OBJECT_TYPE}, SOURCE = @{SOURCE}, NOTES = @{NOTES} WHERE ID_ORM_CONFIG_QUERY = @{ID}";

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));
			command.AddParameter("CODE", typeof(string));
			command.AddParameter("OBJECT_TYPE", typeof(string));
			command.AddParameter("SOURCE", typeof(object));
			command.AddParameter("NOTES", typeof(string));

			return command;
		}

		private DbCommonCommand CreateRemoveObjectQueryCommand()
		{
			string sql = String.Format("UPDATE ORM_CONFIG_QUERY SET REMOVED = {0} WHERE ID_ORM_CONFIG_QUERY = @{{CODE}}", m_connection.GetTypeValue(true));

			DbCommonCommand command = new DbCommonCommand(sql, m_connection);
			command.AddParameter("ID", typeof(long));

			return command;
		}
		#endregion

		DomainObjectConfigCollection m_objectConfig;

		#region Инициализация
		public override DomainObjectConfigCollection LoadObject()
		{
			DbCommonCommand command = null;
			IDbCommonDataReader reader = null;

			m_objectConfig = new DomainObjectConfigCollection();

			#region Загрузка объектов
			command = m_loadObjectCommand.Value;

			using (reader = command.ExecuteReader(SessionIdentifier.SHARED_SESSION))
			{
				while (reader.Read())
				{
					long id = reader.GetValue<long>(0);
					string code = reader.GetValue<String>(1);
					string description = reader.GetValue<String>(2);
					string tableName = reader.GetValue<String>(3);
					string idField = reader.GetValue<String>(4);
					string codeName = reader.GetValue<String>(5);

					DomainObjectConfig configObject = new DomainObjectConfig(id, code, description, tableName, idField, codeName);
					m_objectConfig.Add(configObject);
				}
				reader.Close();
			}
			#endregion

			#region Загрузка свойств
			command = m_loadPropertyCommand.Value;

			using (reader = command.ExecuteReader(SessionIdentifier.SHARED_SESSION))
			{
				while (reader.Read())
				{
					long id = reader.GetValue<long>(0);
					string code = reader.GetValue<String>(1);
					string description = reader.GetValue<String>(2);
					string ownerCode = reader.GetValue<String>(3);
					
					string dataTypeName = reader.GetValue<String>(4);
					string assemblyFile = reader.GetValue<String>(5);
					Type dataType = GetValueType(assemblyFile, dataTypeName);

					string filedName = reader.GetValue<String>(6);
					object defaultValue = reader.GetValue(7, typeof(object));
					int length = reader.GetValue<Int32>(8);
					string codeName = reader.GetValue<String>(9);

					DomainObjectConfig owner = m_objectConfig[ownerCode];
					DomainPropertyConfig property = new DomainPropertyConfig(id, code, description, owner, dataType, filedName, defaultValue, length, codeName);
										
					owner.Property.Add(property);
				}
				reader.Close();
			}
			#endregion

			return m_objectConfig;
		}

		public override List<DomainLinkConfig> LoadLink()
		{
			List<DomainLinkConfig> result = new List<DomainLinkConfig>();
			DbCommonCommand command = m_loadLinkCommand.Value;

			using (IDbCommonDataReader reader = command.ExecuteReader(SessionIdentifier.SHARED_SESSION))
			{
				while (reader.Read())
				{
					CreateLinkParams createParams = new CreateLinkParams();

					createParams.Id = reader.GetValue<long>(0);
					createParams.Code = reader.GetValue<String>(1);
					createParams.LeftRelation = (eRelation)reader.GetValue<Int32>(2);
					createParams.RightRelation = (eRelation)reader.GetValue<Int32>(3);

					string leftObjectCode = reader.GetValue<string>(4);
					createParams.LeftObject = m_objectConfig[leftObjectCode];

					string rightObjectCode = reader.GetValue<string>(5);
					createParams.RightObject = m_objectConfig[rightObjectCode];

					createParams.LinkTable = reader.GetValue<string>(6);
					createParams.LeftObjectIdField = reader.GetValue<string>(7);
					createParams.RightObjectIdField = reader.GetValue<string>(8);

					EditLinkParams editParams = new EditLinkParams();

					editParams.IsLeftToRightActive = reader.GetValue<bool>(9);
					editParams.IsRightToLeftActive = reader.GetValue<bool>(10);
					editParams.LeftToRightDescription = reader.GetValue<string>(11);
					editParams.RightToLeftDescription = reader.GetValue<string>(12);
					editParams.LeftCollectionName = reader.GetValue<string>(13);
					editParams.RightCollectionName = reader.GetValue<string>(14);

					DomainLinkConfig loadLink = new DomainLinkConfig(createParams, editParams);
					result.Add(loadLink);
				}
				reader.Close();
			}

			return result;
		}

		public override ObjectQueryCollection LoadQuery()
		{
			DbCommonCommand command = m_loadObjectQueryCommand.Value;
			ObjectQueryCollection result = new ObjectQueryCollection();

			using (IDbCommonDataReader reader = command.ExecuteReader(SessionIdentifier.SHARED_SESSION))
			{
				while (reader.Read())
				{
					long id = reader.GetValue<long>(0);
					string code = reader.GetValue<String>(1);
					string objectType = reader.GetValue<String>(2);
					string source = (string)reader.GetValue<object>(3);
					string notes = reader.GetValue<String>(4);

					ObjectQuery query = new ObjectQuery(id, code, objectType, source, notes);
					result.Add(query);
				}
				reader.Close();
			}

			return result;
		}
		#endregion

		public override void CreateObject(DomainObjectConfig objConfig)
		{
			DbCommonCommand command = m_createObjectCommand.Value;

			command["ID"].Value = objConfig.Id;
			command["CODE"].Value = objConfig.Code;
			command["DESCRIPTION"].Value = objConfig.Description;
			command["TABLE_NAME"].Value = objConfig.TableName;
			command["ID_FIELD"].Value = objConfig.IdField;
			command["CODE_NAME"].Value = objConfig.CodeName;

			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void SaveObject(DomainObjectConfig objConfig)
		{
			DbCommonCommand command = m_editObjectCommand.Value;

			command["ID"].Value = objConfig.Id;
			command["CODE_NAME"].Value = objConfig.CodeName;
			command["DESCRIPTION"].Value = objConfig.Description;
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void DeleteObject(DomainObjectConfig objConfig)
		{
			DbCommonCommand command = m_removeObjectCommand.Value;

			command["ID"].Value = objConfig.Id;
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void CreateObjectProperty(DomainPropertyConfig propConfig)
		{
			DbCommonCommand command = m_createPropertyCommand.Value;

			command["ID"].Value = propConfig.Id;
			command["CODE"].Value = propConfig.Code;
			command["CODE_NAME"].Value = propConfig.CodeName;
			command["DESCRIPTION"].Value = propConfig.Description;
			command["ID_ORM_CONFIG_OBJECT"].Value = propConfig.Owner.Id;
			command["DATA_TYPE"].Value = propConfig.DataType.ToString();
			command["ASSEMBLY_FILE"].Value = propConfig.DataType.Assembly.ManifestModule.Name;
			command["FIELD_NAME"].Value = propConfig.FieldName;
			command["DEFAULT_VALUE"].Value = propConfig.DefaultValue;
			command["FIELD_LENGTH"].Value = propConfig.Size;			
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void SaveObjectProperty(DomainPropertyConfig propConfig)
		{
			DbCommonCommand command = m_editPropertyCommand.Value;

			command["ID"].Value = propConfig.Id;
			command["CODE_NAME"].Value = propConfig.CodeName;
			command["DESCRIPTION"].Value = propConfig.Description;
			command["DEFAULT_VALUE"].Value = propConfig.DefaultValue;
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void DeleteObjectProperty(DomainPropertyConfig propConfig)
		{
			DbCommonCommand command = m_removePropertyCommand.Value;

			command["ID"].Value = propConfig.Id;
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void CreateLink(CreateLinkParams createParams)
		{
			DbCommonCommand command = m_createLinkCommand.Value;

			command["ID"].Value = createParams.Id;
			command["CODE"].Value = createParams.Code;
			command["LEFT_RELATION"].Value = (int)createParams.LeftRelation;
			command["RIGHT_RELATION"].Value = (int)createParams.RightRelation;
			command["ID_LEFT_OBJECT"].Value = createParams.LeftObject.Id;
			command["ID_RIGHT_OBJECT"].Value = createParams.RightObject.Id;
			command["LINK_TABLE_NAME"].Value = createParams.LinkTable;
			command["LEFT_ID_FIELD"].Value = createParams.LeftObjectIdField;
			command["RIGHT_ID_FIELD"].Value = createParams.RightObjectIdField;

			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void SaveLink(DomainLinkConfig link, EditLinkParams editParams)
		{
			DbCommonCommand command = m_editLinkCommand.Value;
			
			command["ID"].Value = link.Id;
			command["IS_LEFT_TO_RIGHT_ACTIVE"].Value = editParams.IsLeftToRightActive;
			command["IS_RIGHT_TO_LEFT_ACTIVE"].Value = editParams.IsRightToLeftActive;
			command["LEFT_COLLECTION_NAME"].Value = editParams.LeftCollectionName;
			command["RIGHT_COLLECTION_NAME"].Value = editParams.RightCollectionName;
			command["LEFT_TO_RIGHT_DESCRIPTION"].Value = editParams.LeftToRightDescription;
			command["RIGHT_TO_LEFT_DESCRIPTION"].Value = editParams.RightToLeftDescription;

			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void DeleteLink(DomainLinkConfig link)
		{
			DbCommonCommand command = m_removeLinkCommand.Value;

			command["ID"].Value = link.Id;
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void CreateObjectQuery(ObjectQuery query)
		{
			DbCommonCommand command = m_createObjectQueryCommand.Value;

			command["ID"].Value = query.Id;
			command["CODE"].Value = query.Code;
			command["OBJECT_TYPE"].Value = query.ObjectType;
			command["SOURCE"].Value = query.Source;
			command["NOTES"].Value = query.Notes;

			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void SaveObjectQuery(ObjectQuery query, EditObjectQueryParams editParams)
		{
			DbCommonCommand command = m_editObjectQueryCommand.Value;			

			command["ID"].Value = query.Id;
			command["CODE"].Value = editParams.Code;
			command["OBJECT_TYPE"].Value = editParams.ObjectType;
			command["SOURCE"].Value = editParams.Source;
			command["NOTES"].Value = editParams.Notes;

			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void DeleteObjectQuery(ObjectQuery query)
		{
			DbCommonCommand command = m_removeObjectQueryCommand.Value;

			command["ID"].Value = query.Id;
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		//public ObjectQueryParameter CreateQueryParameter(ObjectQuery query)
		//{
		//    if (query.Parameters.Contains(String.Empty))
		//        throw new ApplicationException("Сначала заполните у всех имеющихся параметров идентификаторы");

		//    ObjectQueryParameter newParam = new ObjectQueryParameter(query);
		//    newParam.DataType = typeof(string);

		//    query.Parameters.Add(String.Empty, newParam);

		//    IsEdited = true;

		//    return newParam;
		//}

		//public void EditQueryParameter(string newCode, ObjectQueryParameter parameter)
		//{
		//    ObjectQuery query = parameter.Owner;

		//    if (query.Parameters.Contains(newCode))
		//        throw new EntityObjectException();

		//    query.Parameters.ChangeKey(parameter.Code, newCode, parameter);

		//    IsEdited = true;
		//}

		//public void RemoveQueryParameter(ObjectQueryParameter parameter)
		//{
		//    ObjectQuery query = parameter.Owner;
		//    query.Parameters.Delete(parameter.Code);
		//}
		//#endregion

	}
}
