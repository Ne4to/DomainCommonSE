using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Globalization;
using System.Data.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace DomainCommonSE.DbCommon
{
	public interface IDbCommonConnection : IDisposable
	{
		/// <summary>
		/// Подключение поддерживает пакетные запросы идущие через точку с запятой
		/// </summary>
		bool SupportBatchQueries { get; }
		string SysDateCommand { get; }

		long NewSequence();

		DbCommand GetSqlCommand(SessionIdentifier sid, string sql);
		void AddDeferredQuery(SessionIdentifier sid, string sql);
		string PrepareBatchQuery(List<string> sqlList);
		IDbCommonDataReader GetSqlDataReader(DbDataReader reader);
		DataAdapter GetDataAdapter(SessionIdentifier sid, string sql);

		void DeployORMSequenceScheme();
		void DeployORMInquiryScheme();

		void CreateTable(string tableName, string idField);
		void RemoveTable(string tableName);
		void CreateLinkTable(string tableName, string leftObjectIdField, string rightObjectIdField);
		void AddTableField(string tableName, string fieldName, Type dataType, int length = 0, object defaultValue = null, bool allowNull = true);
		void RemoveTableField(string tableName, string fieldName);

		Type[] GetAvailableDataType();
		string GetReadTypeString(Type dataType, string fieldName);
		string GetTypeString(Type dataType, int length);
		string GetTypeValue(object value);
		string GetObjectValue(object value);

		void CloseConnection();
		void Commit(SessionIdentifier sid);
		void RollBack(SessionIdentifier sid);
		string GetTypeValueList(IEnumerable values);
		DataTable ExecuteTable(SessionIdentifier sid, string sql);

		DbCommonScheme Scheme { get; }
		void RefreshScheme();
	}

	/// <summary>
	/// Подключение к БД
	/// </summary>
	public abstract class DbCommonConnection<TConnection, TTransaction> : IDbCommonConnection
		where TConnection : DbConnection
		where TTransaction : DbTransaction
	{
		protected string m_connectionString;
		protected List<Type> m_availableDataType;
		/// <summary>
		/// Транзакции к БД
		/// </summary>
		private Dictionary<SessionIdentifier, TTransaction> m_transaction;
		private Dictionary<SessionIdentifier, TConnection> m_connection;

		public abstract bool SupportBatchQueries { get; }
			 
		public int SequenceRate { get; set; }

		private static NumberFormatInfo m_numberFormat;
		/// <summary>
		/// Формат чисел для комманд
		/// </summary>
		public static NumberFormatInfo NumberFormat
		{
			get
			{
				if (m_numberFormat == null)
				{
					m_numberFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
					m_numberFormat.CurrencyDecimalSeparator = ".";
					m_numberFormat.NumberDecimalSeparator = ".";
				}

				return m_numberFormat;				
			}
		}

		protected DbCommonScheme m_scheme;
		public DbCommonScheme Scheme
		{
			get
			{
				if (m_scheme == null)
					RefreshScheme();

				return m_scheme;
			}
		}

		public abstract void RefreshScheme();

		public abstract void DeployORMSequenceScheme();
		public abstract void DeployORMInquiryScheme();
		protected abstract void InitAvailableDataType();
		public abstract string SysDateCommand { get; }
		protected abstract TConnection CreateConnection();
		public abstract DbCommand GetSqlCommand(SessionIdentifier sid, string sql);
		public abstract string PrepareBatchQuery(List<string> sqlList);
		public abstract IDbCommonDataReader GetSqlDataReader(DbDataReader reader);
		public abstract DataAdapter GetDataAdapter(SessionIdentifier sid, string sql);

		public abstract void CreateTable(string tableName, string idField);
		public abstract void RemoveTable(string tableName);
		public abstract void CreateLinkTable(string tableName, string leftObjectIdField, string rightObjectIdField);
		public abstract void AddTableField(string tableName, string fieldName, Type dataType, int length = 0, object defaultValue = null, bool allowNull = true);
		public abstract void RemoveTableField(string tableName, string fieldName);

		public Type[] GetAvailableDataType()
		{
			return m_availableDataType.ToArray();
		}

		public virtual string GetReadTypeString(Type dataType, string fieldName)
		{
			return fieldName;
		}

		public abstract string GetTypeString(Type dataType, int length);
		public abstract string GetTypeValue(object value);
		public abstract string GetObjectValue(object value);

		protected List<long> m_sequenceStore;
		protected abstract void LoadSequenceData();
		public long NewSequence()
		{
			long newId = -1;

			lock (m_sequenceStore)
			{
				if (m_sequenceStore.Count == 0)
				{
					LoadSequenceData();
				}

				newId = m_sequenceStore[0];
				m_sequenceStore.RemoveAt(0);
			}

			return newId;
		}

		protected DbCommonConnection(string connectionString)
		{
			SequenceRate = 20;
			m_connectionString = connectionString;
			m_sequenceStore = new List<long>();
			m_transaction = new Dictionary<SessionIdentifier, TTransaction>();
			m_connection = new Dictionary<SessionIdentifier, TConnection>();

			m_deferredSql = new Dictionary<SessionIdentifier,List<string>>();

			m_availableDataType = new List<Type>();
			InitAvailableDataType();
		}

		public void Dispose()
		{
			CloseConnection();
		}

		protected TConnection GetConnection(SessionIdentifier sid)
		{
			//lock (m_connection)
			{
				if (!m_connection.ContainsKey(sid))
					m_connection.Add(sid, CreateConnection());
			}

			return m_connection[sid];
		}
		/// <summary>
		/// Используемая транзакция
		/// </summary>
		public TTransaction GetTransaction(SessionIdentifier sid)
		{
			//lock (m_transaction)
			{
				if (!m_transaction.ContainsKey(sid) || m_transaction[sid] == null)
				{
					m_transaction[sid] = (TTransaction)GetConnection(sid).BeginTransaction();
				}
			}

			return m_transaction[sid];
		}

		/// <summary>
		/// Закрыть подключение к БД
		/// </summary>
		public void CloseConnection()
		{
			foreach (SessionIdentifier sid in m_transaction.Keys)
			{
				if (m_transaction[sid] != null)
					m_transaction[sid].Rollback();
			}

			foreach (var conn in m_connection.Values)
				conn.Close();
		}
		/// <summary>
		/// Записать последние изменения в БД
		/// </summary>
		public void Commit(SessionIdentifier sid)
		{
			//lock (m_transaction)
			{
				ExecuteDefferedQuery(sid);

				if (m_transaction.ContainsKey(sid) && m_transaction[sid] != null)
				{
					m_transaction[sid].Commit();
					m_transaction[sid] = null;
				}
			}
		}
		/// <summary>
		/// Откатить последние изменения БД
		/// </summary>
		public void RollBack(SessionIdentifier sid)
		{
			//lock (m_transaction)
			{
				if (m_transaction.ContainsKey(sid) && m_transaction[sid] != null)
				{
					ClearDefferedQuery(sid);

					m_transaction[sid].Rollback();
					m_transaction[sid] = null;
				}
			}
		}

		protected static byte[] getByteArrayWithObject(Object value)
		{
			MemoryStream ms = new MemoryStream();
			BinaryFormatter bf1 = new BinaryFormatter();
			bf1.Serialize(ms, value);
			return ms.ToArray();
		}

		public virtual DataTable ExecuteTable(SessionIdentifier sid, string sql)
		{
			DataSet ds = new DataSet();
			DataAdapter da = GetDataAdapter(sid, sql);

			da.Fill(ds);
			return ds.Tables.Count == 0 ? new DataTable() : ds.Tables[0];
		}

		public string GetTypeValueList(IEnumerable values)
		{
			StringBuilder result = new StringBuilder();

			bool flag = false;
			foreach (object obj in values)
			{
				if (flag) result.Append(", ");
				result.Append(GetTypeValue(obj));
				flag = true;
			}

			return result.ToString();
		}

		private void ExecuteDefferedQuery(SessionIdentifier session)
		{
			List<string> sqlList = GetDefferedList(session, false);

			if (sqlList == null || sqlList.Count == 0)
				return;
			
			if (SupportBatchQueries)
			{
				CustomDeferredExecution(session, sqlList);
			}
			else
			{
				foreach (string sql in sqlList)
				{
					DbCommand command = GetSqlCommand(session, sql);
					command.ExecuteNonQuery();
				}
			}

			sqlList.Clear();
		}

		private void ClearDefferedQuery(SessionIdentifier session)
		{
			List<string> sqlList = GetDefferedList(session, false);

			if (sqlList != null)
				sqlList.Clear();
		}

		protected virtual void CustomDeferredExecution(SessionIdentifier session, IEnumerable<string> deferredSql)
		{
			StringBuilder resultSql = new StringBuilder("BEGIN\r\n");
			
			foreach (string sql in deferredSql)
			{
				resultSql.AppendFormat("{0};\r\n", sql);
			}
			
			resultSql.Append("END");

			DbCommand command = GetSqlCommand(session, resultSql.ToString());
			command.ExecuteNonQuery();
		}

		private Dictionary<SessionIdentifier, List<string>> m_deferredSql;

		private List<string> GetDefferedList(SessionIdentifier sessionId, bool createIfNotExist = true)
		{
			List<string> sqlList = null;
			
			if (!m_deferredSql.TryGetValue(sessionId, out sqlList) && createIfNotExist)
			{
				sqlList = new List<string>();
				m_deferredSql.Add(sessionId, sqlList);
			}

			return sqlList;
		}

		public void AddDeferredQuery(SessionIdentifier sessionId, string sql)
		{
			if (String.IsNullOrWhiteSpace(sql))
				return;

			List<string> sqlList = GetDefferedList(sessionId);
			sqlList.Add(sql);
		}
	}


	public interface IDbCommonConnectionConnectControl
	{
		ConnectionLoginData GetLoginData();
		void SetLoginData(ConnectionLoginData loginData);
		IDbCommonConnection GetConnection();
	}

	public interface IDbCommonConnectionPlugin
	{
		string ConnectionName { get; }
		Type ControlType { get; }
		Type ConnectionType { get; }
		Type LoginDataType { get; }
	}

	public abstract class DbCommonConnectionPlugin : IDbCommonConnectionPlugin
	{
		public override string ToString()
		{
			return ConnectionName;
		}

		public abstract string ConnectionName { get; }
		public abstract Type ControlType { get; }
		public abstract Type ConnectionType { get; }
		public abstract Type LoginDataType { get; }
	}

	public interface IEditValueControl
	{
		object EditValue { get; set; }
	}

	public class ConnectionLoginData
	{
		public string ConnectionName { get; set; }

		public override string ToString()
		{
			return ConnectionName;
		}
	}
}