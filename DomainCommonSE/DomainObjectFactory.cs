using System;
using DomainCommonSE.Domain;

namespace DomainCommonSE
{
	public abstract class DomainObjectFactory
	{
		public static DomainObjectFactory Instance { get; protected set; }
		
		public DomainObjectFactory()
		{
			Instance = this;
		}

		public abstract DomainObject CreateDomainObject(SessionIdentifier sessionId, ObjectIdentifier objectId);
	}
}
