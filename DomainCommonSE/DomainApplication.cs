using System;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE
{
	public class DomainApplication : IDisposable
	{
		readonly DomainObjectInquiry m_inquiry;
		readonly IDbCommonConnection m_connection;
		readonly DocumentManager m_documentManager;
		readonly DomainObjectManager m_objManager;

		public DbCommonManager DbManager { get; private set; }

		public DomainApplication(DomainObjectInquiry inquiry, IDbCommonConnection connection, DomainObjectFactory objFactory)
		{
			if (inquiry == null)
				throw new ArgumentNullException("inquiry");

			m_inquiry = inquiry;

			if (connection == null)
				throw new ArgumentNullException("connection");

			m_connection = connection;

			m_documentManager = new DocumentManager(m_inquiry);
			m_objManager = new DomainObjectManager(m_inquiry, connection, objFactory);

			DbManager = new DbCommonManager(m_connection);			
		}

		public Document OpenDocument()
		{
			return m_documentManager.OpenDocument();
		}

		#region IDisposable Members

		public void Dispose()
		{
			DbManager.Dispose();
		}

		#endregion
	}
}
