using System;
using System.Linq;
using System.Collections.Generic;
using DomainCommonSE.Domain;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE
{
	internal class ObjectRepository
	{
		private Dictionary<ObjectIdentifier, DomainObject> m_object = new Dictionary<ObjectIdentifier, DomainObject>();
		private Dictionary<DomainLinkKey, DomainLink> m_link;

		public IEnumerable<IGrouping<string, DomainObject>> NewObjectGroup
		{
			get
			{
				return from obj in m_object.Values
					   where obj.State.HasFlag(eObjectState.New)
					   group obj by obj.ObjectId.Code;
			}
		}

		public IEnumerable<IGrouping<string, DomainObject>> OldChangedObjects
		{
			get
			{
				return from obj in m_object.Values
					   where obj.State.HasFlag(eObjectState.PropertyModified) && !obj.State.HasFlag(eObjectState.New)
					   group obj by obj.ObjectId.Code;
			}
		}

		public IEnumerable<IGrouping<string, DomainObject>> DeletedObjects
		{
			get
			{
				return from obj in m_object.Values
					   where obj.State.HasFlag(eObjectState.Deleted)
					   group obj by obj.ObjectId.Code;
			}
		}

		public Dictionary<DomainLink, IEnumerable<DomainLinkNode>> NewLinks
		{
			get
			{
				return m_link.Values.ToDictionary((dl) => dl, (dl) => dl.NewNodes);
			}
		}

		public Dictionary<DomainLink, IEnumerable<DomainLinkNode>> DeletedLinks
		{
			get
			{
				return m_link.Values.ToDictionary((dl) => dl, (dl) => dl.DeletedNodes);
			}
		}

		public IEnumerable<DomainObject> NewObject
		{
			get
			{
				return from obj in m_object.Values
					   where obj.State.HasFlag(eObjectState.New)
					   select obj;
			}
		}

		public IEnumerable<DomainObject> PropertyModifiedObject
		{
			get
			{
				return from obj in m_object.Values
					   where obj.State.HasFlag(eObjectState.PropertyModified) && !obj.State.HasFlag(eObjectState.New)
					   select obj;
			}
		}

		public ObjectRepository(SessionIdentifier session, DomainObjectInquiry objectInquiry)
		{
			m_link = new Dictionary<DomainLinkKey, DomainLink>(objectInquiry.ALinks.Count);

			foreach (DomainLinkConfig linkConfig in objectInquiry.ALinks)
			{
				DomainLinkKey key = new DomainLinkKey(linkConfig);
				DomainLink link = new DomainLink(linkConfig, session);

				m_link.Add(key, link);
			}
		}

		public void ResetObjectState()
		{
			var oldObj = from obj in m_object.Values
						 where obj.State.HasFlag(eObjectState.PropertyModified) || obj.State.HasFlag(eObjectState.New)
						 select obj;

			foreach (var obj in oldObj)
			{
				obj.State &= eObjectState.NotNewAndNotPropertyModified;
				obj.State |= eObjectState.Old;
			}
		}

		public void ResetLinkState()
		{
			foreach (var link in m_link.Values)
			{
				link.ResetStateToOld();
			}
		}

		public void Add(DomainObject obj)
		{
			m_object.Add(obj.ObjectId, obj);
		}

		public void ChangeTo(DomainObject obj)
		{
			m_object[obj.ObjectId] = obj;
		}

		public DomainObject GetObject(ObjectIdentifier objectId)
		{
			DomainObject result = null;
			m_object.TryGetValue(objectId, out result);

			return result;
		}

		public DomainLink GetLink(DomainLinkKey key)
		{
			return m_link[key];
		}
	}
}
