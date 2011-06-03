using System;
using DevExpress.XtraEditors;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class SQLQueryControl : XtraUserControl
	{
		DomainObjectInquiry m_inquiry;

		Document m_doc;
		Document Doc
		{
			get
			{
				throw new NotImplementedException();
				//if (m_doc == null)
				//    m_doc = m_inquiry.OpenDocument();

				//return m_doc;
			}
		}

		public string Sql
		{
			get
			{
				return txtSql.TextValue;
			}
			set
			{
				txtSql.TextValue = value;
			}
		}

		public SQLQueryControl()
		{
			InitializeComponent();
		}

		public void Init(DomainObjectInquiry inquiry)
		{
			m_inquiry = inquiry;
		}

		public void ExecuteQuery()
		{
			throw new NotImplementedException();
			//DbCommonCommand command = m_inquiry.DbManager.CreateCommand(Doc.Session, Sql);
			//gridResult.DataSource = command.ExecuteTable();		
		}

		public void Commit()
		{
			throw new NotImplementedException();
			//m_inquiry.DbManager.Connection.Commit(Doc.Session);
		}

		public void Rollback()
		{
			throw new NotImplementedException();
			//m_inquiry.DbManager.Connection.RollBack(Doc.Session);
		}

		public SQLQueryControl(string sql)
			: this()
		{
			txtSql.TextValue = sql;
		}
	}
}
