using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainCommonSE
{
	public class ObjectMonitor
	{
		private DomainObjectInquiry m_objectInquiry;
		private DocumentManager m_documentManager;

		private Dictionary<ObjectIdentifier, LocalObjectLockInfo> lockedObjectStorage = new Dictionary<ObjectIdentifier, LocalObjectLockInfo>();
		

		static ObjectMonitor m_instance;
		public static ObjectMonitor Instance
		{
			get
			{
				return m_instance;
			}
		}

		public ObjectMonitor(DomainObjectInquiry objectInquiry)
		{
			m_objectInquiry = objectInquiry;
			m_instance = this;
		}

		public void PropertyModified(SessionIdentifier session, ObjectIdentifier objectId)
		{
			LockObject(session, objectId);	
		}

		public void LinkModified(SessionIdentifier session, ObjectIdentifier objectId)
		{
			LockObject(session, objectId);
		}

		private void LockObject(SessionIdentifier session, ObjectIdentifier objectId)
		{
			LocalObjectLockInfo objectLock = null;
			if (lockedObjectStorage.TryGetValue(objectId, out objectLock))
			{
				if (session != objectLock.Session)
				{
					throw new DomainException(String.Format("Объект c OID = {0} заблокирован в сессии {1} {2:HH.mm dd MMMM yyyy}", objectId, objectLock.Session, objectLock.BeginLockDate));
				}

				return;
			}

			lockedObjectStorage.Add(objectId, new LocalObjectLockInfo(session, objectId, DateTime.Now));
		}
	}
}
