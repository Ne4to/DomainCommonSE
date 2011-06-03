using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainCommonSE.ObjQuery
{
	public class PreviewRowCollection : IEnumerable<PreviewRow>
	{
		List<PreviewRow> m_data;

		public int Count
		{
			get
			{
				return m_data.Count;
			}
		}

		public PreviewRow this[int index]
		{
			get
			{
				return m_data[index];
			}
		}

		internal PreviewRowCollection(int capacity)
		{
			m_data = new List<PreviewRow>(capacity);
		}

		internal void AddRow(PreviewRow row)
		{
			m_data.Add(row);
		}

		public IEnumerator GetEnumerator()
		{
			return new PreviewRowCollectionEnumerator(m_data);
		}

		IEnumerator<PreviewRow> IEnumerable<PreviewRow>.GetEnumerator()
		{
			return new PreviewRowCollectionEnumerator(m_data);
		}
	}
}
