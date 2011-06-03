using System;
using System.Linq;
using System.Collections.Generic;
using DomainCommonSE.DomainConfig;

namespace DomainCommonSE.Domain
{
	internal class DomainLinkNode : IEquatable<DomainLinkNode>
	{
		public ObjectIdentifier LeftObjectId { get; private set; }
		public ObjectIdentifier RightObjectId { get; private set; }

		public DomainLinkNode(ObjectIdentifier leftObjectId, ObjectIdentifier rightObjectId)
		{
			LeftObjectId = leftObjectId;
			RightObjectId = rightObjectId;
		}

		public bool Equals(DomainLinkNode other)
		{
			return LeftObjectId == other.LeftObjectId && RightObjectId == other.RightObjectId;
		}
	}

	internal struct DomainLinkKey : IEquatable<DomainLinkKey>, IComparable<DomainLinkKey>
	{
		public string LinkCode;
		public string LeftObjectCode;
		public string RightObjectCode;

		public DomainLinkKey(DomainLinkConfig linkConfig)
		{
			LinkCode = linkConfig.Code;
			LeftObjectCode = linkConfig.LeftObject.Code;
			RightObjectCode = linkConfig.RightObject.Code;
		}

		#region IComparable<DomainLinkKey> Members

		public int CompareTo(DomainLinkKey other)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IEquatable<DomainLinkKey> Members

		public bool Equals(DomainLinkKey other)
		{
			return LinkCode == other.LinkCode && (LeftObjectCode == other.LeftObjectCode || RightObjectCode == other.RightObjectCode);
		}

		#endregion
	}

	internal class DomainLink
	{
		SessionIdentifier m_session;
		DomainLinkConfig m_config;

		public DomainLinkKey Key { get; private set; }

		public IEnumerable<DomainLinkNode> NewNodes
		{
			get
			{
				return from kvp in m_allNode
					   where kvp.Value == eLinkNodeState.New
					   select kvp.Key;
			}
		}

		public IEnumerable<DomainLinkNode> DeletedNodes
		{
			get
			{
				return from kvp in m_allNode
					   where kvp.Value == eLinkNodeState.OldDelete
					   select kvp.Key;
			}
		}

		// коллекция отображающая состояния элементов ссылок между объектами
		Dictionary<DomainLinkNode, eLinkNodeState> m_allNode = new Dictionary<DomainLinkNode, eLinkNodeState>();
		// список привязанных объектов с правой стороны к объекту с левой стороны
		Dictionary<ObjectIdentifier, List<ObjectIdentifier>> m_leftObjects;
		// список привязанных объектов с левой стороны к объекту с правой стороны
		Dictionary<ObjectIdentifier, List<ObjectIdentifier>> m_rightObjects;

		internal DomainLink(DomainLinkConfig config, SessionIdentifier session)
		{
			if (config == null)
				throw new ArgumentNullException("config");

			Key = new DomainLinkKey(config);

			m_config = config;

			if (m_config.IsLeftToRightActive)
				m_leftObjects = new Dictionary<ObjectIdentifier, List<ObjectIdentifier>>();

			if (m_config.IsRightToLeftActive)
				m_rightObjects = new Dictionary<ObjectIdentifier, List<ObjectIdentifier>>();

			m_session = session;
		}

		public void ResetStateToOld()
		{
			foreach (DomainLinkNode linkKey in m_allNode.Keys.ToArray())
			{
				m_allNode[linkKey] = eLinkNodeState.Old;
			}
		}
		/// <summary>
		/// Связать два объекта
		/// </summary>
		/// <param name="leftObjectId">id левого объекта</param>
		/// <param name="rightObjectId">id правого объекта</param>
		public void Add(ObjectIdentifier leftObjectId, ObjectIdentifier rightObjectId)
		{
			DomainLinkNode linkKey = new DomainLinkNode(leftObjectId, rightObjectId);
			eLinkNodeState linkState;
			if (m_allNode.TryGetValue(linkKey, out linkState))
			{
				switch (linkState)
				{
					// если ссылка была удалена и снова добавлено, то в базе никаких изменений и объекты уже должны быть заблокированны
					case eLinkNodeState.OldDelete:
						m_allNode[linkKey] = eLinkNodeState.Old;
						break;

					// если ссылка была уже до этого добавлена, то объекты уже и так связаны и ничего менять не надо
					case eLinkNodeState.New:
					case eLinkNodeState.Old:
						return;
				}
			}
			else
			{
				//// если добавили новую ссылку, то блокируем объекты и добавляем ее в коллекцию
				//if (m_config.IsLeftToRightActive)
				//    ObjectMonitor.Instance.LinkModified(m_session, leftObjectId);

				//if (m_config.IsRightToLeftActive)
				//    ObjectMonitor.Instance.LinkModified(m_session, rightObjectId);

				// изменить статус ссылки ссылки для последующего сохранения в БД
				m_allNode[linkKey] = eLinkNodeState.New;
			}

			if (m_config.IsLeftToRightActive)
			{
				List<ObjectIdentifier> list = null;
				if (m_leftObjects.TryGetValue(leftObjectId, out list))
				{
					if (!list.Contains(rightObjectId))
					{
						list.Add(rightObjectId);
					}
				}
				else
				{
					list = new List<ObjectIdentifier>();
					m_leftObjects.Add(leftObjectId, list);
					list.Add(rightObjectId);
				}
			}

			if (m_config.IsRightToLeftActive)
			{
				List<ObjectIdentifier> list = null;
				if (m_rightObjects.TryGetValue(rightObjectId, out list))
				{
					if (!list.Contains(leftObjectId))
					{
						list.Add(leftObjectId);
					}
				}
				else
				{
					list = new List<ObjectIdentifier>();
					m_rightObjects.Add(rightObjectId, list);
					list.Add(leftObjectId);
				}
			}
		}

		public void Init(long leftId, long rightId)
		{
			ObjectIdentifier leftObjectId = new ObjectIdentifier(m_config.LeftObject.Code, leftId);
			ObjectIdentifier rightObjectId = new ObjectIdentifier(m_config.RightObject.Code, rightId);
			DomainLinkNode node = new DomainLinkNode(leftObjectId, rightObjectId);

			m_allNode.Add(node, eLinkNodeState.Old);

			if (m_config.IsLeftToRightActive)
			{
				List<ObjectIdentifier> list = null;
				if (!m_leftObjects.TryGetValue(leftObjectId, out list))
				{
					list = new List<ObjectIdentifier>();
					m_leftObjects.Add(leftObjectId, list);
				}
				
				list.Add(rightObjectId);
			}

			if (m_config.IsRightToLeftActive)
			{
				List<ObjectIdentifier> list = null;
				if (!m_rightObjects.TryGetValue(rightObjectId, out list))
				{
					list = new List<ObjectIdentifier>();
					m_rightObjects.Add(rightObjectId, list);
				}

				list.Add(leftObjectId);
			}
		}
		/// <summary>
		/// развязать два объекта
		/// </summary>
		/// <param name="leftObject"></param>
		/// <param name="rightObject"></param>
		public void Remove(ObjectIdentifier leftObjectId, ObjectIdentifier rightObjectId)
		{
			DomainLinkNode linkKey = new DomainLinkNode(leftObjectId, rightObjectId);
			eLinkNodeState linkState;
			if (m_allNode.TryGetValue(linkKey, out linkState))
			{
				switch (linkState)
				{
					// если ссылка была удалена, то ничего не меняем, хотя сюда мы не должны никак попасть...
					case eLinkNodeState.OldDelete:
						return;

					// если удаляем новую. то в базе никаких изменений
					case eLinkNodeState.New:
						m_allNode.Remove(linkKey);
						break;

					// если был старый, то надо удалить из базы
					case eLinkNodeState.Old:
						m_allNode[linkKey] = eLinkNodeState.OldDelete;
						break;
				}
			}

			if (m_config.IsLeftToRightActive)
			{
				List<ObjectIdentifier> list = null;
				if (m_leftObjects.TryGetValue(leftObjectId, out list))
				{
					bool removeResult = list.Remove(rightObjectId);

					if (removeResult == false)
					{
						throw new Exception("сюда не должны попасть, т.к. если в коллекциях небыло этого объекта, то и удалить мы его не можем");
					}
				}
			}

			if (m_config.IsRightToLeftActive)
			{
				List<ObjectIdentifier> list = null;
				if (m_rightObjects.TryGetValue(rightObjectId, out list))
				{
					bool removeResult = list.Remove(leftObjectId);

					if (removeResult == false)
					{
						throw new Exception("сюда не должны попасть, т.к. если в коллекциях небыло этого объекта, то и удалить мы его не можем");
					}
				}
			}
		}

		public int GetCount(ObjectIdentifier objId, eLinkSide side)
		{
			List<ObjectIdentifier> list = GetList(objId, side);
			return list.Count;
		}

		public DomainObject GetItem(SessionIdentifier ownerSessionId, ObjectIdentifier objId, eLinkSide side, int index)
		{
			List<ObjectIdentifier> list = GetList(objId, side);
			ObjectIdentifier oid = list[index];

			return DocumentManager.Instance.GetObject(ownerSessionId, oid);			
		}

		public bool Contains(ObjectIdentifier objId, eLinkSide side, ObjectIdentifier otherSideObjectId)
		{
			List<ObjectIdentifier> list = GetList(objId, side);
			return list.Contains(otherSideObjectId);
		}

		private List<ObjectIdentifier> GetList(ObjectIdentifier objId, eLinkSide side)
		{
			Dictionary<ObjectIdentifier, List<ObjectIdentifier>> dict = null;

			switch (side)
			{
				case eLinkSide.Left:
					dict = m_leftObjects;
					break;

				case eLinkSide.Right:
					dict = m_rightObjects;
					break;
			}

			List<ObjectIdentifier> list = null;
			if (dict.TryGetValue(objId, out list))
			{
				return list;
			}

			throw new Exception("Попытка получить коллекцию связанных объектов для объекта который еще не материализован");
		}
	}
}