using System;
using System.Data;
using System.Data.Common;

namespace DomainCommonSE.DbCommon
{
	public interface IDbCommonDataReader : IDisposable
	{
		bool Read();
		void Close();
		bool IsDBNull(int index);
		int GetOrdinal(string name);
		object GetValue(int index);
		object GetValue(int index, Type dataType);
		T GetValue<T>(int index);
	}

	public abstract class DbCommonDataReader<TDataReader> : IDbCommonDataReader
		where TDataReader : DbDataReader
	{		
		static protected Type StringType = typeof(String);		
		static protected Type BooleanType = typeof(Boolean);
		static protected Type ObjectType = typeof(Object);
		
		static protected Type Int16Type = typeof(Int16);
		static protected Type Int32Type = typeof(Int32);
		static protected Type Int64Type = typeof(Int64);

		static protected Type UInt16Type = typeof(UInt16);
		static protected Type UInt32Type = typeof(UInt32);
		static protected Type UInt64Type = typeof(UInt64);			

		protected TDataReader m_reader;

		public DbCommonDataReader(TDataReader reader)
		{
			m_reader = reader;
		}

		public bool Read()
		{
			return m_reader.Read();
		}

		public void Close()
		{
			m_reader.Close();
		}

		public bool IsDBNull(int index)
		{
			return m_reader.IsDBNull(index);
		}

		public int GetOrdinal(string name)
		{
			return m_reader.GetOrdinal(name);
		}

		private object GetDefaultValue(Type dataType)
		{
			if (dataType == Int32Type)
				return new Int32();

			if (dataType == StringType)
				return String.Empty;

			if (dataType == Int64Type)
				return new Int64();

			if (dataType == BooleanType)
				return new Boolean();

			if (dataType == ObjectType)
				return null;

			if (dataType == Int16Type)
				return new Int16();

			if (dataType == UInt32Type)
				return new UInt32();

			if (dataType == UInt64Type)
				return new UInt64();

			if (dataType == UInt16Type)
				return new UInt16();

			return GetCustomDefaultValue(dataType);
		}

		protected virtual object GetCustomDefaultValue(Type dataType)
		{
			return null;
		}
		
		protected abstract object GetValueInternal(int index, Type dataType);
		public object GetValue(int index, Type dataType)
		{
			if (IsDBNull(index))
			{
				return GetDefaultValue(dataType);				
			}

			return GetValueInternal(index, dataType);
		}

		public object GetValue(int index)
		{
			return m_reader.GetValue(index);
		}

		public T GetValue<T>(int index)
		{
			return (T)GetValue(index, typeof(T));						
		}

		public void Dispose()
		{
			if (m_reader != null)
				m_reader.Dispose();
		}
	}
}
