namespace DomainCommonSE.ConfigLibrary
{
	partial class ConnectForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnDeployInquiryScheme = new DevExpress.XtraEditors.SimpleButton();
			this.dbGroup = new DevExpress.XtraEditors.GroupControl();
			this.btnDeploySequenceScheme = new DevExpress.XtraEditors.SimpleButton();
			this.dbConnectControl = new DomainCommonSE.ConfigLibrary.DbConnectControl();
			this.inquiryGroup = new DevExpress.XtraEditors.GroupControl();
			this.inquiryProviderControlPanel = new DevExpress.XtraEditors.PanelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.txtInquiryProvider = new DevExpress.XtraEditors.ComboBoxEdit();
			this.checkInquirySameAsDb = new DevExpress.XtraEditors.CheckEdit();
			((System.ComponentModel.ISupportInitialize)(this.dbGroup)).BeginInit();
			this.dbGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.inquiryGroup)).BeginInit();
			this.inquiryGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.inquiryProviderControlPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInquiryProvider.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkInquirySameAsDb.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			resources.ApplyResources(this.btnOk, "btnOk");
			this.btnOk.Name = "btnOk";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			// 
			// btnDeployInquiryScheme
			// 
			resources.ApplyResources(this.btnDeployInquiryScheme, "btnDeployInquiryScheme");
			this.btnDeployInquiryScheme.Name = "btnDeployInquiryScheme";
			this.btnDeployInquiryScheme.Click += new System.EventHandler(this.btnDeployDB_Click);
			// 
			// dbGroup
			// 
			resources.ApplyResources(this.dbGroup, "dbGroup");
			this.dbGroup.Controls.Add(this.btnDeploySequenceScheme);
			this.dbGroup.Controls.Add(this.dbConnectControl);
			this.dbGroup.Name = "dbGroup";
			// 
			// btnDeploySequenceScheme
			// 
			resources.ApplyResources(this.btnDeploySequenceScheme, "btnDeploySequenceScheme");
			this.btnDeploySequenceScheme.Name = "btnDeploySequenceScheme";
			this.btnDeploySequenceScheme.Click += new System.EventHandler(this.btnDeploySequenceScheme_Click);
			// 
			// dbConnectControl
			// 
			resources.ApplyResources(this.dbConnectControl, "dbConnectControl");
			this.dbConnectControl.Name = "dbConnectControl";
			// 
			// inquiryGroup
			// 
			resources.ApplyResources(this.inquiryGroup, "inquiryGroup");
			this.inquiryGroup.Controls.Add(this.inquiryProviderControlPanel);
			this.inquiryGroup.Controls.Add(this.labelControl3);
			this.inquiryGroup.Controls.Add(this.btnDeployInquiryScheme);
			this.inquiryGroup.Controls.Add(this.txtInquiryProvider);
			this.inquiryGroup.Controls.Add(this.checkInquirySameAsDb);
			this.inquiryGroup.Name = "inquiryGroup";
			// 
			// inquiryProviderControlPanel
			// 
			resources.ApplyResources(this.inquiryProviderControlPanel, "inquiryProviderControlPanel");
			this.inquiryProviderControlPanel.Name = "inquiryProviderControlPanel";
			// 
			// labelControl3
			// 
			resources.ApplyResources(this.labelControl3, "labelControl3");
			this.labelControl3.Name = "labelControl3";
			// 
			// txtInquiryProvider
			// 
			resources.ApplyResources(this.txtInquiryProvider, "txtInquiryProvider");
			this.txtInquiryProvider.Name = "txtInquiryProvider";
			this.txtInquiryProvider.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtInquiryProvider.Properties.Buttons"))))});
			this.txtInquiryProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.txtInquiryProvider.SelectedValueChanged += new System.EventHandler(this.txtInquiryProvider_SelectedValueChanged);
			// 
			// checkInquirySameAsDb
			// 
			resources.ApplyResources(this.checkInquirySameAsDb, "checkInquirySameAsDb");
			this.checkInquirySameAsDb.Name = "checkInquirySameAsDb";
			this.checkInquirySameAsDb.Properties.Caption = resources.GetString("checkInquirySameAsDb.Properties.Caption");
			this.checkInquirySameAsDb.CheckedChanged += new System.EventHandler(this.checkInquirySameAsDb_CheckedChanged);
			// 
			// ConnectForm
			// 
			this.AcceptButton = this.btnOk;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.inquiryGroup);
			this.Controls.Add(this.dbGroup);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConnectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Load += new System.EventHandler(this.ConnectForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dbGroup)).EndInit();
			this.dbGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.inquiryGroup)).EndInit();
			this.inquiryGroup.ResumeLayout(false);
			this.inquiryGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.inquiryProviderControlPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtInquiryProvider.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkInquirySameAsDb.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnDeployInquiryScheme;
		private DevExpress.XtraEditors.GroupControl dbGroup;
		private DevExpress.XtraEditors.GroupControl inquiryGroup;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.ComboBoxEdit txtInquiryProvider;
		private DevExpress.XtraEditors.CheckEdit checkInquirySameAsDb;
		private DevExpress.XtraEditors.PanelControl inquiryProviderControlPanel;
		private DbConnectControl dbConnectControl;
		private DevExpress.XtraEditors.SimpleButton btnDeploySequenceScheme;
	}
}