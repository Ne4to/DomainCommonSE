using System;
using System.Collections.Generic;

namespace DomainCommonSE.ObjQuery
{
	public class PreviewRowCollectionEnumerator : IEnumerator<PreviewRow>
	{
		int position = -1;
		List<PreviewRow> m_data;

		public bool MoveNext()
		{
			position++;
			return (position < m_data.Count);
		}

		public void Reset()
		{
			position = -1;
		}

		public object Current
		{
			get
			{
				try
				{
					return m_data[position];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		public PreviewRowCollectionEnumerator(List<PreviewRow> list)
		{
			m_data = list;
		}

		PreviewRow IEnumerator<PreviewRow>.Current
		{
			get
			{
				try
				{
					return m_data[position];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		public void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
