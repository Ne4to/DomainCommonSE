using System;

namespace DomainCommonSE.Domain
{
	/// <summary>
	/// Свойство экземпляра объекта
	/// </summary>
	public sealed class DomainProperty
	{
		public readonly ObjectIdentifier m_parentId;
		readonly SessionIdentifier m_session;

		public event EventHandler ValueChanged;
		public string Code { get; private set; }

		object m_value;
		public object Value
		{
			get
			{
				return m_value;
			}
			set
			{
				if (m_value == value)
					return;

				if (ValueChanged != null)
					ValueChanged(this, EventArgs.Empty);
				ObjectMonitor.Instance.PropertyModified(m_session, m_parentId);

				m_value = value;
			}
		}

		public TValue ValueAs<TValue>()
		{
			return (TValue)Value;
		}

		internal DomainProperty(SessionIdentifier sid, ObjectIdentifier parentId, string code, object value)
		{
			m_session = sid;
			m_parentId = parentId;
			Code = code;
			m_value = value;
		}

		internal DomainProperty Copy(SessionIdentifier newSession)
		{
			return new DomainProperty(newSession, m_parentId, Code, m_value);
		}
	}
}