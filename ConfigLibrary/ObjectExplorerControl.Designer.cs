namespace DomainCommonSE.ConfigLibrary
{
	partial class ObjectExplorerControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectExplorerControl));
			this.objectTree = new DevExpress.XtraTreeList.TreeList();
			this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.sourceCodeItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createObjectConfigItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createLinkConfigItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createPropertyConfigItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createObjectQueryItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SQLItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowSelectSQLItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowInsertSQLItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowUpdateSQLItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuShowDeleteSQLItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.barManager = new DevExpress.XtraBars.BarManager(this.components);
			this.bar2 = new DevExpress.XtraBars.Bar();
			this.connectionItem = new DevExpress.XtraBars.BarSubItem();
			this.AddProfileItem = new DevExpress.XtraBars.BarButtonItem();
			this.disconnectItem = new DevExpress.XtraBars.BarButtonItem();
			this.saveItem = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			((System.ComponentModel.ISupportInitialize)(this.objectTree)).BeginInit();
			this.contextMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
			this.SuspendLayout();
			// 
			// objectTree
			// 
			resources.ApplyResources(this.objectTree, "objectTree");
			this.objectTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
			this.objectTree.DataMember = global::DomainCommonSE.ConfigLibrary.Localization.EditLinkFormLocalization.EnterReverseLinkCodeMessage;
			this.objectTree.Name = "objectTree";
			this.objectTree.OptionsBehavior.AllowIncrementalSearch = true;
			this.objectTree.OptionsBehavior.AutoChangeParent = false;
			this.objectTree.OptionsBehavior.AutoMoveRowFocus = true;
			this.objectTree.OptionsBehavior.Editable = false;
			this.objectTree.OptionsBehavior.EnableFiltering = true;
			this.objectTree.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.objectTree.OptionsView.ShowColumns = false;
			this.objectTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.objectTree_FocusedNodeChanged);
			this.objectTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.objectTree_MouseDoubleClick);
			this.objectTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.objectTree_MouseUp);
			// 
			// treeListColumn1
			// 
			resources.ApplyResources(this.treeListColumn1, "treeListColumn1");
			this.treeListColumn1.CustomizationCaption = global::DomainCommonSE.ConfigLibrary.Localization.EditLinkFormLocalization.EnterReverseLinkCodeMessage;
			this.treeListColumn1.FieldName = "Value";
			this.treeListColumn1.Name = "treeListColumn1";
			// 
			// contextMenuStrip
			// 
			resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceCodeItem,
            this.createObjectConfigItem,
            this.createLinkConfigItem,
            this.createPropertyConfigItem,
            this.createObjectQueryItem,
            this.editItem,
            this.deleteItem,
            this.SQLItem,
            this.refreshSeparator,
            this.refreshMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
			// 
			// sourceCodeItem
			// 
			resources.ApplyResources(this.sourceCodeItem, "sourceCodeItem");
			this.sourceCodeItem.Name = "sourceCodeItem";
			this.sourceCodeItem.Click += new System.EventHandler(this.sourceCodeItem_Click);
			// 
			// createObjectConfigItem
			// 
			resources.ApplyResources(this.createObjectConfigItem, "createObjectConfigItem");
			this.createObjectConfigItem.Name = "createObjectConfigItem";
			this.createObjectConfigItem.Click += new System.EventHandler(this.createObjectConfigItem_Click);
			// 
			// createLinkConfigItem
			// 
			resources.ApplyResources(this.createLinkConfigItem, "createLinkConfigItem");
			this.createLinkConfigItem.Name = "createLinkConfigItem";
			this.createLinkConfigItem.Click += new System.EventHandler(this.createLinkConfigItem_Click);
			// 
			// createPropertyConfigItem
			// 
			resources.ApplyResources(this.createPropertyConfigItem, "createPropertyConfigItem");
			this.createPropertyConfigItem.Name = "createPropertyConfigItem";
			this.createPropertyConfigItem.Click += new System.EventHandler(this.createPropertyConfigItem_Click);
			// 
			// createObjectQueryItem
			// 
			resources.ApplyResources(this.createObjectQueryItem, "createObjectQueryItem");
			this.createObjectQueryItem.Name = "createObjectQueryItem";
			this.createObjectQueryItem.Click += new System.EventHandler(this.createObjectQueryItem_Click);
			// 
			// editItem
			// 
			resources.ApplyResources(this.editItem, "editItem");
			this.editItem.Name = "editItem";
			this.editItem.Click += new System.EventHandler(this.editItem_Click);
			// 
			// deleteItem
			// 
			resources.ApplyResources(this.deleteItem, "deleteItem");
			this.deleteItem.Name = "deleteItem";
			this.deleteItem.Click += new System.EventHandler(this.deleteItem_Click);
			// 
			// SQLItem
			// 
			resources.ApplyResources(this.SQLItem, "SQLItem");
			this.SQLItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowSelectSQLItem,
            this.menuShowInsertSQLItem,
            this.menuShowUpdateSQLItem,
            this.menuShowDeleteSQLItem});
			this.SQLItem.Name = "SQLItem";
			// 
			// menuShowSelectSQLItem
			// 
			resources.ApplyResources(this.menuShowSelectSQLItem, "menuShowSelectSQLItem");
			this.menuShowSelectSQLItem.Name = "menuShowSelectSQLItem";
			this.menuShowSelectSQLItem.Click += new System.EventHandler(this.menuShowSelectSQLItem_Click);
			// 
			// menuShowInsertSQLItem
			// 
			resources.ApplyResources(this.menuShowInsertSQLItem, "menuShowInsertSQLItem");
			this.menuShowInsertSQLItem.Name = "menuShowInsertSQLItem";
			this.menuShowInsertSQLItem.Click += new System.EventHandler(this.menuShowInsertSQLItem_Click);
			// 
			// menuShowUpdateSQLItem
			// 
			resources.ApplyResources(this.menuShowUpdateSQLItem, "menuShowUpdateSQLItem");
			this.menuShowUpdateSQLItem.Name = "menuShowUpdateSQLItem";
			this.menuShowUpdateSQLItem.Click += new System.EventHandler(this.menuShowUpdateSQLItem_Click);
			// 
			// menuShowDeleteSQLItem
			// 
			resources.ApplyResources(this.menuShowDeleteSQLItem, "menuShowDeleteSQLItem");
			this.menuShowDeleteSQLItem.Name = "menuShowDeleteSQLItem";
			this.menuShowDeleteSQLItem.Click += new System.EventHandler(this.menuShowDeleteSQLItem_Click);
			// 
			// refreshSeparator
			// 
			resources.ApplyResources(this.refreshSeparator, "refreshSeparator");
			this.refreshSeparator.Name = "refreshSeparator";
			// 
			// refreshMenuItem
			// 
			resources.ApplyResources(this.refreshMenuItem, "refreshMenuItem");
			this.refreshMenuItem.Name = "refreshMenuItem";
			this.refreshMenuItem.Click += new System.EventHandler(this.refreshMenuItem_Click);
			// 
			// barManager
			// 
			this.barManager.AllowCustomization = false;
			this.barManager.AllowMoveBarOnToolbar = false;
			this.barManager.AllowQuickCustomization = false;
			this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
			this.barManager.DockControls.Add(this.barDockControlTop);
			this.barManager.DockControls.Add(this.barDockControlBottom);
			this.barManager.DockControls.Add(this.barDockControlLeft);
			this.barManager.DockControls.Add(this.barDockControlRight);
			this.barManager.Form = this;
			this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.connectionItem,
            this.AddProfileItem,
            this.disconnectItem,
            this.saveItem});
			this.barManager.MainMenu = this.bar2;
			this.barManager.MaxItemId = 6;
			// 
			// bar2
			// 
			this.bar2.BarName = "Main menu";
			this.bar2.DockCol = 0;
			this.bar2.DockRow = 0;
			this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.connectionItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.disconnectItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.saveItem)});
			this.bar2.OptionsBar.AllowQuickCustomization = false;
			this.bar2.OptionsBar.MultiLine = true;
			this.bar2.OptionsBar.UseWholeRow = true;
			resources.ApplyResources(this.bar2, "bar2");
			// 
			// connectionItem
			// 
			resources.ApplyResources(this.connectionItem, "connectionItem");
			this.connectionItem.Hint = global::DomainCommonSE.ConfigLibrary.Localization.EditLinkFormLocalization.EnterReverseLinkCodeMessage;
			this.connectionItem.Id = 0;
			this.connectionItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.AddProfileItem, true)});
			this.connectionItem.Name = "connectionItem";
			// 
			// AddProfileItem
			// 
			resources.ApplyResources(this.AddProfileItem, "AddProfileItem");
			this.AddProfileItem.Hint = global::DomainCommonSE.ConfigLibrary.Localization.EditLinkFormLocalization.EnterReverseLinkCodeMessage;
			this.AddProfileItem.Id = 3;
			this.AddProfileItem.Name = "AddProfileItem";
			this.AddProfileItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AddProfileItem_ItemClick);
			// 
			// disconnectItem
			// 
			resources.ApplyResources(this.disconnectItem, "disconnectItem");
			this.disconnectItem.Enabled = false;
			this.disconnectItem.Hint = global::DomainCommonSE.ConfigLibrary.Localization.EditLinkFormLocalization.EnterReverseLinkCodeMessage;
			this.disconnectItem.Id = 4;
			this.disconnectItem.Name = "disconnectItem";
			this.disconnectItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.disconnectItem_ItemClick);
			// 
			// saveItem
			// 
			resources.ApplyResources(this.saveItem, "saveItem");
			this.saveItem.Enabled = false;
			this.saveItem.Hint = global::DomainCommonSE.ConfigLibrary.Localization.EditLinkFormLocalization.EnterReverseLinkCodeMessage;
			this.saveItem.Id = 5;
			this.saveItem.Name = "saveItem";
			this.saveItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveItem_ItemClick);
			// 
			// barDockControlTop
			// 
			resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
			// 
			// barDockControlBottom
			// 
			resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
			// 
			// barDockControlLeft
			// 
			resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
			// 
			// barDockControlRight
			// 
			resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
			// 
			// ObjectExplorerControl
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.objectTree);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "ObjectExplorerControl";
			this.Load += new System.EventHandler(this.ObjectExplorerControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.objectTree)).EndInit();
			this.contextMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem SQLItem;
		private System.Windows.Forms.ToolStripMenuItem menuShowDeleteSQLItem;
		private System.Windows.Forms.ToolStripMenuItem menuShowSelectSQLItem;
		private System.Windows.Forms.ToolStripMenuItem menuShowInsertSQLItem;
		private System.Windows.Forms.ToolStripMenuItem menuShowUpdateSQLItem;
		private DevExpress.XtraTreeList.TreeList objectTree;
		private DevExpress.XtraBars.BarManager barManager;
		private DevExpress.XtraBars.Bar bar2;
		private DevExpress.XtraBars.BarSubItem connectionItem;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private System.Windows.Forms.ToolStripSeparator refreshSeparator;
		private System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createObjectConfigItem;
		private System.Windows.Forms.ToolStripMenuItem createObjectQueryItem;
		private System.Windows.Forms.ToolStripMenuItem editItem;
		private System.Windows.Forms.ToolStripMenuItem deleteItem;
		private System.Windows.Forms.ToolStripMenuItem createPropertyConfigItem;
		private System.Windows.Forms.ToolStripMenuItem createLinkConfigItem;
		private DevExpress.XtraBars.BarButtonItem AddProfileItem;
		private System.Windows.Forms.ToolStripMenuItem sourceCodeItem;
		private DevExpress.XtraBars.BarButtonItem disconnectItem;
		private DevExpress.XtraBars.BarButtonItem saveItem;
	}
}
