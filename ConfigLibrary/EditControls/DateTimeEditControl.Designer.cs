namespace DomainCommonSE.ConfigLibrary.EditControls
{
	partial class DateTimeEditControl
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
			this.dateEdit = new DevExpress.XtraEditors.DateEdit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// dateEdit
			// 
			this.dateEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dateEdit.EditValue = null;
			this.dateEdit.Location = new System.Drawing.Point(0, 0);
			this.dateEdit.Name = "dateEdit";
			this.dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.dateEdit.Size = new System.Drawing.Size(176, 20);
			this.dateEdit.TabIndex = 0;
			// 
			// DateTimeEditControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dateEdit);
			this.Name = "DateTimeEditControl";
			this.Size = new System.Drawing.Size(176, 24);
			((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateEdit.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.DateEdit dateEdit;
	}
}
