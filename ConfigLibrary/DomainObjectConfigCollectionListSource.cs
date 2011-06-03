using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using DomainCommonSE.DomainConfig;

namespace DomainCommonSE.ConfigLibrary
{
	public class DomainObjectConfigCollectionListSource : DomainObjectConfigCollection, IListSource
	{
		public DomainObjectConfigCollectionListSource(DomainObjectConfigCollection collection)
		{
			foreach (DomainObjectConfig obj in collection)
			{
				Add(obj);
			}
		}

		#region IListSource Members

		public bool ContainsListCollection
		{
			get { return false; }
		}

		public IList GetList()
		{
			return new List<DomainObjectConfig>(m_data.Values); ;
		}

		#endregion
	}
}
