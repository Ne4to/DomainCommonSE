namespace DomainCommonSE.ConfigLibrary
{
	partial class InquiryFileProviderControl
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
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtFilePath = new DevExpress.XtraEditors.ButtonEdit();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(3, 3);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(41, 13);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "File path";
			// 
			// txtFilePath
			// 
			this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilePath.Location = new System.Drawing.Point(3, 22);
			this.txtFilePath.Name = "txtFilePath";
			this.txtFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.txtFilePath.Size = new System.Drawing.Size(229, 20);
			this.txtFilePath.TabIndex = 1;
			this.txtFilePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFilePath_ButtonClick);
			// 
			// InquiryFileProviderControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.txtFilePath);
			this.Controls.Add(this.labelControl1);
			this.Name = "InquiryFileProviderControl";
			this.Size = new System.Drawing.Size(235, 49);
			((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.ButtonEdit txtFilePath;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}
