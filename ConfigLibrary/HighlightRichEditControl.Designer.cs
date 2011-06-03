namespace DomainCommonSE.ConfigLibrary
{
	partial class HighlightRichEditControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighlightRichEditControl));
			this.txtEdit = new DevExpress.XtraRichEdit.RichEditControl();
			this.SuspendLayout();
			// 
			// txtEdit
			// 
			this.txtEdit.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
			this.txtEdit.Appearance.Text.Font = new System.Drawing.Font("Tahoma", 8F);
			this.txtEdit.Appearance.Text.Options.UseFont = true;
			this.txtEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtEdit.DragDropMode = DevExpress.XtraRichEdit.DragDropMode.Manual;
			this.txtEdit.Location = new System.Drawing.Point(0, 0);
			this.txtEdit.Name = "txtEdit";
			this.txtEdit.Options.Behavior.Drop = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
			this.txtEdit.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
			this.txtEdit.Options.DocumentSaveOptions.DefaultFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
			this.txtEdit.Options.Import.PlainText.Encoding = ((System.Text.Encoding)(resources.GetObject("txtEdit.Options.Import.PlainText.Encoding")));
			this.txtEdit.Size = new System.Drawing.Size(460, 359);
			this.txtEdit.TabIndex = 1;
			this.txtEdit.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtEdit_DragDrop);
			this.txtEdit.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtEdit_DragEnter);
			this.txtEdit.DragOver += new System.Windows.Forms.DragEventHandler(this.txtEdit_DragOver);
			this.txtEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdit_KeyDown);
			this.txtEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtEdit_MouseDown);
			this.txtEdit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtEdit_MouseMove);
			// 
			// HighlightRichEditControl
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtEdit);
			this.Name = "HighlightRichEditControl";
			this.Size = new System.Drawing.Size(460, 359);
			this.Load += new System.EventHandler(this.HighlightRichEditControl_Load);
			this.ResumeLayout(false);

		}

		#endregion

		public DevExpress.XtraRichEdit.RichEditControl txtEdit;
	}
}
