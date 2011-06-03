using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using DomainCommonSE.DomainConfig;

namespace DomainCommonSE.Domain
{
	public interface IDomainObjectCollection : IEnumerable<DomainObject>
	{
		int Count { get; }
		DomainObject this[int index] { get; }
		void Add(DomainObject obj);
		void Extract(DomainObject obj);
		bool Contains(DomainObject obj);
		void Clear();
	}

	public class DomainObjectCollection : IDomainObjectCollection
	{
		ObjectIdentifier m_ownerObjectId;
		SessionIdentifier m_ownerSessionId;
		eLinkSide m_side;
		DomainLink m_link;

		//GetLink(string objectCode, string linkCode, eLinkSide side)

		internal DomainObjectCollection(DomainObject obj, string linkCode, eLinkSide side = eLinkSide.Left)
		{
			m_ownerObjectId = obj.ObjectId;
			m_ownerSessionId = obj.Session;
			m_side = side;

			DomainLinkKey linkKey = new DomainLinkKey()
			{
				LeftObjectCode = side == eLinkSide.Left ? obj.ObjectId.Code: String.Empty,
				RightObjectCode = side == eLinkSide.Right ? obj.ObjectId.Code: String.Empty,
				LinkCode = linkCode
			};

			m_link = DocumentManager.Instance.GetLink(obj.Session, linkKey);			
		}

		public int Count
		{
			get
			{
				return m_link.GetCount(m_ownerObjectId, m_side);
			}
		}

		public DomainObject this[int index]
		{
			get
			{
				return m_link.GetItem(m_ownerSessionId, m_ownerObjectId, m_side, index);
			}
		}

		public void Add(DomainObject obj)
		{
			switch (m_side)
			{
				case eLinkSide.Left:
					m_link.Add(m_ownerObjectId, obj.ObjectId);
					break;

				case eLinkSide.Right:
					m_link.Add(obj.ObjectId, m_ownerObjectId);
					break;
			}
		}

		public void Extract(DomainObject obj)
		{
			switch (m_side)
			{
				case eLinkSide.Left:
					m_link.Remove(m_ownerObjectId, obj.ObjectId);
					break;

				case eLinkSide.Right:
					m_link.Remove(obj.ObjectId, m_ownerObjectId);
					break;
			}
		}

		public bool Contains(DomainObject obj)
		{
			return m_link.Contains(m_ownerObjectId, m_side, obj.ObjectId);
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public IEnumerator<DomainObject> GetEnumerator()
		{			
			return new DomainObjectCollectionEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new DomainObjectCollectionEnumerator(this);
		}
	}

	//public class EntityObjectCollection : IEnumerable<EntityObject>
	//{
	//    public string ObjectCode { get; protected set; }
	//    public SessionIdentifier Session { get; private set; }
	//    protected internal List<ObjectIdentifier> m_oIdList;

	//    public EntityObject this[int index]
	//    {
	//        get
	//        {
	//            return DocumentManager.Instance.GetObject(Session, m_oIdList[index]);
	//        }
	//    }

	//    public int Count
	//    {
	//        get
	//        {
	//            return m_oIdList.Count;
	//        }
	//    }

	//    internal EntityObjectCollection(SessionIdentifier sid)
	//    {
	//        Session = sid;
	//        m_oIdList = new List<ObjectIdentifier>();
	//    }

	//    public bool Add(EntityObject obj)
	//    {
	//        if (!m_oIdList.Contains(obj.ObjectId))
	//        {
	//            m_oIdList.Add(obj.ObjectId);
	//            AddItem(obj);
	//            return true;
	//        }

	//        return false;
	//    }

	//    public bool Del(EntityObject obj)
	//    {
	//        if (m_oIdList.Contains(obj.ObjectId))
	//        {
	//            m_oIdList.Remove(obj.ObjectId);
	//            DelItem(obj);
	//            return true;
	//        }

	//        return false;
	//    }

	//    internal void Add(ObjectIdentifier oid)
	//    {
	//        if (!m_oIdList.Contains(oid))
	//        {
	//            m_oIdList.Add(oid);
	//        }
	//    }

	//    #region События		
	//    public event EventHandler<EntityObjectArgs> AddItemEvent;
	//    protected virtual void AddItem(EntityObject obj)
	//    {
	//        if (AddItemEvent != null)
	//            AddItemEvent(this, new EntityObjectArgs(obj));
	//    }

	//    public event EventHandler<EntityObjectArgs> DelItemEvent;
	//    protected virtual void DelItem(EntityObject obj)
	//    {
	//        if (DelItemEvent != null)
	//            DelItemEvent(this, new EntityObjectArgs(obj));
	//    }
	//    #endregion

	//    IEnumerator IEnumerable.GetEnumerator()
	//    {
	//        return new EntityObjectCollectionEnumerator(this);
	//    }

	//    internal EntityObjectCollection Clone(SessionIdentifier newSessionId)
	//    {
	//        EntityObjectCollection clone = new EntityObjectCollection(newSessionId);
	//        clone.m_oIdList.AddRange(m_oIdList);

	//        return clone;
	//    }

	//    IEnumerator<EntityObject> IEnumerable<EntityObject>.GetEnumerator()
	//    {
	//        return new EntityObjectCollectionEnumerator(this);
	//    }
	//}

	//public class EntityObjectCollection<TObject> : EntityObjectCollection
	//    where TObject : EntityObject
	//{
	//    public EntityObjectCollection(SessionIdentifier sid, string objectCode)
	//        : base(sid)
	//    {
	//        ObjectCode = objectCode;
	//    }

	//    new public TObject this[int index]
	//    {
	//        get
	//        {
	//            return base[index] as TObject;
	//        }
	//    }
	//}

	//public class EntityObjectArgs : EventArgs
	//{
	//    public EntityObject AObject { get; private set; }

	//    public EntityObjectArgs(EntityObject obj)
	//    {
	//        AObject = obj;
	//    }
	//}
}
