using System;
using DomainCommonSE.Domain;
using System.Runtime.Serialization;

namespace DomainCommonSE
{
	/// <summary>
	/// Уникальный идентификатор объекта
	/// </summary>
	[DataContract]
	public struct ObjectIdentifier : IEquatable<ObjectIdentifier>, IComparable<ObjectIdentifier>
	{
		readonly long m_id;
		/// <summary>
		/// Уникальный номер
		/// </summary>
		[DataMember]
		public long Id { get { return m_id; } }

		readonly string m_code;
		/// <summary>
		/// Код
		/// </summary>
		[DataMember]
		public string Code { get { return m_code; } }
		/// <summary>
		/// Ошибочный идентификатор
		/// </summary>
		public static ObjectIdentifier ERROR_OID
		{
			get
			{
				return new ObjectIdentifier("ERROR_TYPE", -1);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="code">Код объекта</param>
		/// <param name="id">Уникальный номер объекта</param>
		public ObjectIdentifier(string code, long id)
		{
			m_id = id;
			m_code = code;			
		}		

		public override string ToString()
		{
			return String.Format("[{0}, {1}]", Code, Id);
		}

		public override int GetHashCode()
		{
			return Code.GetHashCode() + Id.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				throw new ArgumentNullException("obj");

			if (obj is ObjectIdentifier)
				return Equals((ObjectIdentifier)obj);

			throw new InvalidCastException("The 'obj' argument is not a ObjectIdentifier object.");
		}

		public bool Equals(ObjectIdentifier other)
		{			
			if (Code == other.Code && Id == other.Id)
				return true;
			else
				return false;
		}

		public int CompareTo(ObjectIdentifier other)
		{
			int codeResult = Code.CompareTo(other.Code);

			if (codeResult == 0)
			{
				return Id.CompareTo(other.Id);
			}

			return codeResult;
		}

		public static bool operator ==(ObjectIdentifier left, ObjectIdentifier right)
		{
			return left.m_id == right.m_id && left.m_code == right.m_code;
		}

		public static bool operator !=(ObjectIdentifier left, ObjectIdentifier right)
		{
			return left.m_id != right.m_id || left.m_code != right.m_code;
		}
	}
}
