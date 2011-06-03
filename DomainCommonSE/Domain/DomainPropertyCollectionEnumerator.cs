using System;
using System.Collections.Generic;

namespace DomainCommonSE.Domain
{
	public class DomainPropertyCollectionEnumerator : IEnumerator<DomainProperty>
	{
		int position = -1;
		SortedList<string, DomainProperty> m_property;

		public bool MoveNext()
		{
			position++;
			return (position < m_property.Count);
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
					return m_property.Values[position];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		public DomainPropertyCollectionEnumerator(SortedList<string, DomainProperty> list)
		{
			m_property = list;
		}

		DomainProperty IEnumerator<DomainProperty>.Current
		{
			get 
			{
				try
				{
					return m_property.Values[position];
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
