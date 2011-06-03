namespace DomainCommonSE.ConfigLibrary
{
	partial class SaveLoginDataForm
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
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtConnectionName = new DevExpress.XtraEditors.ComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtConnectionName.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(186, 58);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(267, 58);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 12);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(20, 13);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Title";
			// 
			// txtConnectionName
			// 
			this.txtConnectionName.Location = new System.Drawing.Point(12, 31);
			this.txtConnectionName.Name = "txtConnectionName";
			this.txtConnectionName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.txtConnectionName.Size = new System.Drawing.Size(330, 20);
			this.txtConnectionName.TabIndex = 1;
			// 
			// SaveLoginDataForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(354, 93);
			this.Controls.Add(this.txtConnectionName);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveLoginDataForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Save login data";
			((System.ComponentModel.ISupportInitialize)(this.txtConnectionName.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.ComboBoxEdit txtConnectionName;
	}
}