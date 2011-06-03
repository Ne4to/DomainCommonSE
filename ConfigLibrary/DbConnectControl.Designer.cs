namespace DomainCommonSE.ConfigLibrary
{
	partial class DbConnectControl
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
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtProfile = new DevExpress.XtraEditors.ComboBoxEdit();
			this.connectControlPanel = new DevExpress.XtraEditors.PanelControl();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.txtLoginData = new DevExpress.XtraEditors.ComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtProfile.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.connectControlPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLoginData.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(3, 3);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(79, 13);
			this.labelControl1.TabIndex = 6;
			this.labelControl1.Text = "Database profile";
			// 
			// txtProfile
			// 
			this.txtProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtProfile.Location = new System.Drawing.Point(3, 22);
			this.txtProfile.Name = "txtProfile";
			this.txtProfile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.txtProfile.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.txtProfile.Size = new System.Drawing.Size(350, 20);
			this.txtProfile.TabIndex = 5;
			this.txtProfile.SelectedIndexChanged += new System.EventHandler(this.txtProfile_SelectedIndexChanged);
			// 
			// connectControlPanel
			// 
			this.connectControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.connectControlPanel.Location = new System.Drawing.Point(0, 93);
			this.connectControlPanel.Name = "connectControlPanel";
			this.connectControlPanel.Size = new System.Drawing.Size(356, 175);
			this.connectControlPanel.TabIndex = 7;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(278, 70);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 17);
			this.btnSave.TabIndex = 10;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(3, 48);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(112, 13);
			this.labelControl2.TabIndex = 8;
			this.labelControl2.Text = "Stored data connection";
			// 
			// txtLoginData
			// 
			this.txtLoginData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtLoginData.Location = new System.Drawing.Point(3, 67);
			this.txtLoginData.Name = "txtLoginData";
			this.txtLoginData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.txtLoginData.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.txtLoginData.Size = new System.Drawing.Size(269, 20);
			this.txtLoginData.TabIndex = 9;
			this.txtLoginData.SelectedIndexChanged += new System.EventHandler(this.txtLoginData_SelectedIndexChanged);
			// 
			// DbConnectControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.txtLoginData);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.txtProfile);
			this.Controls.Add(this.connectControlPanel);
			this.Name = "DbConnectControl";
			this.Size = new System.Drawing.Size(356, 268);
			this.Load += new System.EventHandler(this.DbConnectControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtProfile.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.connectControlPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLoginData.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.ComboBoxEdit txtProfile;
		private DevExpress.XtraEditors.PanelControl connectControlPanel;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.ComboBoxEdit txtLoginData;
	}
}
