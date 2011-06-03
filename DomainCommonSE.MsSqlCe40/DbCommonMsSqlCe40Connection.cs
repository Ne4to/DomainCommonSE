using System;
using System.Text;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.Data;
using System.IO;

using DomainCommonSE;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.MsSqlCe40
{
	public class DbCommonMsSqlCe40Connection : DbCommonConnection<SqlCeConnection, SqlCeTransaction>
	{
		public override bool SupportBatchQueries
		{
			get { return false; }
		}

		public DbCommonMsSqlCe40Connection(string connectionString)
			: base(connectionString)
		{
		}

		public DbCommonMsSqlCe40Connection(string fileName, string password, int locale)
			: this(GetConnectionString(fileName, password, locale))
		{
		}

		public override DataAdapter GetDataAdapter(SessionIdentifier sid, string sql)
		{
			return new SqlCeDataAdapter(sql, GetConnection(sid));
		}

		public override DbCommand GetSqlCommand(SessionIdentifier sid, string sql)
		{
			return new SqlCeCommand(sql, GetConnection(sid), GetTransaction(sid));
		}

		public override IDbCommonDataReader GetSqlDataReader(DbDataReader reader)
		{
			return new DbCommonMsSqlCe40DataReader((SqlCeDataReader)reader);
		}

		public override string SysDateCommand
		{
			get { return "SELECT GETDATE()"; }
		}

		const string deploySequenceScheme = @"
CREATE TABLE [ORM_CONFIG_SEQUENCE]
(
	[LAST_VALUE] [BIGINT] DEFAULT(0) NOT NULL
){;}

INSERT INTO ORM_CONFIG_SEQUENCE (LAST_VALUE) VALUES (1){;}
";

		public override void DeployORMSequenceScheme()
		{
			DeployORMScheme(deploySequenceScheme);
		}

		const string deployInquiryScript = @"
CREATE TABLE [ORM_CONFIG_OBJECT](
	[ID_ORM_CONFIG_OBJECT] [BIGINT] NOT NULL,
	[CODE] [NVARCHAR](50) NOT NULL,
	[DESCRIPTION] [NVARCHAR](200) NOT NULL,
	[TABLE_NAME] [NVARCHAR](50) NOT NULL,	
	[CODE_NAME] [NVARCHAR](50) NOT NULL,
	[ID_FIELD] [NVARCHAR](50) NOT NULL
){;}

CREATE TABLE [ORM_CONFIG_PROPERTY](
	[ID_ORM_CONFIG_PROPERTY] [BIGINT] NOT NULL,
	[CODE] [NVARCHAR](50) NOT NULL,
	[DESCRIPTION] [NVARCHAR](200) NOT NULL,
	[ID_ORM_CONFIG_OBJECT] [BIGINT] NOT NULL,
	[DATA_TYPE] [NVARCHAR](100) NOT NULL,
	[ASSEMBLY_FILE] [NVARCHAR](100) NOT NULL,
	[DEFAULT_VALUE] [VARBINARY](8000) NULL,
	[FIELD_NAME] [NVARCHAR](50) NOT NULL,
	[FIELD_LENGTH] [INT] NOT NULL,	
	[CODE_NAME] [NVARCHAR](50) NOT NULL
){;}

CREATE TABLE [ORM_CONFIG_LINK](
	[ID_ORM_CONFIG_LINK] [BIGINT] NOT NULL,
	[CODE] [NVARCHAR](50) NOT NULL,
	[LEFT_RELATION] [INT] NOT NULL,
	[RIGHT_RELATION] [INT] NOT NULL,
	[ID_LEFT_OBJECT] [BIGINT] NOT NULL,
	[ID_RIGHT_OBJECT] [BIGINT] NOT NULL,
	[LINK_TABLE_NAME] [NVARCHAR](50) NOT NULL,
	[LEFT_ID_FIELD] [NVARCHAR](50) NOT NULL,
	[RIGHT_ID_FIELD] [NVARCHAR](50) NOT NULL,
	[IS_LEFT_TO_RIGHT_ACTIVE] [BIT] NULL,
	[IS_RIGHT_TO_LEFT_ACTIVE] [BIT] NULL,
	[LEFT_TO_RIGHT_DESCRIPTION] [NVARCHAR](200) NULL,
	[RIGHT_TO_LEFT_DESCRIPTION] [NVARCHAR](200) NULL,
	[LEFT_COLLECTION_NAME] [NVARCHAR](50) NULL,
	[RIGHT_COLLECTION_NAME] [NVARCHAR](50) NULL
){;}

CREATE TABLE [ORM_CONFIG_QUERY](
	[ID_ORM_CONFIG_QUERY] [BIGINT] NOT NULL,
	[CODE] [NVARCHAR](50) NOT NULL,
	[OBJECT_TYPE] [NVARCHAR](200) NOT NULL,
	[SOURCE] [VARBINARY](8000) NOT NULL,
	[NOTES] [NVARCHAR](400) NOT NULL,
	[REMOVED] [BIT] NOT NULL
){;}
";

		public override void DeployORMInquiryScheme()
		{
			DeployORMScheme(deployInquiryScript);
		}

		private void DeployORMScheme(string sql)
		{
			SqlCeConnectionStringBuilder sb = new SqlCeConnectionStringBuilder(m_connectionString);
			if (!File.Exists(sb.DataSource))
			{
				using (SqlCeEngine engine = new SqlCeEngine(m_connectionString))
				{
					engine.CreateDatabase();
				}
			}

			using (DbCommonMsSqlCe40Connection connection = new DbCommonMsSqlCe40Connection(m_connectionString))
			{
				DbCommonManager dbManager = new DbCommonManager(connection);
				DbCommonCommand command = new DbCommonCommand(sql, connection);
				command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);

				dbManager.Connection.Commit(SessionIdentifier.SHARED_SESSION);
				connection.CloseConnection();
			}
		}

		public override void CreateTable(string tableName, string idField)
		{
			StringBuilder sql = new StringBuilder();

			sql.AppendFormat("CREATE TABLE {0} ({1} bigint NOT NULL){2}", tableName, idField, DbCommonCommand.BatchCommandSeparatorKey);
			sql.AppendFormat("ALTER TABLE {0} ADD CONSTRAINT PK_{0} PRIMARY KEY ({1}){2}", tableName, idField, DbCommonCommand.BatchCommandSeparatorKey);

			DbCommonCommand command = new DbCommonCommand(sql.ToString(), this);
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void RemoveTable(string tableName)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat("DROP TABLE {0}{1}", tableName, DbCommonCommand.BatchCommandSeparatorKey);

			DbCommonCommand command = new DbCommonCommand(sql.ToString(), this);
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void CreateLinkTable(string tableName, string leftObjectIdField, string rightObjectIdField)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat("CREATE TABLE {0} ({1} bigint NOT NULL, {2} bigint NOT NULL){3}", tableName, leftObjectIdField, rightObjectIdField, DbCommonCommand.BatchCommandSeparatorKey);

			DbCommonCommand command = new DbCommonCommand(sql.ToString(), this);
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void AddTableField(string tableName, string fieldName, Type dataType, int length = 0, object defaultValue = null, bool allowNull = true)
		{
			StringBuilder sql = new StringBuilder();

			if (defaultValue == null && allowNull == false)
				throw new ArgumentException("need recreate table");

			if (defaultValue != null && allowNull == false)
			{
				sql.AppendFormat("ALTER TABLE {0} ADD {1} {2} NOT NULL CONSTRAINT DF_{0}_{1} DEFAULT {3}{4}", tableName, fieldName, GetTypeString(dataType, length), GetTypeValue(defaultValue), DbCommonCommand.BatchCommandSeparatorKey);
			}
			else
			{
				sql.AppendFormat("ALTER TABLE {0} ADD {1} {2} {3}{4}", tableName, fieldName, GetTypeString(dataType, length), allowNull ? "NULL" : "NOT NULL", DbCommonCommand.BatchCommandSeparatorKey);

				if (defaultValue != null)
					sql.AppendFormat("ALTER TABLE {0} ADD CONSTRAINT DF_{0}_{1} DEFAULT {2} FOR {1}{3}", tableName, fieldName, GetTypeValue(defaultValue), DbCommonCommand.BatchCommandSeparatorKey);
			}

			DbCommonCommand command = new DbCommonCommand(sql.ToString(), this);
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override void RemoveTableField(string tableName, string fieldName)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat("ALTER TABLE {0} DROP COLUMN {1}{2}", tableName, fieldName, DbCommonCommand.BatchCommandSeparatorKey);

			DbCommonCommand command = new DbCommonCommand(sql.ToString(), this);
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);
		}

		public override string GetTypeString(Type dataType, int length)
		{
			if (dataType == typeof(String)) return String.Format("NVARCHAR({0})", length);
			if (dataType == typeof(Int32)) return "INT";
			if (dataType == typeof(Int64)) return "BIGINT";
			if (dataType == typeof(Double)) return "FLOAT";
			if (dataType == typeof(DateTime)) return "DATETIME";
			if (dataType == typeof(Boolean)) return "BIT";
			if (dataType == typeof(Decimal)) return "MONEY";
			if (dataType == typeof(TimeSpan)) return "BIGINT"; //bigint
			if (dataType == typeof(Int16)) return "SMALLINT";
			if (dataType == typeof(Single)) return "REAL";
			if (dataType == typeof(Guid)) return "UNIQUEIDENTIFIER";
			if (dataType == typeof(Object)) return "VARBINARY(8000)";

			//VARBINARY(MAX)

			throw new DomainException(String.Format("Тип данных {0} не поддерживается для этого профиля базы данных", dataType));
		}

		public override string GetTypeValue(object value)
		{
			if (value == null)
				return "NULL";

			Type dataType = value.GetType();
			if (dataType == typeof(String)) return String.Format("N\'{0}\'", value.ToString().Replace("'", "''"));
			if (dataType == typeof(Int32)) return value.ToString();
			if (dataType == typeof(Int64)) return value.ToString();
			if (dataType == typeof(Double)) return ((Double)value).ToString(NumberFormat);
			if (dataType == typeof(DateTime)) return String.Format("CONVERT(datetime, \'{0:yyyy-MM-dd HH:mm:ss}\', 120)", value);
			if (dataType == typeof(Boolean)) return (bool)value ? "1" : "0";
			if (dataType == typeof(Decimal)) return ((decimal)value).ToString(NumberFormat);
			if (dataType == typeof(TimeSpan)) return ((TimeSpan)value).TotalMilliseconds.ToString("f0");
			if (dataType == typeof(Int16)) return value.ToString();
			if (dataType == typeof(Single)) return ((float)value).ToString(NumberFormat);

			throw new DomainException(String.Format("Тип данных {0} не поддерживается для этого профиля базы данных", dataType));
		}

		public override string GetObjectValue(object value)
		{
			return String.Format("0x{0}", BitConverter.ToString(getByteArrayWithObject(value)).Replace("-", String.Empty));
		}

		protected override void LoadSequenceData()
		{
			string sql = "SELECT LAST_VALUE FROM ORM_CONFIG_SEQUENCE";
			DbCommonCommand command = new DbCommonCommand(sql, this);

			long firstValue = (long)command.ExecuteScalar(SessionIdentifier.SHARED_SESSION);
			for (long value = firstValue; value < firstValue + SequenceRate; value++)
			{
				m_sequenceStore.Add(value);
			}

			sql = String.Format("UPDATE ORM_CONFIG_SEQUENCE SET LAST_VALUE = LAST_VALUE + {0}", SequenceRate);
			command = new DbCommonCommand(sql, this);
			command.ExecuteNonQuery(SessionIdentifier.SHARED_SESSION);

			Commit(SessionIdentifier.SHARED_SESSION);
		}

		public static string GetConnectionString(string fileName, string password, int locale)
		{
			return String.Format("Persist Security Info=False; Encrypt database=True; Data Source={0}; Password={1}; Locale identifier={2}", fileName, password, locale);
		}

		//public static void DeployDataBase(string fileName, string password, int locale)
		//{
		//    string connectionString = GetConnectionString(fileName, password, locale);

		//    using (SqlCeEngine engine = new SqlCeEngine(connectionString))
		//    {
		//        engine.CreateDatabase();
		//    }

		//    using (DbCommonMsSqlCe35Connection connection = new DbCommonMsSqlCe35Connection(connectionString))
		//    {
		//        string sql = Settings.Default.DeploySqlScript;
		//        DbCommonManager dbManager = new DbCommonManager(connection);
		//        DbCommonCommand command = dbManager.CreateCommand(SessionIdentifier.SHARED_SESSION, sql);
		//        command.ExecuteNonQuery();

		//        dbManager.Connection.Commit(SessionIdentifier.SHARED_SESSION);
		//        connection.CloseConnection();
		//    }
		//}

		protected override SqlCeConnection CreateConnection()
		{
			SqlCeConnection result = new SqlCeConnection(m_connectionString);
			result.Open();

			return result;
		}

		public override string PrepareBatchQuery(List<string> sqlList)
		{
			throw new NotSupportedException();
		}

		protected override void InitAvailableDataType()
		{
			m_availableDataType.Add(typeof(String));
			m_availableDataType.Add(typeof(Int32));
			m_availableDataType.Add(typeof(Int64));
			m_availableDataType.Add(typeof(Double));
			m_availableDataType.Add(typeof(DateTime));
			m_availableDataType.Add(typeof(Boolean));
			m_availableDataType.Add(typeof(Decimal));
			m_availableDataType.Add(typeof(TimeSpan));
			m_availableDataType.Add(typeof(Int16));
			m_availableDataType.Add(typeof(Single));
		}

		const string getSchemeSql = @"SELECT C.TABLE_NAME, C.COLUMN_NAME, C.DATA_TYPE
FROM INFORMATION_SCHEMA.TABLES T, INFORMATION_SCHEMA.COLUMNS C 
WHERE T.TABLE_TYPE = 'TABLE' AND T.TABLE_NAME = C.TABLE_NAME
ORDER BY C.TABLE_NAME, C.COLUMN_NAME";

		public override void RefreshScheme()
		{
			m_scheme = new DbCommonScheme();

			DbCommonCommand command = new DbCommonCommand(getSchemeSql, this);
			DataTable resultTable = command.ExecuteTable(SessionIdentifier.SHARED_SESSION);

			Dictionary<string, DbCommonSchemeTable> tables = new Dictionary<string, DbCommonSchemeTable>();
			foreach (DataRow row in resultTable.Rows)
			{
				string tableName = row["TABLE_NAME"].ToString();
				string fieldName = row["COLUMN_NAME"].ToString();
				string dataType = row["DATA_TYPE"].ToString();

				DbCommonSchemeTable table = null;
				if (!tables.TryGetValue(tableName, out table))
				{
					table = new DbCommonSchemeTable(tableName);
					tables.Add(tableName, table);
					m_scheme.AddTable(table);
				}

				table.AddField(new DbCommonSchemeTableField(fieldName, dataType));
			}
		}
	}
}
