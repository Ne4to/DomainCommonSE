using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCommonSE.Domain
{
	public class DomainObjectCollectionEnumerator : IEnumerator<DomainObject>
	{
		private int m_position = -1;
		private DomainObjectCollection m_collection;

		public DomainObjectCollectionEnumerator(DomainObjectCollection collection)
		{
			m_collection = collection;
		}

		public DomainObject Current
		{
			get { return m_collection[m_position]; }
		}

		public void Dispose()
		{
			//throw new NotImplementedException();
		}

		object System.Collections.IEnumerator.Current
		{
			get { return m_collection[m_position]; }
		}

		public bool MoveNext()
		{
			m_position++;
			return (m_position < m_collection.Count);
		}

		public void Reset()
		{
			m_position = -1;
		}
	}
}
