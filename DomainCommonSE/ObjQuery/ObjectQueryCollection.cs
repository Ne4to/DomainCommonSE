using System;
using System.Collections;
using System.Collections.Generic;
using DomainCommonSE.Collection;

namespace DomainCommonSE.ObjQuery
{
	public class ObjectQueryCollection : IndexerCollection<string, ObjectQuery>
	{
		public void ChangeQueryCode(ObjectQuery query)
		{
			m_data.RemoveAt(m_data.IndexOfValue(query));
			Add(query);
		}
		/// <summary>
		/// Добавить объектный запрос в коллекцию
		/// </summary>
		/// <param name="obj">Объект</param>
		internal void Add(ObjectQuery query)
		{
			m_data.Add(query.Code, query);
		}
	}
}
