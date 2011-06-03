using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainCommonSE.Collection
{
	public class IndexerCollection<TKey, TValue> : IEnumerable<TValue>
	{
		protected SortedList<TKey, TValue> m_data = new SortedList<TKey, TValue>();
		
		public int Count
		{
			get
			{
				return m_data.Count;
			}
		}

		public TValue this[TKey code]
		{
			get
			{
				return m_data[code];
			}
		}

		public TValue this[int index]
		{
			get
			{
				return m_data.Values[index];
			}
		}

		public void ChangeKey(TKey oldKey, TKey newKey, TValue value)
		{
			m_data.Remove(oldKey);
			m_data.Add(newKey, value);
		}

		internal void Add(TKey key, TValue value)
		{
			m_data.Add(key, value);
		}

		internal void Delete(TKey code)
		{
			m_data.Remove(code);
		}

		public bool Contains(TKey code)
		{
			return m_data.ContainsKey(code);
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			return new IndexerCollectionEnumerator<TKey, TValue>(m_data);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
