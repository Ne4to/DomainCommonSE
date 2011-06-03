using System;
using System.Collections;
using System.Collections.Generic;
using DomainCommonSE.Collection;

namespace DomainCommonSE.ObjQuery
{
	public class ObjectQueryParameterCollection : IndexerCollection<string, ObjectQueryParameter>
	{
		public override string ToString()
		{
			return "(Collection)";
		}
	}
}

