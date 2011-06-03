using System;
using System.IO;
using System.Data.SqlServerCe;
using DomainCommonSE.DbCommon;
using System.Runtime.Serialization.Formatters.Binary;

namespace DomainCommonSE.MsSqlCe40
{
	public class DbCommonMsSqlCe40DataReader : DbCommonDataReader<SqlCeDataReader>
	{
		static protected Type timeSpanType = typeof(TimeSpan);

		internal DbCommonMsSqlCe40DataReader(SqlCeDataReader reader)
			: base(reader)
		{
		}

		protected override object GetValueInternal(int index, Type dataType)
		{
			if (dataType == ObjectType)
			{
				using (MemoryStream stream = new MemoryStream(m_reader.GetSqlBinary(index).Value))
				{
					BinaryFormatter bin = new BinaryFormatter();
					return bin.Deserialize(stream);
				}
			}

			if (dataType == BooleanType)
			{
				return m_reader.GetDataTypeName(index) == "Bit" ? m_reader.GetBoolean(index) : m_reader.GetInt32(index) == 1;
			}

			if (dataType == timeSpanType)
			{
				return TimeSpan.FromMilliseconds(Convert.ToInt64(m_reader.GetValue(index)));
			}

			return m_reader.GetValue(index);
		}
	}
}
