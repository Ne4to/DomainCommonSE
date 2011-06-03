using System;
using System.Collections;
using System.Collections.Generic;
using DomainCommonSE.Collection;

namespace DomainCommonSE.DomainConfig
{
	/// <summary>
	/// Коллекция объектов предметной области
	/// </summary>
	public class DomainObjectConfigCollection : IndexerCollection<string, DomainObjectConfig>
	{
		public void Add(DomainObjectConfig obj)
		{
			Add(obj.Code, obj);
		}
	}
}