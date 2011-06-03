namespace DomainCommonSE.ConfigLibrary
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.barManager = new DevExpress.XtraBars.BarManager(this.components);
			this.mainButtonBar = new DevExpress.XtraBars.Bar();
			this.barBtnSaveSession = new DevExpress.XtraBars.BarButtonItem();
			this.barBtnCancelSession = new DevExpress.XtraBars.BarButtonItem();
			this.mainMenuBar = new DevExpress.XtraBars.Bar();
			this.mainMenuSubItem = new DevExpress.XtraBars.BarSubItem();
			this.NewConnectionButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.SettingsButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.ExitButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
			this.btnShowDBExplorer = new DevExpress.XtraBars.BarButtonItem();
			this.btnShowPropertiesWindow = new DevExpress.XtraBars.BarButtonItem();
			this.statusBar = new DevExpress.XtraBars.Bar();
			this.objectQueryBar = new DevExpress.XtraBars.Bar();
			this.btnSaveObjectQuery = new DevExpress.XtraBars.BarButtonItem();
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.btnNewQuery = new DevExpress.XtraBars.BarButtonItem();
			this.queryBar = new DevExpress.XtraBars.Bar();
			this.btnExecuteQuery = new DevExpress.XtraBars.BarButtonItem();
			this.btnCommitQuery = new DevExpress.XtraBars.BarButtonItem();
			this.btnRollbackQuery = new DevExpress.XtraBars.BarButtonItem();
			this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
			this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
			this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
			this.objectDockPanel = new DevExpress.XtraBars.Docking.DockPanel();
			this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
			this.objectExplorerControl = new DomainCommonSE.ConfigLibrary.ObjectExplorerControl();
			this.propertiesDockPanel = new DevExpress.XtraBars.Docking.DockPanel();
			this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
			this.propertyControl = new DomainCommonSE.ConfigLibrary.PropertyControl();
			this.tabControl = new DevExpress.XtraTab.XtraTabControl();
			this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
			((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
			this.objectDockPanel.SuspendLayout();
			this.dockPanel1_Container.SuspendLayout();
			this.propertiesDockPanel.SuspendLayout();
			this.controlContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
			this.SuspendLayout();
			// 
			// barManager
			// 
			this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.mainButtonBar,
            this.mainMenuBar,
            this.statusBar,
            this.objectQueryBar,
            this.bar1,
            this.queryBar});
			this.barManager.Controller = this.barAndDockingController1;
			this.barManager.DockControls.Add(this.barDockControlTop);
			this.barManager.DockControls.Add(this.barDockControlBottom);
			this.barManager.DockControls.Add(this.barDockControlLeft);
			this.barManager.DockControls.Add(this.barDockControlRight);
			this.barManager.Form = this;
			this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barBtnSaveSession,
            this.barBtnCancelSession,
            this.mainMenuSubItem,
            this.SettingsButtonItem,
            this.ExitButtonItem,
            this.NewConnectionButtonItem,
            this.btnSaveObjectQuery,
            this.btnNewQuery,
            this.barSubItem1,
            this.btnShowDBExplorer,
            this.btnShowPropertiesWindow,
            this.btnExecuteQuery,
            this.btnCommitQuery,
            this.btnRollbackQuery});
			this.barManager.MainMenu = this.mainMenuBar;
			this.barManager.MaxItemId = 18;
			this.barManager.StatusBar = this.statusBar;
			// 
			// mainButtonBar
			// 
			this.mainButtonBar.BarName = "Tools";
			this.mainButtonBar.DockCol = 0;
			this.mainButtonBar.DockRow = 1;
			this.mainButtonBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.mainButtonBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSaveSession),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnCancelSession)});
			resources.ApplyResources(this.mainButtonBar, "mainButtonBar");
			// 
			// barBtnSaveSession
			// 
			resources.ApplyResources(this.barBtnSaveSession, "barBtnSaveSession");
			this.barBtnSaveSession.Id = 3;
			this.barBtnSaveSession.ImageIndex = 1;
			this.barBtnSaveSession.Name = "barBtnSaveSession";
			this.barBtnSaveSession.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnSaveSession_ItemClick);
			// 
			// barBtnCancelSession
			// 
			resources.ApplyResources(this.barBtnCancelSession, "barBtnCancelSession");
			this.barBtnCancelSession.Id = 4;
			this.barBtnCancelSession.ImageIndex = 2;
			this.barBtnCancelSession.Name = "barBtnCancelSession";
			// 
			// mainMenuBar
			// 
			this.mainMenuBar.BarName = "Main menu";
			this.mainMenuBar.DockCol = 0;
			this.mainMenuBar.DockRow = 0;
			this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mainMenuSubItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
			this.mainMenuBar.OptionsBar.MultiLine = true;
			this.mainMenuBar.OptionsBar.UseWholeRow = true;
			resources.ApplyResources(this.mainMenuBar, "mainMenuBar");
			// 
			// mainMenuSubItem
			// 
			resources.ApplyResources(this.mainMenuSubItem, "mainMenuSubItem");
			this.mainMenuSubItem.Id = 6;
			this.mainMenuSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.NewConnectionButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.SettingsButtonItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ExitButtonItem, true)});
			this.mainMenuSubItem.Name = "mainMenuSubItem";
			// 
			// NewConnectionButtonItem
			// 
			resources.ApplyResources(this.NewConnectionButtonItem, "NewConnectionButtonItem");
			this.NewConnectionButtonItem.Id = 9;
			this.NewConnectionButtonItem.Name = "NewConnectionButtonItem";
			this.NewConnectionButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewConnectionButtonItem_ItemClick);
			// 
			// SettingsButtonItem
			// 
			resources.ApplyResources(this.SettingsButtonItem, "SettingsButtonItem");
			this.SettingsButtonItem.Id = 7;
			this.SettingsButtonItem.Name = "SettingsButtonItem";
			this.SettingsButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SettingsButtonItem_ItemClick);
			// 
			// ExitButtonItem
			// 
			resources.ApplyResources(this.ExitButtonItem, "ExitButtonItem");
			this.ExitButtonItem.Id = 8;
			this.ExitButtonItem.Name = "ExitButtonItem";
			this.ExitButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExitButtonItem_ItemClick);
			// 
			// barSubItem1
			// 
			resources.ApplyResources(this.barSubItem1, "barSubItem1");
			this.barSubItem1.Id = 12;
			this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShowDBExplorer),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnShowPropertiesWindow)});
			this.barSubItem1.Name = "barSubItem1";
			// 
			// btnShowDBExplorer
			// 
			resources.ApplyResources(this.btnShowDBExplorer, "btnShowDBExplorer");
			this.btnShowDBExplorer.Id = 13;
			this.btnShowDBExplorer.Name = "btnShowDBExplorer";
			this.btnShowDBExplorer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowDBExplorer_ItemClick);
			// 
			// btnShowPropertiesWindow
			// 
			resources.ApplyResources(this.btnShowPropertiesWindow, "btnShowPropertiesWindow");
			this.btnShowPropertiesWindow.Id = 14;
			this.btnShowPropertiesWindow.Name = "btnShowPropertiesWindow";
			this.btnShowPropertiesWindow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowPropertiesWindow_ItemClick);
			// 
			// statusBar
			// 
			this.statusBar.BarName = "Status bar";
			this.statusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
			this.statusBar.DockCol = 0;
			this.statusBar.DockRow = 0;
			this.statusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
			this.statusBar.OptionsBar.AllowQuickCustomization = false;
			this.statusBar.OptionsBar.DrawDragBorder = false;
			this.statusBar.OptionsBar.UseWholeRow = true;
			resources.ApplyResources(this.statusBar, "statusBar");
			// 
			// objectQueryBar
			// 
			this.objectQueryBar.BarName = "ObjectQuery bar";
			this.objectQueryBar.DockCol = 3;
			this.objectQueryBar.DockRow = 1;
			this.objectQueryBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.objectQueryBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveObjectQuery)});
			this.objectQueryBar.Offset = 524;
			resources.ApplyResources(this.objectQueryBar, "objectQueryBar");
			this.objectQueryBar.Visible = false;
			// 
			// btnSaveObjectQuery
			// 
			resources.ApplyResources(this.btnSaveObjectQuery, "btnSaveObjectQuery");
			this.btnSaveObjectQuery.Id = 10;
			this.btnSaveObjectQuery.Name = "btnSaveObjectQuery";
			// 
			// bar1
			// 
			this.bar1.BarName = "Custom 6";
			this.bar1.DockCol = 1;
			this.bar1.DockRow = 1;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewQuery)});
			this.bar1.Offset = 102;
			resources.ApplyResources(this.bar1, "bar1");
			// 
			// btnNewQuery
			// 
			resources.ApplyResources(this.btnNewQuery, "btnNewQuery");
			this.btnNewQuery.Id = 11;
			this.btnNewQuery.Name = "btnNewQuery";
			this.btnNewQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewQuery_ItemClick);
			// 
			// queryBar
			// 
			this.queryBar.BarName = "Query bar";
			this.queryBar.DockCol = 2;
			this.queryBar.DockRow = 1;
			this.queryBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.queryBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExecuteQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCommitQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRollbackQuery)});
			this.queryBar.Offset = 232;
			resources.ApplyResources(this.queryBar, "queryBar");
			this.queryBar.Visible = false;
			// 
			// btnExecuteQuery
			// 
			resources.ApplyResources(this.btnExecuteQuery, "btnExecuteQuery");
			this.btnExecuteQuery.Id = 15;
			this.btnExecuteQuery.Name = "btnExecuteQuery";
			this.btnExecuteQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExecuteQuery_ItemClick);
			// 
			// btnCommitQuery
			// 
			resources.ApplyResources(this.btnCommitQuery, "btnCommitQuery");
			this.btnCommitQuery.Id = 16;
			this.btnCommitQuery.Name = "btnCommitQuery";
			this.btnCommitQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCommitQuery_ItemClick);
			// 
			// btnRollbackQuery
			// 
			resources.ApplyResources(this.btnRollbackQuery, "btnRollbackQuery");
			this.btnRollbackQuery.Id = 17;
			this.btnRollbackQuery.Name = "btnRollbackQuery";
			this.btnRollbackQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRollbackQuery_ItemClick);
			// 
			// barAndDockingController1
			// 
			this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
			// 
			// barButtonItem1
			// 
			resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
			this.barButtonItem1.Id = 0;
			this.barButtonItem1.Name = "barButtonItem1";
			// 
			// barButtonItem2
			// 
			resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
			this.barButtonItem2.Id = 1;
			this.barButtonItem2.Name = "barButtonItem2";
			// 
			// dockManager
			// 
			this.dockManager.Controller = this.barAndDockingController1;
			this.dockManager.Form = this;
			this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.objectDockPanel,
            this.propertiesDockPanel});
			this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
			// 
			// objectDockPanel
			// 
			this.objectDockPanel.Controls.Add(this.dockPanel1_Container);
			this.objectDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
			this.objectDockPanel.ID = new System.Guid("f7e35330-3832-493e-95ec-64df0c366c68");
			resources.ApplyResources(this.objectDockPanel, "objectDockPanel");
			this.objectDockPanel.Name = "objectDockPanel";
			this.objectDockPanel.Options.AllowDockTop = false;
			this.objectDockPanel.OriginalSize = new System.Drawing.Size(300, 200);
			// 
			// dockPanel1_Container
			// 
			this.dockPanel1_Container.Controls.Add(this.objectExplorerControl);
			resources.ApplyResources(this.dockPanel1_Container, "dockPanel1_Container");
			this.dockPanel1_Container.Name = "dockPanel1_Container";
			// 
			// objectExplorerControl
			// 
			resources.ApplyResources(this.objectExplorerControl, "objectExplorerControl");
			this.objectExplorerControl.Name = "objectExplorerControl";
			// 
			// propertiesDockPanel
			// 
			this.propertiesDockPanel.Controls.Add(this.controlContainer1);
			this.propertiesDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
			this.propertiesDockPanel.ID = new System.Guid("b8a7d8bf-6df5-4328-a530-2253bb8d5d01");
			resources.ApplyResources(this.propertiesDockPanel, "propertiesDockPanel");
			this.propertiesDockPanel.Name = "propertiesDockPanel";
			this.propertiesDockPanel.Options.AllowDockTop = false;
			this.propertiesDockPanel.OriginalSize = new System.Drawing.Size(400, 200);
			// 
			// controlContainer1
			// 
			this.controlContainer1.Controls.Add(this.propertyControl);
			resources.ApplyResources(this.controlContainer1, "controlContainer1");
			this.controlContainer1.Name = "controlContainer1";
			// 
			// propertyControl
			// 
			resources.ApplyResources(this.propertyControl, "propertyControl");
			this.propertyControl.Name = "propertyControl";
			// 
			// tabControl
			// 
			resources.ApplyResources(this.tabControl, "tabControl");
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControl_SelectedPageChanged);
			this.tabControl.CloseButtonClick += new System.EventHandler(this.tabControl_CloseButtonClick);
			// 
			// defaultLookAndFeel
			// 
			this.defaultLookAndFeel.LookAndFeel.SkinName = "Blue";
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.objectDockPanel);
			this.Controls.Add(this.propertiesDockPanel);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "MainForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewMainForm_FormClosing);
			this.Load += new System.EventHandler(this.NewMainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
			this.objectDockPanel.ResumeLayout(false);
			this.dockPanel1_Container.ResumeLayout(false);
			this.propertiesDockPanel.ResumeLayout(false);
			this.controlContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraBars.BarManager barManager;
		private DevExpress.XtraBars.Bar mainButtonBar;
		private DevExpress.XtraBars.Bar mainMenuBar;
		private DevExpress.XtraBars.Bar statusBar;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.Docking.DockManager dockManager;
		private DevExpress.XtraBars.BarButtonItem barButtonItem1;
		private DevExpress.XtraBars.BarButtonItem barButtonItem2;
		private DevExpress.XtraBars.Docking.DockPanel objectDockPanel;
		private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
		private ObjectExplorerControl objectExplorerControl;
		private DevExpress.XtraTab.XtraTabControl tabControl;
		private DevExpress.XtraBars.BarButtonItem barBtnSaveSession;
		private DevExpress.XtraBars.BarButtonItem barBtnCancelSession;
		private DevExpress.XtraBars.Bar objectQueryBar;
		private DevExpress.XtraBars.BarSubItem mainMenuSubItem;
		private DevExpress.XtraBars.BarButtonItem SettingsButtonItem;
		private DevExpress.XtraBars.BarButtonItem ExitButtonItem;
		private DevExpress.XtraBars.BarButtonItem NewConnectionButtonItem;
		private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
		private DevExpress.XtraBars.Docking.DockPanel propertiesDockPanel;
		private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
		private PropertyControl propertyControl;
		private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
		private DevExpress.XtraBars.BarButtonItem btnSaveObjectQuery;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem btnNewQuery;
		private DevExpress.XtraBars.BarSubItem barSubItem1;
		private DevExpress.XtraBars.BarButtonItem btnShowDBExplorer;
		private DevExpress.XtraBars.BarButtonItem btnShowPropertiesWindow;
		private DevExpress.XtraBars.Bar queryBar;
		private DevExpress.XtraBars.BarButtonItem btnExecuteQuery;
		private DevExpress.XtraBars.BarButtonItem btnCommitQuery;
		private DevExpress.XtraBars.BarButtonItem btnRollbackQuery;
	}
}