using System;
using DomainCommonSE.Domain;
using System.Linq;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.DbCommon;
using System.Collections.Generic;

namespace DomainCommonSE
{
	/// <summary>
	/// Документ в рамках которого происходит работа с объектами
	/// </summary>
	public class Document
	{
		/// <summary>
		/// Хранилище материализованных объектов
		/// </summary>
		ObjectRepository m_objRepository;		

		/// <summary>
		/// Сессия документа
		/// </summary>
		public SessionIdentifier Session { get; private set; }

		bool m_isModified;
		/// <summary>
		/// Документ изменен
		/// </summary>
		public bool IsModified
		{
			get
			{
				return m_isModified;
			}
			private set
			{
				if (m_isModified != value)
				{
					m_isModified = value;

					if (ModifiedChanged != null)
						ModifiedChanged(this, EventArgs.Empty);
				}
			}
		}
		/// <summary>
		/// Состояние документа изменено
		/// </summary>
		public event EventHandler ModifiedChanged;

		internal Document(SessionIdentifier sid, DomainObjectInquiry inquiry)
		{
			Session = sid;
			m_objRepository = new ObjectRepository(Session, inquiry);
		}

		internal void AddObject(DomainObject obj)
		{
			m_objRepository.Add(obj);
		}

		public DomainObject GetObject(ObjectIdentifier oid)
		{
			DomainObject result = null;

			result = m_objRepository.GetObject(oid);
			if (result != null)
				return result;

			result = DomainObjectManager.Instance.SharedRepository.BeginGetObject(oid, Session);

			if (result == null)
				result = DomainObjectManager.Instance.Materialize(Session, oid);

			m_objRepository.Add(result);

			result.PropertiesChanged += result_PropertiesChanged;

			return result;
		}

		void result_PropertiesChanged(object sender, EventArgs e)
		{
			IsModified = true;
		}
		/// <summary>
		/// Сохранить изменения
		/// </summary>
		public void Save()
		{
			DomainObjectManager.Instance.SaveRepository(Session, m_objRepository);
			IsModified = false;
		}

		public void Cancel()
		{
			//m_documentManager.CancelDocument(this);
			IsModified = false;

			throw new NotImplementedException();
		}

		public void Close()
		{
			//m_documentManager.CloseDocument(this);
			//IsModified = false;

			//throw new NotImplementedException();
		}

		internal DomainLink GetLink(DomainLinkKey key)
		{
			return m_objRepository.GetLink(key);
		}
	}
}