using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCommonSE.DbCommon
{
	public class DbCommonScheme
	{
		private List<DbCommonSchemeTable> m_tables = new List<DbCommonSchemeTable>();

		public IEnumerable<DbCommonSchemeTable> Tables
		{
			get
			{
				return m_tables;
			}
		}

		public void AddTable(DbCommonSchemeTable table)
		{
			m_tables.Add(table);
		}
	}

	public class DbCommonSchemeTable
	{
		public string Name { get; private set; }

		private List<DbCommonSchemeTableField> m_fields = new List<DbCommonSchemeTableField>();
		public IEnumerable<DbCommonSchemeTableField> Fields
		{
			get
			{
				return m_fields;
			}
		}

		public DbCommonSchemeTable(string name)
		{
			Name = name;
		}

		public void AddField(DbCommonSchemeTableField field)
		{
			m_fields.Add(field);
		}

		public override string ToString()
		{
			return Name;
		}
	}

	public class DbCommonSchemeTableField
	{
		public string Name { get; private set; }
		public string DataType { get; private set; }

		public DbCommonSchemeTableField(string name, string dataType)
		{
			Name = name;
			DataType = dataType;
		}

		public override string ToString()
		{
			return String.Format("{0} ({1})", Name, DataType);
		}
	}
}
