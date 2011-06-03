using System;
using System.Collections;
using System.Collections.Generic;
using DomainCommonSE.Collection;

namespace DomainCommonSE.DomainConfig
{
	/// <summary>
	/// Коллекция свойств предметной области
	/// </summary>
	public class DomainPropertyConfigCollection : IndexerCollection<string, DomainPropertyConfig>
	{
		/// <summary>
		/// Добавить свойство в коллекцию
		/// </summary>
		/// <param name="obj">Свойство</param>
		internal void Add(DomainPropertyConfig obj)
		{
			Add(obj.Code, obj);
		}
	}
}
