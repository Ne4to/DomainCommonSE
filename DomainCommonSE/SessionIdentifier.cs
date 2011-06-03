using System;

namespace DomainCommonSE
{
	/// <summary>
	/// Session identifier
	/// </summary>
	public struct SessionIdentifier : IEquatable<SessionIdentifier>, IComparable<SessionIdentifier>
	{
		readonly long m_id;
		/// <summary>
		/// Unique number
		/// </summary>
		public long Id { get { return m_id; } }
		/// <summary>
		/// Error session identifier
		/// </summary>
		public static SessionIdentifier ERROR_SESSION
		{
			get
			{
				return new SessionIdentifier(-1);
			}
		}
		/// <summary>
		/// Расшаренная сессия (служебная)
		/// </summary>
		public static SessionIdentifier SHARED_SESSION
		{
			get
			{
				return new SessionIdentifier(0);
			}
		}

		public SessionIdentifier(long id)
		{
			m_id = id;
		}

		public override int GetHashCode()
		{
			return m_id.GetHashCode();
		}

		public override bool Equals(object o)
		{
			if (m_id == ((SessionIdentifier)o).Id)
				return true;
			else
				return false;
		}

		public override string ToString()
		{
			return String.Format("[SESSION #{0}]", Id);
		}

		public bool Equals(SessionIdentifier other)
		{
			return m_id == other.Id;				 
		}

		public int CompareTo(SessionIdentifier other)
		{
			return m_id.CompareTo(other.Id);			
		}

		public static bool operator ==(SessionIdentifier left, SessionIdentifier right)
		{
			return left.m_id == right.m_id;
		}

		public static bool operator !=(SessionIdentifier left, SessionIdentifier right)
		{
			return left.m_id != right.m_id;
		}
	}
}
