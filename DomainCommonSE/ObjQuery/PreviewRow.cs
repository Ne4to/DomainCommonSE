using System;
using System.Data;

namespace DomainCommonSE.ObjQuery
{
	public class PreviewRow
	{
		public const string OidField = "OID";

		DataRow m_data;
		public ObjectIdentifier OID { get; private set; }

		//public string this[string code]
		//{
		//    get
		//    {
		//        return m_data[code].ToString();
		//    }
		//}

		public object this[string code]
		{
			get
			{
				object res = m_data[code];
				return res is DBNull ? null : res;
			}
		}

		internal PreviewRow(string objectCode, DataRow row)
		{
			m_data = row;
			try
			{
				object oidValue = m_data[OidField];
				long idValue = Convert.ToInt64(oidValue);
				OID = new ObjectIdentifier(objectCode, idValue);
			}
			catch (ArgumentException)
			{
				OID = ObjectIdentifier.ERROR_OID;
			}
		}
	}
}
