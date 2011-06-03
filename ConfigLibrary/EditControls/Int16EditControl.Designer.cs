namespace DomainCommonSE.ConfigLibrary.EditControls
{
	partial class Int16EditControl
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
			this.numberEditControl1 = new DomainCommonSE.ConfigLibrary.EditControls.NumberEditControl();
			this.SuspendLayout();
			// 
			// numberEditControl1
			// 
			this.numberEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numberEditControl1.Location = new System.Drawing.Point(0, 0);
			this.numberEditControl1.Name = "numberEditControl1";
			this.numberEditControl1.Size = new System.Drawing.Size(144, 21);
			this.numberEditControl1.TabIndex = 0;
			this.numberEditControl1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// Int16EditControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.numberEditControl1);
			this.Name = "Int16EditControl";
			this.Controls.SetChildIndex(this.numberEditControl1, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private NumberEditControl numberEditControl1;
	}
}
