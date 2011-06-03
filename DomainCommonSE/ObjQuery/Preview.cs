using System;
using System.Data;
using DomainCommonSE.Domain;

namespace DomainCommonSE.ObjQuery
{
	public class Preview
	{
		public SessionIdentifier Session { get; private set; }
		public string ObjectCode { get; private set; }

		public PreviewRowCollection Rows { get; private set; }
		public PreviewRow this[int index]
		{
			get
			{
				return Rows[index];
			}
		}

		public int Count
		{
			get
			{
				return Rows.Count;
			}
		}

		internal Preview(SessionIdentifier session, string objectCode, DataTable table)
		{
			Session = session;
			ObjectCode = objectCode;

			Rows = new PreviewRowCollection(table.Rows.Count);
			foreach (DataRow row in table.Rows)
			{
				Rows.AddRow(new PreviewRow(ObjectCode, row));
			}
		}

		//EntityObjectCollection m_result = null;
		//public EntityObjectCollection Objects
		//{
		//    get
		//    {
		//        if (m_result == null)
		//        {
		//            m_result = new EntityObjectCollection(Session);

		//            foreach (PreviewRow row in Rows)
		//            {
		//                m_result.Add(row.OID);
		//            }
		//        }

		//        return m_result;
		//    }
		//}
	}
}
