using System;
using System.Collections;
using System.Collections.Generic;

namespace DomainCommonSE.Domain
{
	public class DomainPropertyCollection : IEnumerable<DomainProperty>
	{
		SortedList<string, DomainProperty> m_property;

		public DomainProperty this[string code]
		{
			get
			{
				DomainProperty obj = null;
				if (m_property.TryGetValue(code, out obj))
					return obj;

				throw new DomainException(String.Format("Свойство с кодом '{0}' не найден.", code));
			}
		}

		internal DomainPropertyCollection()
		{
			m_property = new SortedList<string, DomainProperty>();
		}

		public IEnumerator GetEnumerator()
		{
			return new DomainPropertyCollectionEnumerator(m_property);
		}

		internal void Add(DomainProperty prop)
		{
			m_property.Add(prop.Code, prop);
		}

		IEnumerator<DomainProperty> IEnumerable<DomainProperty>.GetEnumerator()
		{
			return new DomainPropertyCollectionEnumerator(m_property);
		}
	}
}
