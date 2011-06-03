using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainCommonSE.Collection
{
	public class IndexerCollectionEnumerator<TKey, TValue> : IEnumerator<TValue>
	{
		protected int position = -1;
		protected SortedList<TKey, TValue> m_data;

		public TValue Current
		{
			get 
			{
				return m_data.Values[position]; 
			}
		}

		object IEnumerator.Current
		{
			get 
			{ 
				return m_data.Values[position]; 
			}
		}

		public IndexerCollectionEnumerator(SortedList<TKey, TValue> list)
		{
			m_data = list;
		}
	
		public bool MoveNext()
		{
			position++;
			return (position < m_data.Count);
		}

		public void Reset()
		{
			position = -1;
		}

		public void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
