namespace DomainCommonSE.ConfigLibrary
{
	partial class EditQueryForm
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
			this.txtCode = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new DevExpress.XtraEditors.LabelControl();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
			this.label2 = new DevExpress.XtraEditors.LabelControl();
			this.txtObjectType = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.txtSource = new DomainCommonSE.ConfigLibrary.SqlHighlightControl();
			this.dbScheme = new DomainCommonSE.ConfigLibrary.DbSchemeControl();
			((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtObjectType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtCode
			// 
			this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCode.Location = new System.Drawing.Point(12, 28);
			this.txtCode.Name = "txtCode";
			this.txtCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCode.Properties.MaxLength = 50;
			this.txtCode.Size = new System.Drawing.Size(668, 20);
			this.txtCode.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Code";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(524, 391);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Ok";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(605, 391);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(12, 299);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Properties.MaxLength = 200;
			this.txtDescription.Size = new System.Drawing.Size(668, 86);
			this.txtDescription.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 280);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Description";
			// 
			// txtObjectType
			// 
			this.txtObjectType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtObjectType.Location = new System.Drawing.Point(12, 73);
			this.txtObjectType.Name = "txtObjectType";
			this.txtObjectType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.txtObjectType.Size = new System.Drawing.Size(668, 20);
			this.txtObjectType.TabIndex = 3;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 54);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(57, 13);
			this.labelControl1.TabIndex = 2;
			this.labelControl1.Text = "Object type";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(12, 99);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(33, 13);
			this.labelControl2.TabIndex = 4;
			this.labelControl2.Text = "Source";
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerControl1.Location = new System.Drawing.Point(12, 118);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.txtSource);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.dbScheme);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(668, 156);
			this.splitContainerControl1.SplitterPosition = 436;
			this.splitContainerControl1.TabIndex = 16;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// txtSource
			// 
			this.txtSource.AllowDrop = true;
			this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSource.Location = new System.Drawing.Point(0, 0);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(436, 156);
			this.txtSource.TabIndex = 0;
			this.txtSource.TextValue = "";
			// 
			// dbScheme
			// 
			this.dbScheme.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dbScheme.Location = new System.Drawing.Point(0, 0);
			this.dbScheme.Name = "dbScheme";
			this.dbScheme.Size = new System.Drawing.Size(226, 156);
			this.dbScheme.TabIndex = 0;
			// 
			// EditQueryForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(692, 426);
			this.Controls.Add(this.splitContainerControl1);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.txtObjectType);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.label1);
			this.MinimizeBox = false;
			this.Name = "EditQueryForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit query";
			((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtObjectType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.TextEdit txtCode;
		private DevExpress.XtraEditors.LabelControl label1;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.MemoEdit txtDescription;
		private DevExpress.XtraEditors.LabelControl label2;
		private DevExpress.XtraEditors.ComboBoxEdit txtObjectType;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private SqlHighlightControl txtSource;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DbSchemeControl dbScheme;
	}
}