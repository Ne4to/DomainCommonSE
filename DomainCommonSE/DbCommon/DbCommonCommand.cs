using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DomainCommonSE.Properties;
using System.Collections;

namespace DomainCommonSE.DbCommon
{
	/// <summary>
	/// SQL комманда
	/// </summary>
	public class DbCommonCommand
	{
		public IDbCommonConnection Connection { get; set; }
		/// <summary>
		/// Ключевое слово - разделитель SQL комманд
		/// </summary>
		public const string BatchCommandSeparatorKey = "{;}";
		/// <summary>
		/// Исходный текст запроса
		/// </summary>
		public string BaseSql { get; protected set; }

		protected Dictionary<string, DbCommonCommandParameter> m_parameter = new Dictionary<string, DbCommonCommandParameter>();

		/// <summary>
		/// Параметры
		/// </summary>
		/// <param name="code">Код параметра</param>
		/// <returns></returns>
		public DbCommonCommandParameter this[string code]
		{
			get
			{
				if (!m_parameter.ContainsKey(code))
					throw new DomainException(String.Format(Resources.DbCommonParameterNotFound, code));

				return m_parameter[code];
			}
		}

		/// <summary>
		/// Количество параметров
		/// </summary>
		public int ParameterCount
		{
			get
			{
				return m_parameter.Count;
			}
		}

		public DbCommonCommand(string sql, IDbCommonConnection connection = null)
		{
			BaseSql = sql;
			Connection = connection;
		}

		private void CheckConnection()
		{
			if (Connection == null)				
				throw new Exception("параметр Connection не установлен");
		}

		/// <summary>
		/// Добавить параметер
		/// </summary>
		/// <param name="code">Код параметра</param>
		/// <param name="dataType">Тип данных</param>
		/// <param name="isCollection">Параметер является коллекцией</param>
		/// <param name="value">Значение параметра</param>
		/// <returns>Добавленный параметер</returns>
		public DbCommonCommandParameter AddParameter(string code, Type dataType, bool isCollection = false, object value = null)
		{
			if (m_parameter.ContainsKey(code))
				throw new DomainException(String.Format(Resources.DbCommonParameterAlreadyExists, code));

			DbCommonCommandParameter newParameter = new DbCommonCommandParameter(code, dataType, value, isCollection);
			m_parameter.Add(code, newParameter);

			return newParameter;
		}

		public virtual string GetPreparedSql()
		{
			StringBuilder sql = new StringBuilder(BaseSql);
			foreach (DbCommonCommandParameter param in m_parameter.Values)
			{
				string paramValue;

				if (param.Value == null)
				{
					if (param.AllowNull)
					{
						paramValue = "NULL";
					}
					else
						throw new DomainException(String.Format(Resources.DbCommonParameterValueNotAssigned, param.Code));
				}
				else
				{
					if (param.DataType == typeof(object))
					{
						paramValue = Connection.GetObjectValue(param.Value);
					}
					else
					{
						if (param.IsCollection)
							paramValue = Connection.GetTypeValueList(param.Value as IEnumerable);
						else
							paramValue = Connection.GetTypeValue(param.Value);
					}
				}

				sql.Replace(String.Format("@{{{0}}}", param.Code), paramValue);
			}

			return sql.ToString();
		}

		private List<string> GetQueryList()
		{
			List<string> list = new List<string>();

			foreach (string sql in GetPreparedSql().Split(new string[] { BatchCommandSeparatorKey }, StringSplitOptions.RemoveEmptyEntries))
			{
				string trimSql = sql.Trim();
				if (trimSql.Length > 0)
					list.Add(trimSql);
			}

			return list;
		}

		public virtual int ExecuteNonQuery(SessionIdentifier session, bool allowDeferredExecution = false)
		{
			CheckConnection();

			if (Connection.SupportBatchQueries)
			{
				string sql = GetPreparedSql();

				if (allowDeferredExecution)
				{
					return ExecuteNonQuery(session, sql, allowDeferredExecution);					
				}

				return ExecuteNonQuery(session, sql);
			}
			else
			{
				List<string> sqlList = GetQueryList();

				if (sqlList.Count == 0)
					throw new DomainException(Resources.CanNotExecuteEmptyQuery);

				int lastResult = -1;

				foreach (string currentQuery in sqlList)
				{
					lastResult = ExecuteNonQuery(session, currentQuery, allowDeferredExecution);
				}

				return lastResult;
			}
		}

		public Object ExecuteScalar(SessionIdentifier session)
		{
			CheckConnection();

			if (Connection.SupportBatchQueries)
			{
				string sql = GetPreparedSql();
				return ExecuteScalar(session, sql);
			}
			else
			{
				List<string> sqlList = GetQueryList();

				if (sqlList.Count == 0)
					throw new DomainException(Resources.CanNotExecuteEmptyQuery);

				object lastResult = null;

				foreach (string currentQuery in sqlList)
				{
					lastResult = ExecuteScalar(session, currentQuery);
				}

				return lastResult;
			}
		}

		public DataTable ExecuteTable(SessionIdentifier session)
		{
			CheckConnection();

			return Connection.ExecuteTable(session, GetPreparedSql());
		}

		protected int ExecuteNonQuery(SessionIdentifier session, string sql, bool allowDeferredExecution = false)
		{
			if (allowDeferredExecution)
			{
				Connection.AddDeferredQuery(session, sql);
				return -1;
			}
			else
			{
				DbCommand dbCommand = Connection.GetSqlCommand(session, sql);
				return dbCommand.ExecuteNonQuery();
			}
		}

		protected Object ExecuteScalar(SessionIdentifier session, string sql)
		{
			DbCommand dbCommand = Connection.GetSqlCommand(session, sql);
			return dbCommand.ExecuteScalar();
		}

		public IDbCommonDataReader ExecuteReader(SessionIdentifier session)
		{
			CheckConnection();

			DbCommand dbCommand = Connection.GetSqlCommand(session, GetPreparedSql());
			DbDataReader dbReader = dbCommand.ExecuteReader();
			return Connection.GetSqlDataReader(dbReader);
		}
	}
}
