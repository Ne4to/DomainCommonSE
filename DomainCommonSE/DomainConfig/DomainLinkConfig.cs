using System;
using DomainCommonSE.DbCommon;
using DomainCommonSE.Domain;

namespace DomainCommonSE.DomainConfig
{
	public enum eRelation
	{
		One = 1,
		Many = 100
	}

	public enum eLinkSide
	{
		Left,
		Right
	}

	internal enum eLinkNodeState
	{
		Unknown = 0,
		New = 1,
		Old = 2,
		OldDelete = 4
	}

	public class DomainLinkConfig
	{
		internal DomainLinkKey Key { get; private set; }

		public long Id { get; private set; }
		public string Code { get; private set; }

		public eRelation LeftRelation { get; private set; }
		public eRelation RightRelation { get; private set; }

		public DomainObjectConfig LeftObject { get; private set; }
		public DomainObjectConfig RightObject { get; private set; }

		public string LinkTable { get; private set; }

		public string LeftObjectIdField { get; private set; }
		public string RightObjectIdField { get; private set; }

		public bool IsLeftToRightActive { get; private set; }
		public bool IsRightToLeftActive { get; private set; }

		public string LeftToRightDescription { get; private set; }
		public string RightToLeftDescription { get; private set; }

		public string LeftCollectionName { get; private set; }
		public string RightCollectionName { get; private set; }

		internal DomainLinkConfig(CreateLinkParams createParams, EditLinkParams editParams = null)
		{
			Id = createParams.Id;
			Code = createParams.Code;
			LeftRelation = createParams.LeftRelation;
			RightRelation = createParams.RightRelation;
			LeftObject = createParams.LeftObject;
			RightObject = createParams.RightObject;
			LinkTable = createParams.LinkTable;
			LeftObjectIdField = createParams.LeftObjectIdField;
			RightObjectIdField = createParams.RightObjectIdField;

			if (editParams != null)
				Update(editParams);

			Key = new DomainLinkKey(this);
		}

		internal void Update(EditLinkParams editParams)
		{
			IsLeftToRightActive = editParams.IsLeftToRightActive;
			IsRightToLeftActive = editParams.IsRightToLeftActive;
			LeftToRightDescription = editParams.LeftToRightDescription;
			RightToLeftDescription = editParams.RightToLeftDescription;
			LeftCollectionName = editParams.LeftCollectionName;
			RightCollectionName = editParams.RightCollectionName;
		}
	}

	public class CreateLinkParams
	{
		public long Id { get; set; }
		public string Code { get; set; }
		public DomainObjectConfig LeftObject { get; set; }
		public DomainObjectConfig RightObject { get; set; }
		public eRelation LeftRelation { get; set; }
		public eRelation RightRelation { get; set; }
		public string LinkTable { get; set; }
		public string LeftObjectIdField { get; set; }
		public string RightObjectIdField { get; set; }
	}

	public class EditLinkParams
	{
		public bool IsLeftToRightActive { get; set; }
		public bool IsRightToLeftActive { get; set; }
		public string LeftToRightDescription { get; set; }
		public string RightToLeftDescription { get; set; }
		public string LeftCollectionName { get; set; }
		public string RightCollectionName { get; set; }
	}
}