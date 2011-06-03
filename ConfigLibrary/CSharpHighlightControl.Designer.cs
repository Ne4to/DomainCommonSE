namespace DomainCommonSE.ConfigLibrary
{
	partial class CSharpHighlightControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSharpHighlightControl));
			this.SuspendLayout();
			// 
			// txtEdit
			// 
			this.txtEdit.Appearance.Text.Font = new System.Drawing.Font("Tahoma", 8F);
			this.txtEdit.Appearance.Text.Options.UseFont = true;
			this.txtEdit.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
			this.txtEdit.Options.DocumentSaveOptions.DefaultFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
			this.txtEdit.Options.Import.PlainText.Encoding = ((System.Text.Encoding)(resources.GetObject("txtEdit.Options.Import.PlainText.Encoding")));
			// 
			// CSharpHighlightControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Name = "CSharpHighlightControl";
			this.Load += new System.EventHandler(this.CSharpHighlightControl_Load);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
