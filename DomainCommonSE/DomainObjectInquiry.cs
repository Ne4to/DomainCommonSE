using System;
using System.Collections.Generic;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.ObjQuery;
using DomainCommonSE.DbCommon;
using DomainCommonSE.Properties;
using System.Linq;

namespace DomainCommonSE
{
	/// <summary>
	/// Справочник конфигурации
	/// </summary>
	public class DomainObjectInquiry
	{
		readonly ObjectInquiryProvider m_provider;
		public IDbCommonConnection Connection { get; private set; }

		public event EventHandler IsModifiedChanged;

		private bool m_isModified = false;
		public bool IsModified
		{
			get
			{
				return m_isModified;
			}
			private set
			{
				if (m_isModified == value)
					return;

				m_isModified = value;

				if (IsModifiedChanged != null)
					IsModifiedChanged(this, EventArgs.Empty);
			}
		}

		public DomainObjectConfigCollection AObject { get; private set; }
		public List<DomainLinkConfig> ALinks { get; private set; }
		public ObjectQueryCollection AQuery { get; private set; }

		#region События
		public event EventHandler<ObjectConfigArgs> CreateObjectCompleted;
		public event EventHandler<EditObjectConfigArgs> EditObjectCompleted;
		public event EventHandler<ObjectConfigArgs> DeleteObjectCompleted;

		public event EventHandler<PropertyConfigArgs> CreatePropertyCompleted;
		public event EventHandler<EditPropertyConfigArgs> EditPropertyCompleted;
		public event EventHandler<PropertyConfigArgs> DeletePropertyCompleted;

		public event EventHandler<LinkConfigArgs> CreateLinkCompleted;
		public event EventHandler<EditLinkConfigArgs> EditLinkCompleted;
		public event EventHandler<LinkConfigArgs> DeleteLinkCompleted;

		public event EventHandler<ObjectQueryArgs> CreateObjectQueryCompleted;
		public event EventHandler<ObjectQueryArgs> EditObjectQueryCompleted;
		public event EventHandler<ObjectQueryArgs> DeleteObjectQueryCompleted;
		#endregion

		public DomainObjectInquiry(ObjectInquiryProvider provider, IDbCommonConnection connection)
		{
			if (provider == null)
				throw new ArgumentNullException("provider");

			m_provider = provider;

			if (connection == null)
				throw new ArgumentNullException("connection");

			Connection = connection;

			AObject = m_provider.LoadObject();
			ALinks = m_provider.LoadLink();
			AQuery = m_provider.LoadQuery();
		}

		public void Save()
		{
			m_provider.Save();
			IsModified = false;
		}

		public DomainObjectConfig CreateObject(string code, string description, string codeName)
		{
			return CreateObject(code, description, codeName, String.Format("O_{0}", code), "ID_" + code);
		}

		public DomainObjectConfig CreateObject(string code, string description, string codeName, string tableName, string idField)
		{
			if (!Utils.CheckEnglishString(code))
			{
				throw new ArgumentOutOfRangeException("code", Resources.OnlyLatinString);
			}

			if (!Utils.CheckEnglishString(tableName))
			{
				throw new ArgumentOutOfRangeException("tableName", Resources.OnlyLatinString);
			}

			if (!Utils.CheckEnglishString(codeName))
			{
				throw new ArgumentOutOfRangeException("codeName", Resources.OnlyLatinString);
			}

			if (AObject.Contains(code))
				throw new DomainException(String.Format("Объект с кодом '{0}' уже существует.", code));

			//string idField = String.Format("ID_{0}", tableName);

			long newId = Connection.NewSequence();
			DomainObjectConfig newObject = new DomainObjectConfig(newId, code, description, tableName, idField, codeName);

			Connection.CreateTable(tableName, idField);
			Connection.AddTableField(tableName, "REMOVED", typeof(bool), 0, false, false);

			m_provider.CreateObject(newObject);

			AObject.Add(newObject);

			if (CreateObjectCompleted != null)
				CreateObjectCompleted(this, new ObjectConfigArgs(newObject));

			IsModified = true;

			return newObject;
		}

		public void SaveObject(DomainObjectConfig baseObject, string newCodeName, string newDescription)
		{
			if (!Utils.CheckEnglishString(newCodeName))
			{
				throw new ArgumentOutOfRangeException("newCodeName", Resources.OnlyLatinString);
			}

			string prevCodeName = baseObject.CodeName;
			baseObject.Update(newCodeName, newDescription);

			m_provider.SaveObject(baseObject);

			if (EditObjectCompleted != null)
				EditObjectCompleted(this, new EditObjectConfigArgs(baseObject, prevCodeName));

			IsModified = true;
		}

		public void DeleteObject(DomainObjectConfig objConfig)
		{
			foreach (DomainPropertyConfig prop in objConfig.Property)
			{
				DeleteProperty(prop);
			}

			Connection.RemoveTable(objConfig.TableName);

			m_provider.DeleteObject(objConfig);

			AObject.Delete(objConfig.Code);

			if (DeleteObjectCompleted != null)
				DeleteObjectCompleted(this, new ObjectConfigArgs(objConfig));

			IsModified = true;
		}

		public DomainPropertyConfig CreateProperty(DomainObjectConfig baseObject, string code, string description, Type dataType, string fieldName, object defaultValue, int length, string codeName)
		{
			if (!Utils.CheckEnglishString(code))
			{
				throw new ArgumentOutOfRangeException("code", Resources.OnlyLatinString);
			}

			if (!Utils.CheckEnglishString(fieldName))
			{
				throw new ArgumentOutOfRangeException("fieldName", Resources.OnlyLatinString);
			}

			if (!Utils.CheckEnglishString(codeName))
			{
				throw new ArgumentOutOfRangeException("codeName", Resources.OnlyLatinString);
			}

			if (baseObject.Property.Contains(code))
				throw new DomainException(String.Format("Свойство с кодом '{0}' уже существует.", code));

			long newId = Connection.NewSequence();
			DomainPropertyConfig property = new DomainPropertyConfig(newId, code, description, baseObject, dataType, fieldName, defaultValue, length, codeName);

			m_provider.CreateObjectProperty(property);

			Connection.AddTableField(baseObject.TableName, fieldName, dataType, length, defaultValue);

			baseObject.Property.Add(property);

			if (CreatePropertyCompleted != null)
				CreatePropertyCompleted(this, new PropertyConfigArgs(property));

			IsModified = true;

			return property;
		}

		public void SaveProperty(DomainPropertyConfig property, string newCodeName, string newDescription, object newDefaultValue)
		{
			if (!Utils.CheckEnglishString(newCodeName))
			{
				throw new ArgumentOutOfRangeException("newCodeName", Resources.OnlyLatinString);
			}

			string prevCodeName = property.CodeName;
			property.Update(newCodeName, newDescription, newDefaultValue);
			
			m_provider.SaveObjectProperty(property);

			if (EditPropertyCompleted != null)
				EditPropertyCompleted(this, new EditPropertyConfigArgs(property, prevCodeName));

			IsModified = true;
		}

		public void DeleteProperty(DomainPropertyConfig property)
		{
			m_provider.DeleteObjectProperty(property);

			DomainObjectConfig baseObject = AObject[property.Owner.Code];
			Connection.RemoveTableField(baseObject.TableName, property.FieldName);

			baseObject.Property.Delete(property.Code);

			if (DeletePropertyCompleted != null)
				DeletePropertyCompleted(this, new PropertyConfigArgs(property));

			IsModified = true;
		}

		bool IsLinkExist(CreateLinkParams createparams)
		{
			return false;
			//throw new NotImplementedException();
			return ALinks.FirstOrDefault(l => l.Code == createparams.Code &&
				((l.LeftObject == createparams.LeftObject && l.RightObject == createparams.RightObject) ||
				(l.LeftObject == createparams.RightObject && l.RightObject == createparams.LeftObject))) != null;
		}

		public DomainLinkConfig CreateLink(CreateLinkParams createParams)
		{
			if (createParams == null)
				throw new ArgumentNullException("createParams");

			if (String.IsNullOrEmpty(createParams.Code))
				throw new ArgumentNullException("createParams.Code", Resources.EmptyLinkCode);

			if (!Utils.CheckEnglishString(createParams.Code))
			{
				throw new ArgumentOutOfRangeException("createParams.Code", Resources.OnlyLatinString);
			}

			if (createParams.LeftObject == null)
				throw new ArgumentNullException("createParams.LeftObject", Resources.LeftObjectNotAssigned);

			if (createParams.RightObject == null)
				throw new ArgumentNullException("createParams.RightObject", Resources.RightObjectNotAssigned);

			if (createParams.LeftRelation == eRelation.One && createParams.RightRelation == eRelation.One)
				throw new NotSupportedException();

			if (IsLinkExist(createParams))
				throw new ArgumentException("link with this params already exists");

			if (createParams.LeftRelation == eRelation.Many && createParams.RightRelation == eRelation.Many)
			{
				Connection.CreateLinkTable(createParams.LinkTable, createParams.LeftObjectIdField, createParams.RightObjectIdField);
			}
			else
			{
				if (createParams.LeftRelation == eRelation.One)
				{
					Connection.AddTableField(createParams.RightObject.TableName, createParams.LeftObjectIdField, typeof(long));
				}
				else
				{
					Connection.AddTableField(createParams.LeftObject.TableName, createParams.RightObjectIdField, typeof(long));
				}
			}

			long newId = Connection.NewSequence();
			createParams.Id = newId;

			m_provider.CreateLink(createParams);

			DomainLinkConfig newLink = new DomainLinkConfig(createParams);
			ALinks.Add(newLink);

			if (CreateLinkCompleted != null)
				CreateLinkCompleted(this, new LinkConfigArgs(newLink));

			IsModified = true;

			return newLink;
		}

		public void SaveLink(DomainLinkConfig link, EditLinkParams editParams)
		{
			if (!editParams.IsLeftToRightActive && !editParams.IsRightToLeftActive)
				throw new ArgumentException();

			if (!Utils.CheckEnglishString(editParams.LeftCollectionName))
				throw new ArgumentOutOfRangeException("editParams.LeftCollectionName", Resources.OnlyLatinString);

			if (!Utils.CheckEnglishString(editParams.RightCollectionName))
				throw new ArgumentOutOfRangeException("editParams.RightCollectionName", Resources.OnlyLatinString);

			m_provider.SaveLink(link, editParams);

			link.Update(editParams);

			if (EditLinkCompleted != null)
				EditLinkCompleted(this, new EditLinkConfigArgs(link));

			IsModified = true;
		}

		public void DeleteLink(DomainLinkConfig link)
		{
			if (link == null)
				throw new ArgumentNullException("link");

			if (link.LeftRelation == eRelation.Many && link.RightRelation == eRelation.Many)
			{
				Connection.RemoveTable(link.LinkTable);
			}
			else
			{
				if (link.LeftRelation == eRelation.One)
				{
					Connection.RemoveTableField(link.RightObject.TableName, link.LeftObjectIdField);
				}
				else
				{
					Connection.RemoveTableField(link.LeftObject.TableName, link.RightObjectIdField);
				}
			}

			m_provider.DeleteLink(link);

			ALinks.Remove(link);

			if (DeleteLinkCompleted != null)
				DeleteLinkCompleted(this, new LinkConfigArgs(link));

			IsModified = true;
		}

		public ObjectQuery CreateObjectQuery(string code, string objectType, string source, string notes)
		{
			if (AQuery.Contains(code))
				throw new DomainException(String.Format("Объектный запрос с кодом '{0}' уже существует.", code));

			long newId = Connection.NewSequence();
			ObjectQuery newQuery = new ObjectQuery(newId, code, objectType, source, notes);

			m_provider.CreateObjectQuery(newQuery);

			AQuery.Add(newQuery);

			if (CreateObjectQueryCompleted != null)
				CreateObjectQueryCompleted(this, new ObjectQueryArgs(newQuery));

			IsModified = true;

			return newQuery;
		}

		public void SaveObjectQuery(ObjectQuery query, EditObjectQueryParams editParams)
		{
			m_provider.SaveObjectQuery(query, editParams);

			query.Update(editParams);

			if (EditObjectQueryCompleted != null)
				EditObjectQueryCompleted(this, new ObjectQueryArgs(query));

			IsModified = true;
		}

		public void DeleteObjectQuery(ObjectQuery query)
		{
			m_provider.DeleteObjectQuery(query);

			AQuery.Delete(query.Code);

			if (DeleteObjectQueryCompleted != null)
				DeleteObjectQueryCompleted(this, new ObjectQueryArgs(query));

			IsModified = true;
		}
	}

	public class ObjectConfigArgs : EventArgs
	{
		public DomainObjectConfig AObject { get; private set; }

		public ObjectConfigArgs(DomainObjectConfig aobject)
		{
			AObject = aobject;
		}
	}

	public class EditObjectConfigArgs : ObjectConfigArgs
	{
		public string PrevCodeName { get; private set; }

		public EditObjectConfigArgs(DomainObjectConfig newObject, string prevCodeName)
			: base(newObject)
		{
			PrevCodeName = prevCodeName;
		}
	}

	public class PropertyConfigArgs : EventArgs
	{
		public DomainPropertyConfig Property { get; private set; }

		public PropertyConfigArgs(DomainPropertyConfig property)
		{
			Property = property;
		}
	}

	public class EditPropertyConfigArgs : PropertyConfigArgs
	{
		public string PrevCodeName { get; private set; }

		public EditPropertyConfigArgs(DomainPropertyConfig property, string prevCodeName)
			: base(property)
		{
			PrevCodeName = prevCodeName;
		}
	}

	public class LinkConfigArgs : EventArgs
	{
		public DomainLinkConfig Link { get; private set; }

		public LinkConfigArgs(DomainLinkConfig link)
		{
			Link = link;
		}
	}

	public class EditLinkConfigArgs : LinkConfigArgs
	{
		public EditLinkConfigArgs(DomainLinkConfig link)
			: base(link)
		{
			//throw new NotImplementedException("add prev state changed params");
		}
	}

	public class ObjectQueryArgs : EventArgs
	{
		public ObjectQuery Query { get; private set; }

		public ObjectQueryArgs(ObjectQuery query)
		{
			Query = query;
		}
	}
}
