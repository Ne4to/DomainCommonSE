using System;
using System.Collections.Generic;
using System.Text;
using DomainCommonSE;
using DomainCommonSE.Properties;

namespace DomainCommonSE.DbCommon
{
	public class DbCommonManager : IDisposable
	{
		public IDbCommonConnection Connection { get; private set; }

		/// <summary>
		/// Код комманды по получению системной даты
		/// </summary>
		protected const string STR_SYSDATE = "SYSDATE";
		/// <summary>
		/// Комманды к БД
		/// </summary>
		private Dictionary<SessionIdentifier, Dictionary<string, DbCommonCommand>> m_dbCommand;

		DbCommonCommand m_sysDateCommand;
		/// <summary>
		/// Системная дата
		/// </summary>
		public DateTime SysDate
		{
			get
			{
				return (DateTime)m_sysDateCommand.ExecuteScalar(SessionIdentifier.SHARED_SESSION);
			}
		}

		public DbCommonManager(IDbCommonConnection connection)
		{
			Connection = connection;
			m_dbCommand = new Dictionary<SessionIdentifier, Dictionary<string, DbCommonCommand>>();
			PrepareSysDateCommand();
		}

		/// <summary>
		/// Подготовить комманду по получению системной даты
		/// </summary>
		private void PrepareSysDateCommand()
		{
			m_sysDateCommand = new DbCommonCommand(Connection.SysDateCommand, Connection);			
		}

		#region IDisposable Members

		public void Dispose()
		{
			Connection.Dispose();
		}

		#endregion
	}
}
