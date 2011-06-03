using System;
using DomainCommonSE.DomainConfig;

namespace DomainCommonSE.Domain
{
	/// <summary>
	/// Internal ORM object state, using for building SQL save script
	/// </summary>
	internal enum eObjectState
	{
		/// <summary>
		/// Never used, is used for undefined state
		/// </summary>
		Unknown = 0,
		/// <summary>
		/// Object loaded from DB
		/// </summary>
		Old = 1,
		/// <summary>
		/// New, not already saved object
		/// </summary>
		New = 2,
		/// <summary>
		/// Deleted object
		/// </summary>
		Deleted = 4,
		/// <summary>
		/// One or more property were modefied
		/// </summary>
		PropertyModified = 8,

		NotNewAndNotPropertyModified = Int32.MaxValue ^ (eObjectState.New | eObjectState.PropertyModified),

		NotDeleted = Int32.MaxValue ^ eObjectState.Deleted
	}

	/// <summary>
	/// Base ORM object class
	/// </summary>
	public abstract class DomainObject
	{
		public event EventHandler PropertiesChanged;
		/// <summary>
		/// The session, in which the object was created or loaded
		/// </summary>
		public SessionIdentifier Session { get; private set; }
		/// <summary>
		/// The unique object identifier
		/// </summary>
		public ObjectIdentifier ObjectId { get; private set; }
		/// <summary>
		/// Collection of object properties
		/// </summary>
		public DomainPropertyCollection Properties { get; private set; }

		/// <summary>
		/// Object state
		/// </summary>
		internal eObjectState State { get; set; }

		/// <summary>
		/// Constructor for create new object
		/// </summary>
		/// <param name="sessionId">Session identifier</param>
		/// <param name="objectCode">Object code in config inquiry</param>
		public DomainObject(SessionIdentifier sessionId, string objectCode)
		{
			// Save session identifier
			Session = sessionId;
			// Get new object identifier
			ObjectId = DomainObjectManager.Instance.GetNewId(objectCode);
			// Get default properties for this object type
			Properties = DomainObjectManager.Instance.GetEmptyProperties(sessionId, ObjectId);
			AssignPropertyEvents();
			// Set object state to New
			State = eObjectState.New;

			DocumentManager.Instance.AddObject(this);
		}
		/// <summary>
		/// Constructor for load object from DB
		/// It must be used ONLY by EntityObjectFactory inherited class
		/// </summary>
		/// <param name="sessionId">Session identifier</param>
		/// <param name="objectId">Object identifier</param>
		public DomainObject(SessionIdentifier sessionId, ObjectIdentifier objectId)
		{
			// Save session identifier
			Session = sessionId;
			// Save object identifier
			ObjectId = objectId;
		}
		/// <summary>
		/// Init properties and set object state to Old
		/// </summary>
		/// <param name="properties"></param>
		internal void Init(DomainPropertyCollection properties)
		{
			// Save object properties
			Properties = properties;
			AssignPropertyEvents();
			// Set object state to Old
			State |= eObjectState.Old;
		}

		private void AssignPropertyEvents()
		{
			if (Session == SessionIdentifier.SHARED_SESSION)
				return;

			foreach (DomainProperty property in Properties)
			{
				property.ValueChanged += property_ValueChanged;
			}
		}

		void property_ValueChanged(object sender, EventArgs e)
		{
			if ((State & eObjectState.PropertyModified) > 0)
				return;

			State &= eObjectState.PropertyModified;

			if (PropertiesChanged != null)
				PropertiesChanged(this, EventArgs.Empty);
		}
		/// <summary>
		/// Delete object
		/// </summary>
		public void Delete()
		{
			// Set object state to Deleted
			State &= eObjectState.Deleted;
		}

		protected DomainObjectCollection GetLinkCollection(string code, eLinkSide side = eLinkSide.Left)
		{
			return new DomainObjectCollection(this, code, side);
		}
	}
}