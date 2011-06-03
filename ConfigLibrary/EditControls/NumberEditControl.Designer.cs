namespace DomainCommonSE.ConfigLibrary.EditControls
{
	partial class NumberEditControl
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
			this.txtValue = new DevExpress.XtraEditors.SpinEdit();
			((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtValue
			// 
			this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.txtValue.Location = new System.Drawing.Point(0, 0);
			this.txtValue.Name = "txtValue";
			this.txtValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.txtValue.Size = new System.Drawing.Size(144, 20);
			this.txtValue.TabIndex = 1;
			// 
			// NumberEditControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtValue);
			this.Name = "NumberEditControl";
			this.Size = new System.Drawing.Size(144, 31);
			((System.ComponentModel.ISupportInitialize)(this.txtValue.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SpinEdit txtValue;

	}
}
