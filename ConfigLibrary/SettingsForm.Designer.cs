namespace DomainCommonSE.ConfigLibrary
{
	partial class SettingsForm
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
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.dbProfileGroup = new DevExpress.XtraEditors.GroupControl();
			this.dbProfileList = new DevExpress.XtraEditors.ListBoxControl();
			this.btnDeleteDbProfile = new DevExpress.XtraEditors.SimpleButton();
			this.btnAddDbProfile = new DevExpress.XtraEditors.SimpleButton();
			this.openDbProfileFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dbProfileGroup)).BeginInit();
			this.dbProfileGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dbProfileList)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(655, 227);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(736, 227);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			// 
			// dbProfileGroup
			// 
			this.dbProfileGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dbProfileGroup.Controls.Add(this.dbProfileList);
			this.dbProfileGroup.Controls.Add(this.btnDeleteDbProfile);
			this.dbProfileGroup.Controls.Add(this.btnAddDbProfile);
			this.dbProfileGroup.Location = new System.Drawing.Point(12, 12);
			this.dbProfileGroup.Name = "dbProfileGroup";
			this.dbProfileGroup.Size = new System.Drawing.Size(799, 209);
			this.dbProfileGroup.TabIndex = 2;
			this.dbProfileGroup.Text = "DB profile plugins";
			// 
			// dbProfileList
			// 
			this.dbProfileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dbProfileList.HotTrackItems = true;
			this.dbProfileList.Location = new System.Drawing.Point(5, 25);
			this.dbProfileList.Name = "dbProfileList";
			this.dbProfileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.dbProfileList.Size = new System.Drawing.Size(789, 150);
			this.dbProfileList.TabIndex = 2;
			// 
			// btnDeleteDbProfile
			// 
			this.btnDeleteDbProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDeleteDbProfile.Location = new System.Drawing.Point(86, 181);
			this.btnDeleteDbProfile.Name = "btnDeleteDbProfile";
			this.btnDeleteDbProfile.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteDbProfile.TabIndex = 1;
			this.btnDeleteDbProfile.Text = "Remove";
			this.btnDeleteDbProfile.Click += new System.EventHandler(this.btnDeleteDbProfile_Click);
			// 
			// btnAddDbProfile
			// 
			this.btnAddDbProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddDbProfile.Location = new System.Drawing.Point(5, 181);
			this.btnAddDbProfile.Name = "btnAddDbProfile";
			this.btnAddDbProfile.Size = new System.Drawing.Size(75, 23);
			this.btnAddDbProfile.TabIndex = 0;
			this.btnAddDbProfile.Text = "Add";
			this.btnAddDbProfile.Click += new System.EventHandler(this.btnAddDbProfile_Click);
			// 
			// openDbProfileFileDialog
			// 
			this.openDbProfileFileDialog.Filter = "Профиль БД|*.dll";
			this.openDbProfileFileDialog.Multiselect = true;
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(823, 262);
			this.Controls.Add(this.dbProfileGroup);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dbProfileGroup)).EndInit();
			this.dbProfileGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dbProfileList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.GroupControl dbProfileGroup;
		private DevExpress.XtraEditors.ListBoxControl dbProfileList;
		private DevExpress.XtraEditors.SimpleButton btnDeleteDbProfile;
		private DevExpress.XtraEditors.SimpleButton btnAddDbProfile;
		private System.Windows.Forms.OpenFileDialog openDbProfileFileDialog;

	}
}