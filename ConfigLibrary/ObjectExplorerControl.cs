using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DomainCommonSE.ConfigLibrary.Localization;
using DomainCommonSE.DbCommon;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class ObjectExplorerControl : RuntimeControl
	{
		public DomainObjectInquiry FocusedInquiry
		{
			get
			{
				TreeListNode node = objectTree.FocusedNode;
				if (node == null)
					return null;

				return (node.Tag as ObjectExplorerNodeTag).Inquiry;
			}
		}

		public ObjectExplorerControl()
		{
			InitializeComponent();
		}

		private static string GetNodeTitle(DomainObjectConfig objConfig)
		{
			return String.Format("{0} ({1})", objConfig.Code, objConfig.Description);
		}

		private static string GetNodeTitle(DomainPropertyConfig prop)
		{
			return String.Format("{0} ({1})", prop.Code, prop.Description);
		}

		private static string GetNodeTitle(DomainLinkConfig link)
		{		
			return String.Format("{0}, {1} | {2}", link.LeftObject.Code, link.RightObject.Code, link.Code);
		}

		private TreeListNode AppendNode(TreeListNode parentNode, string title, ObjectExplorerNodeTag tag)
		{
			return objectTree.AppendNode(new object[] { title }, parentNode, tag);
		}

		private void AppendObjectConfigNode(TreeListNode parentNode, DomainObjectInquiry inquiry, DomainObjectConfig objConfig)
		{
			TreeListNode objNode = AppendNode(parentNode, GetNodeTitle(objConfig), new ObjectExplorerNodeTag(inquiry, eObjectExplorerNode.ObjectConfig, objConfig));

			TreeListNode objPropertiesNode = AppendNode(objNode, ObjectExplorerControlLocalization.PropertiesNodeTitle, new ObjectExplorerNodeTag(inquiry, eObjectExplorerNode.ObjectProperties, objConfig));

			foreach (DomainPropertyConfig prop in objConfig.Property)
			{
				AppendPropertyConfigNode(inquiry, objPropertiesNode, prop);
			}			
		}

		private void AppendPropertyConfigNode(DomainObjectInquiry inquiry, TreeListNode objPropertiesNode, DomainPropertyConfig prop)
		{
			AppendNode(objPropertiesNode, GetNodeTitle(prop), new ObjectExplorerNodeTag(inquiry, eObjectExplorerNode.ObjectPropertyConfig, prop));
		}

		private void AppendLinkConfigNode(DomainObjectInquiry inquiry, TreeListNode objLinksNode, DomainLinkConfig link)
		{
			AppendNode(objLinksNode, GetNodeTitle(link), new ObjectExplorerNodeTag(inquiry, eObjectExplorerNode.LinkConfig, link));
		}

		private static TreeListNode GetParentNode(DomainObjectInquiry inquiry, TreeList tree)
		{
			for (int i = 0; i < tree.Nodes.Count; i++)
			{
				TreeListNode node = tree.Nodes[i];
				ObjectExplorerNodeTag tag = node.Tag as ObjectExplorerNodeTag;
				if (tag.Inquiry == inquiry)
					return node;
			}

			return null;
		}

		private TreeListNode GetParentNode(DomainObjectInquiry inquiry)
		{
			return GetParentNode(inquiry, objectTree);
		}

		private static TreeListNode GetNode(TreeListNode parentNode, eObjectExplorerNode nodeKind)
		{
			return parentNode.Nodes.OfType<TreeListNode>().FirstOrDefault(node => (node.Tag as ObjectExplorerNodeTag).Kind == nodeKind);
		}

		private static TreeListNode GetNodeByValue(TreeListNode parentNode, object value)
		{
			return parentNode.Nodes.OfType<TreeListNode>().FirstOrDefault(node => (node.Tag as ObjectExplorerNodeTag).Value == value);
		}

		private TreeListNode GetRootObjectsNode(DomainObjectInquiry inquiry)
		{
			TreeListNode dbNode = GetParentNode(inquiry);

			if (dbNode == null)
				throw new ApplicationException(ObjectExplorerControlLocalization.RootDbNodeNotFoundError);

			TreeListNode objectRootNode = GetNode(dbNode, eObjectExplorerNode.RootObjects);
			if (objectRootNode == null)
				throw new ApplicationException(ObjectExplorerControlLocalization.ObjectsRootNodeNotFoundError);

			return objectRootNode;
		}

		private TreeListNode GetRootObjectQueryNode(DomainObjectInquiry inquiry)
		{
			TreeListNode dbNode = GetParentNode(inquiry);

			if (dbNode == null)
				throw new ApplicationException(ObjectExplorerControlLocalization.RootDbNodeNotFoundError);

			TreeListNode objectQueryRootNode = GetNode(dbNode, eObjectExplorerNode.RootObjectQuery);
			if (objectQueryRootNode == null)
				throw new ApplicationException(ObjectExplorerControlLocalization.ObjectQueriesNodeNotFoundError);

			return objectQueryRootNode;
		}

		private TreeListNode GetObjectConfigNode(DomainObjectInquiry inquiry, DomainObjectConfig objectConfig)
		{
			TreeListNode objectRootNode = GetRootObjectsNode(inquiry);
			return GetNodeByValue(objectRootNode, objectConfig);
		}

		private TreeListNode GetPropertiesNode(DomainObjectInquiry inquiry, DomainObjectConfig objectConfig)
		{
			TreeListNode objectConfigNode = GetObjectConfigNode(inquiry, objectConfig);
			TreeListNode propertyCollectionNode = GetNode(objectConfigNode, eObjectExplorerNode.ObjectProperties);

			if (propertyCollectionNode == null)
				throw new ApplicationException(ObjectExplorerControlLocalization.PropertyCollectionNodeNotFoundError);

			return propertyCollectionNode;
		}

		private TreeListNode GetLinksNode(DomainObjectInquiry inquiry)
		{
			TreeListNode dbNode = GetParentNode(inquiry);

			if (dbNode == null)
				throw new ApplicationException(ObjectExplorerControlLocalization.RootDbNodeNotFoundError);

			TreeListNode linkCollectionNode = GetNode(dbNode, eObjectExplorerNode.RootLinks);

			if (linkCollectionNode == null)
				throw new ApplicationException(ObjectExplorerControlLocalization.LinkCollectionNodeNotFoundError);

			return linkCollectionNode;
		}

		private static DomainObjectInquiry GetInquiry(TreeListNode node)
		{
			return (node.Tag as ObjectExplorerNodeTag).Inquiry;
		}

		private void BindData(DomainObjectInquiry inquiry)
		{
			try
			{
				inquiry.CreateObjectCompleted += ObjectInquiry_CreateObjectCompleted;
				inquiry.EditObjectCompleted += ObjectInquiry_EditObjectCompleted;
				inquiry.DeleteObjectCompleted += ObjectInquiry_DeleteObjectCompleted;

				inquiry.CreatePropertyCompleted += ObjectInquiry_CreatePropertyCompleted;
				inquiry.EditPropertyCompleted += ObjectInquiry_EditPropertyCompleted;
				inquiry.DeletePropertyCompleted += ObjectInquiry_DeletePropertyCompleted;

				inquiry.CreateLinkCompleted += ObjectInquiry_CreateLinkCompleted;
				inquiry.EditLinkCompleted += ObjectInquiry_EditLinkCompleted;
				inquiry.DeleteLinkCompleted += ObjectInquiry_DeleteLinkCompleted;

				inquiry.CreateObjectQueryCompleted += ObjectInquiry_CreateObjectQueryCompleted;
				inquiry.DeleteObjectQueryCompleted += ObjectInquiry_DeleteObjectQueryCompleted;

				inquiry.IsModifiedChanged += ObjectInquiry_IsEditedChanged;

				objectTree.BeginUpdate();

				TreeListNode dbRootNode = AppendNode(null, ObjectExplorerControlLocalization.DbNodeTitle, new ObjectExplorerNodeTag(inquiry, eObjectExplorerNode.Database));

				TreeListNode objectRootNode = AppendNode(dbRootNode, ObjectExplorerControlLocalization.ObjectsNodeTitle, new ObjectExplorerNodeTag(inquiry, eObjectExplorerNode.RootObjects));

				foreach (DomainObjectConfig objConfig in inquiry.AObject)
				{
					AppendObjectConfigNode(objectRootNode, inquiry, objConfig);
				}

				TreeListNode linkRootNode = AppendNode(dbRootNode, ObjectExplorerControlLocalization.LinksNodeTitle, new ObjectExplorerNodeTag(inquiry, eObjectExplorerNode.RootLinks));

				foreach (DomainLinkConfig link in inquiry.ALinks)
				{
					AppendLinkConfigNode(inquiry, linkRootNode, link);
				}

				TreeListNode objectQueryRoot = AppendNode(dbRootNode, ObjectExplorerControlLocalization.ObjectQueryCollectionNodeTitle, new ObjectExplorerNodeTag(inquiry, eObjectExplorerNode.RootObjectQuery));

				foreach (ObjectQuery query in inquiry.AQuery)
				{
					AppendObjectQueryNode(objectQueryRoot, inquiry, query);
				}
			}
			finally
			{
				objectTree.EndUpdate();
			}
		}

		private void AppendObjectQueryNode(TreeListNode objectQueryRoot, DomainObjectInquiry inquiry, ObjectQuery query)
		{
			AppendNode(objectQueryRoot, query.Code, new ObjectExplorerNodeTag(inquiry, eObjectExplorerNode.ObjectQueryConfig, query));
		}

		void ObjectInquiry_IsEditedChanged(object sender, EventArgs e)
		{
			DomainObjectInquiry senderInquiry = sender as DomainObjectInquiry;

			TreeListNode node = objectTree.FocusedNode;

			if (node == null)
				return;

			ObjectExplorerNodeTag nodeTag = node.Tag as ObjectExplorerNodeTag;

			if (senderInquiry == nodeTag.Inquiry)
				saveItem.Enabled = senderInquiry.IsModified;
		}

		void ObjectInquiry_CreateObjectCompleted(object sender, ObjectConfigArgs e)
		{
			DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			TreeListNode objectRootNode = GetRootObjectsNode(inquiry);

			AppendObjectConfigNode(objectRootNode, GetInquiry(objectRootNode), e.AObject);
		}

		void ObjectInquiry_CreateObjectQueryCompleted(object sender, ObjectQueryArgs e)
		{
			DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			TreeListNode objectQueryRootNode = GetRootObjectQueryNode(inquiry);

			AppendObjectQueryNode(objectQueryRootNode, inquiry, e.Query);
		}

		void ObjectInquiry_DeleteObjectQueryCompleted(object sender, ObjectQueryArgs e)
		{
			DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			TreeListNode queriesNode = GetRootObjectQueryNode(inquiry);
			TreeListNode deleteQueryNode = GetNodeByValue(queriesNode, e.Query);

			if (deleteQueryNode == null)
				return;

			queriesNode.Nodes.Remove(deleteQueryNode);
		}

		void ObjectInquiry_EditObjectCompleted(object sender, EditObjectConfigArgs e)
		{
			DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			TreeListNode objectConfigNode = GetObjectConfigNode(inquiry, e.AObject);
			objectConfigNode.SetValue(0, GetNodeTitle(e.AObject));
		}

		void ObjectInquiry_DeleteObjectCompleted(object sender, ObjectConfigArgs e)
		{
			DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			TreeListNode objectRootNode = GetRootObjectsNode(inquiry);

			TreeListNode objectConfigNode = GetNodeByValue(objectRootNode, e.AObject);
			if (objectConfigNode == null)
				return;

			objectRootNode.Nodes.Remove(objectConfigNode);
		}

		void ObjectInquiry_CreatePropertyCompleted(object sender, PropertyConfigArgs e)
		{
			DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			DomainObjectConfig objectConfig = inquiry.AObject[e.Property.Owner.Code];

			TreeListNode propertyCollectionNode = GetPropertiesNode(inquiry, objectConfig);
			AppendPropertyConfigNode(GetInquiry(propertyCollectionNode), propertyCollectionNode, e.Property);
		}

		void ObjectInquiry_EditPropertyCompleted(object sender, EditPropertyConfigArgs e)
		{
			DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			DomainObjectConfig objectConfig = inquiry.AObject[e.Property.Owner.Code];

			TreeListNode propertyCollectionNode = GetPropertiesNode(inquiry, objectConfig);
			TreeListNode propertyNode = GetNodeByValue(propertyCollectionNode, e.Property);

			propertyNode.SetValue(0, GetNodeTitle(e.Property));
		}

		void ObjectInquiry_DeletePropertyCompleted(object sender, PropertyConfigArgs e)
		{
			DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			DomainObjectConfig objectConfig = inquiry.AObject[e.Property.Owner.Code];

			TreeListNode propertyCollectionNode = GetPropertiesNode(inquiry, objectConfig);
			TreeListNode propertyNode = GetNodeByValue(propertyCollectionNode, e.Property);

			propertyCollectionNode.Nodes.Remove(propertyNode);
		}

		void ObjectInquiry_CreateLinkCompleted(object sender, LinkConfigArgs e)
		{			
			DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			
			TreeListNode linkCollectionNode = GetLinksNode(inquiry);
			AppendLinkConfigNode(inquiry, linkCollectionNode, e.Link);
		}

		void ObjectInquiry_EditLinkCompleted(object sender, EditLinkConfigArgs e)
		{
			//DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			//DomainObjectConfig objectConfig = inquiry.AObject[e.Link.BaseObjectCode];

			//TreeListNode linkCollectionNode = GetLinksNode(inquiry, objectConfig);
			//TreeListNode linkNode = GetNodeByValue(linkCollectionNode, e.Link);

			//linkNode.SetValue(0, GetNodeTitle(e.Link));
		}

		void ObjectInquiry_DeleteLinkCompleted(object sender, LinkConfigArgs e)
		{
			//DomainObjectInquiry inquiry = sender as DomainObjectInquiry;
			//DomainObjectConfig objectConfig = inquiry.AObject[e.Link.BaseObjectCode];

			//TreeListNode linkCollectionNode = GetLinksNode(inquiry, objectConfig);
			//TreeListNode linkNode = GetNodeByValue(linkCollectionNode, e.Link);

			//linkCollectionNode.Nodes.Remove(linkNode);
		}

		private void ShowObjectSql(ObjectSqlArgs.eKind kind)
		{
			TreeListNode node = objectTree.FocusedNode;
			ObjectExplorerNodeTag tag = node.Tag as ObjectExplorerNodeTag;
			DomainObjectConfig config = tag.Value as DomainObjectConfig;

			UI.Instance.ShowObjectSql(tag.Inquiry, config, kind);
		}

		private void menuShowSelectSQLItem_Click(object sender, EventArgs e)
		{
			try
			{
				ShowObjectSql(ObjectSqlArgs.eKind.Select);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void menuShowInsertSQLItem_Click(object sender, EventArgs e)
		{
			try
			{
				ShowObjectSql(ObjectSqlArgs.eKind.Insert);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void menuShowUpdateSQLItem_Click(object sender, EventArgs e)
		{
			try
			{
				ShowObjectSql(ObjectSqlArgs.eKind.Update);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void menuShowDeleteSQLItem_Click(object sender, EventArgs e)
		{
			try
			{
				ShowObjectSql(ObjectSqlArgs.eKind.Delete);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				ObjectExplorerNodeTag tag = objectTree.FocusedNode.Tag as ObjectExplorerNodeTag;

				switch (tag.Kind)
				{
					case eObjectExplorerNode.RootObjects:
						sourceCodeItem.Visible = false;

						createObjectConfigItem.Visible = true;
						createPropertyConfigItem.Visible = false;
						createLinkConfigItem.Visible = false;
						createObjectQueryItem.Visible = false;

						editItem.Visible = false;
						deleteItem.Visible = false;

						SQLItem.Visible = false;
						break;

					case eObjectExplorerNode.RootObjectQuery:
						sourceCodeItem.Visible = false;

						createObjectConfigItem.Visible = false;
						createPropertyConfigItem.Visible = false;
						createLinkConfigItem.Visible = false;
						createObjectQueryItem.Visible = true;

						editItem.Visible = false;
						deleteItem.Visible = false;

						SQLItem.Visible = false;
						break;

					case eObjectExplorerNode.ObjectQueryConfig:
						sourceCodeItem.Visible = false;

						createObjectConfigItem.Visible = false;
						createPropertyConfigItem.Visible = false;
						createLinkConfigItem.Visible = false;
						createObjectQueryItem.Visible = false;

						editItem.Visible = true;
						deleteItem.Visible = true;

						SQLItem.Visible = false;
						break;

					case eObjectExplorerNode.ObjectConfig:
						sourceCodeItem.Visible = true;

						createObjectConfigItem.Visible = false;
						createPropertyConfigItem.Visible = true;
						createLinkConfigItem.Visible = true;
						createObjectQueryItem.Visible = false;

						editItem.Visible = true;
						deleteItem.Visible = true;

						SQLItem.Visible = true;
						break;

					case eObjectExplorerNode.ObjectProperties:
						sourceCodeItem.Visible = false;

						createObjectConfigItem.Visible = false;
						createPropertyConfigItem.Visible = true;
						createLinkConfigItem.Visible = false;
						createObjectQueryItem.Visible = false;

						editItem.Visible = false;
						deleteItem.Visible = false;

						SQLItem.Visible = false;
						break;

					case eObjectExplorerNode.ObjectPropertyConfig:
						sourceCodeItem.Visible = false;

						createObjectConfigItem.Visible = false;
						createPropertyConfigItem.Visible = false;
						createLinkConfigItem.Visible = false;
						createObjectQueryItem.Visible = false;

						editItem.Visible = true;
						deleteItem.Visible = true;

						SQLItem.Visible = false;
						break;

					case eObjectExplorerNode.RootLinks:
						sourceCodeItem.Visible = false;

						createObjectConfigItem.Visible = false;
						createPropertyConfigItem.Visible = false;
						createLinkConfigItem.Visible = true;
						createObjectQueryItem.Visible = false;

						editItem.Visible = false;
						deleteItem.Visible = false;

						SQLItem.Visible = false;
						break;

					case eObjectExplorerNode.LinkConfig:
						sourceCodeItem.Visible = false;

						createObjectConfigItem.Visible = false;
						createPropertyConfigItem.Visible = false;
						createLinkConfigItem.Visible = false;
						createObjectQueryItem.Visible = false;

						editItem.Visible = true;
						deleteItem.Visible = true;

						SQLItem.Visible = false;
						break;

					default:
						e.Cancel = true;
						break;
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void objectTree_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button != MouseButtons.Right)
					return;

				TreeListHitInfo info = objectTree.CalcHitInfo(e.Location);
				if (info.HitInfoType == HitInfoType.Cell)
				{
					objectTree.FocusedNode = info.Node;
					contextMenuStrip.Show(objectTree, e.Location);
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void ObjectExplorerControl_Load(object sender, EventArgs e)
		{
			if (IsRuntime)
			{
				BuildConnectionMenu();

				UI.Instance.NewConnectionOpened += Instance_NewConnectionOpened;
				UI.Instance.ConnectionPluginChanged += Instance_ConnectionPluginChanged;
			}
		}

		void Instance_ConnectionPluginChanged(object sender, EventArgs e)
		{
			BuildConnectionMenu();
		}

		private void BuildConnectionMenu()
		{
			connectionItem.BeginUpdate();

			List<BarButtonItemLink> itemsForRemove = new List<BarButtonItemLink>();
			foreach (BarButtonItemLink link in connectionItem.ItemLinks)
			{
				BarButtonItem item = link.Item;
				if (item.Tag is IDbCommonConnectionPlugin)
					itemsForRemove.Add(link);
			}

			itemsForRemove.ForEach(item => connectionItem.RemoveLink(item));

			foreach (IDbCommonConnectionPlugin data in ConfigInquiry.Instance.ConnectPlugin)
			{
				BarButtonItem item = new BarButtonItem(barManager, data.ConnectionName)
				{
					Tag = data
				};
				item.ItemClick += item_ItemClick;

				connectionItem.AddItem(item);
			}

			connectionItem.EndUpdate();
		}

		void Instance_NewConnectionOpened(object sender, UIArgs e)
		{
			try
			{
				BindData(e.Inquiry);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		void item_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				UI.Instance.ShowNewConnectionForm(e.Item.Tag as IDbCommonConnectionPlugin);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void refreshMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				throw new NotImplementedException();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void createObjectConfigItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeListNode node = objectTree.FocusedNode;
				ObjectExplorerNodeTag tag = node.Tag as ObjectExplorerNodeTag;

				UI.Instance.EditObjectConfig(tag.Inquiry);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void editItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeListNode node = objectTree.FocusedNode;
				ObjectExplorerNodeTag tag = node.Tag as ObjectExplorerNodeTag;

				Type valueType = tag.Value.GetType();
				if (valueType == typeof(DomainObjectConfig))
				{
					UI.Instance.EditObjectConfig(tag.Inquiry, tag.Value as DomainObjectConfig);
				}
				else if (valueType == typeof(DomainPropertyConfig))
				{
					UI.Instance.EditPropertyConfig(tag.Inquiry, tag.Value as DomainPropertyConfig);
				}
				else if (valueType == typeof(DomainLinkConfig))
				{
					UI.Instance.EditLinkConfig(tag.Inquiry, tag.Value as DomainLinkConfig);
				}
				else
				{
					XtraMessageBox.Show(String.Format(ObjectExplorerControlLocalization.EditTypeNotSupportedError, valueType));
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void deleteItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeListNode node = objectTree.FocusedNode;
				ObjectExplorerNodeTag tag = node.Tag as ObjectExplorerNodeTag;

				Type valueType = tag.Value.GetType();
				if (valueType == typeof(DomainObjectConfig))
				{
					UI.Instance.DeleteObjectConfig(tag.Inquiry, tag.Value as DomainObjectConfig);
				}
				else if (valueType == typeof(DomainPropertyConfig))
				{
					UI.Instance.DeletePropertyConfig(tag.Inquiry, tag.Value as DomainPropertyConfig);
				}
				else if (valueType == typeof(DomainLinkConfig))
				{
					UI.Instance.DeleteLinkConfig(tag.Inquiry, tag.Value as DomainLinkConfig);
				}
				else if (valueType == typeof(ObjectQuery))
				{
					UI.Instance.DeleteObjectQuery(tag.Inquiry, tag.Value as ObjectQuery);
				}
				else
				{
					XtraMessageBox.Show(String.Format(ObjectExplorerControlLocalization.DeleteTypeNotSupportedError, valueType));
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void createPropertyConfigItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeListNode node = objectTree.FocusedNode;
				ObjectExplorerNodeTag tag = node.Tag as ObjectExplorerNodeTag;

				UI.Instance.CreatePropertyConfig(tag.Inquiry, tag.Value as DomainObjectConfig);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void createLinkConfigItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeListNode node = objectTree.FocusedNode;
				ObjectExplorerNodeTag tag = node.Tag as ObjectExplorerNodeTag;

				UI.Instance.CreateLinkConfig(tag.Inquiry, tag.Value as DomainObjectConfig);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void AddProfileItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (SettingsForm form = new SettingsForm())
				{
					form.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void sourceCodeItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeListNode node = objectTree.FocusedNode;
				ObjectExplorerNodeTag tag = node.Tag as ObjectExplorerNodeTag;

				string sourceCode = String.Empty;
				
				switch (tag.Kind)
				{
					case eObjectExplorerNode.ObjectConfig:
						sourceCode = SourceCodeGenerator.DomainObjectCode(tag.Inquiry, tag.Value as DomainObjectConfig);
						break;

					default:
						return;
				}

				UI.Instance.SourceCode(sourceCode);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void objectTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
		{
			if (e.Node == null)
			{
				disconnectItem.Enabled = false;
				UI.Instance.ShowProperty(null, null);
			}

			ObjectExplorerNodeTag nodeTag = e.Node.Tag as ObjectExplorerNodeTag;

			saveItem.Enabled = nodeTag.Inquiry.IsModified;
			disconnectItem.Enabled = true;

			UI.Instance.ShowProperty(nodeTag.Value, nodeTag.Inquiry);
		}

		private void saveItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				TreeListNode node = objectTree.FocusedNode;
				if (node == null)
					return;

				ObjectExplorerNodeTag nodeTag = node.Tag as ObjectExplorerNodeTag;
				nodeTag.Inquiry.Save();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void createObjectQueryItem_Click(object sender, EventArgs e)
		{
			try
			{
				TreeListNode node = objectTree.FocusedNode;
				ObjectExplorerNodeTag tag = node.Tag as ObjectExplorerNodeTag;

				UI.Instance.CreateObjectQuery(tag.Inquiry);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void objectTree_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				TreeListHitInfo hitInfo = objectTree.CalcHitInfo(e.Location);
				if (hitInfo.Node == null)
					return;

				ObjectExplorerNodeTag tag = hitInfo.Node.Tag as ObjectExplorerNodeTag;
				if (tag == null)
					return;

				switch (tag.Kind)
				{
					case eObjectExplorerNode.ObjectConfig:
						UI.Instance.EditObjectConfig(tag.Inquiry, tag.Value as DomainObjectConfig);
						break;

					case eObjectExplorerNode.LinkConfig:
						UI.Instance.EditLinkConfig(tag.Inquiry, tag.Value as DomainLinkConfig);
						break;

					case eObjectExplorerNode.ObjectPropertyConfig:
						UI.Instance.EditPropertyConfig(tag.Inquiry, tag.Value as DomainPropertyConfig);
						break;

					case eObjectExplorerNode.ObjectQueryConfig:
						UI.Instance.EditObjectQuery(tag.Inquiry, tag.Value as ObjectQuery);
						break;
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void disconnectItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				TreeListNode node = objectTree.FocusedNode;
				if (node == null)
					return;

				ObjectExplorerNodeTag nodeTag = node.Tag as ObjectExplorerNodeTag;
				DomainObjectInquiry inquiry = nodeTag.Inquiry;

				CloseConnection(inquiry);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void CloseConnection(DomainObjectInquiry inquiry, bool deleteNodeFromTree = true)
		{
			if (inquiry.IsModified)
			{
				if (XtraMessageBox.Show(ObjectExplorerControlLocalization.SaveChangesQuestion, ParentForm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					inquiry.Save();
			}

			if (deleteNodeFromTree)
			{
				TreeListNode parentNode = GetParentNode(inquiry);
				if (parentNode == null)
					return;

				objectTree.Nodes.Remove(parentNode);
			}
		}

		public void CloseAllConnections()
		{
			foreach (TreeListNode node in objectTree.Nodes)
			{
				ObjectExplorerNodeTag nodeTag = node.Tag as ObjectExplorerNodeTag;
				DomainObjectInquiry inquiry = nodeTag.Inquiry;
				CloseConnection(inquiry, false);
			}
		}
	}

	enum eObjectExplorerNode
	{
		Database,
		RootObjects,
		ObjectConfig,
		ObjectProperties,
		ObjectPropertyConfig,
		RootLinks,
		LinkConfig,
		RootObjectQuery,
		ObjectQueryConfig
	}

	class ObjectExplorerNodeTag
	{
		public DomainObjectInquiry Inquiry { get; private set; }
		public eObjectExplorerNode Kind { get; private set; }
		public object Value { get; private set; }

		public ObjectExplorerNodeTag(DomainObjectInquiry inquiry, eObjectExplorerNode kind, object value = null)
		{
			Inquiry = inquiry;
			Kind = kind;
			Value = value;
		}
	}
}
