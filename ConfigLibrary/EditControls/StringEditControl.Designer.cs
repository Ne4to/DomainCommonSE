namespace DomainCommonSE.ConfigLibrary.EditControls
{
	partial class StringEditControl
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
			this.txtEdit = new DevExpress.XtraEditors.MemoEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtEdit.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtEdit
			// 
			this.txtEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtEdit.Location = new System.Drawing.Point(0, 0);
			this.txtEdit.Name = "txtEdit";
			this.txtEdit.Size = new System.Drawing.Size(122, 26);
			this.txtEdit.TabIndex = 0;
			// 
			// StringEditControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtEdit);
			this.Name = "StringEditControl";
			this.Size = new System.Drawing.Size(122, 26);
			((System.ComponentModel.ISupportInitialize)(this.txtEdit.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.MemoEdit txtEdit;

	}
}
