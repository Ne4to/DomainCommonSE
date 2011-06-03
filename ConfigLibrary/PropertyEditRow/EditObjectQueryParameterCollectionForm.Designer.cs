namespace DomainCommonSE.ConfigLibrary.PropertyEditRow
{
	partial class EditObjectQueryParameterCollectionForm
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
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.listMembers = new DevExpress.XtraEditors.ListBoxControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.btnAddParam = new DevExpress.XtraEditors.SimpleButton();
			this.btnRemoveParam = new DevExpress.XtraEditors.SimpleButton();
			this.propertyGrid = new DevExpress.XtraVerticalGrid.PropertyGridControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.listMembers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.propertyGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(401, 327);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(482, 327);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// listMembers
			// 
			this.listMembers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.listMembers.Location = new System.Drawing.Point(12, 31);
			this.listMembers.Name = "listMembers";
			this.listMembers.Size = new System.Drawing.Size(212, 261);
			this.listMembers.TabIndex = 2;
			this.listMembers.SelectedValueChanged += new System.EventHandler(this.listMembers_SelectedValueChanged);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 12);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(43, 13);
			this.labelControl1.TabIndex = 3;
			this.labelControl1.Text = "Members";
			// 
			// btnAddParam
			// 
			this.btnAddParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddParam.Location = new System.Drawing.Point(12, 298);
			this.btnAddParam.Name = "btnAddParam";
			this.btnAddParam.Size = new System.Drawing.Size(75, 23);
			this.btnAddParam.TabIndex = 4;
			this.btnAddParam.Text = "Add";
			this.btnAddParam.Click += new System.EventHandler(this.btnAddParam_Click);
			// 
			// btnRemoveParam
			// 
			this.btnRemoveParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRemoveParam.Location = new System.Drawing.Point(149, 298);
			this.btnRemoveParam.Name = "btnRemoveParam";
			this.btnRemoveParam.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveParam.TabIndex = 5;
			this.btnRemoveParam.Text = "Remove";
			this.btnRemoveParam.Click += new System.EventHandler(this.btnRemoveParam_Click);
			// 
			// propertyGrid
			// 
			this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid.DefaultEditors.AddRange(new DevExpress.XtraVerticalGrid.Rows.DefaultEditor[] {
            new DevExpress.XtraVerticalGrid.Rows.DefaultEditor(null, null)});
			this.propertyGrid.Location = new System.Drawing.Point(233, 31);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.RecordWidth = 121;
			this.propertyGrid.RowHeaderWidth = 79;
			this.propertyGrid.Size = new System.Drawing.Size(324, 290);
			this.propertyGrid.TabIndex = 6;
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(233, 12);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(49, 13);
			this.labelControl2.TabIndex = 7;
			this.labelControl2.Text = "Properties";
			// 
			// EditObjectQueryParameterCollectionForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(569, 362);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.propertyGrid);
			this.Controls.Add(this.btnRemoveParam);
			this.Controls.Add(this.btnAddParam);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.listMembers);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditObjectQueryParameterCollectionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Object query parameter collection";
			this.Load += new System.EventHandler(this.EditObjectQueryParameterCollectionForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.listMembers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.propertyGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.ListBoxControl listMembers;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.SimpleButton btnAddParam;
		private DevExpress.XtraEditors.SimpleButton btnRemoveParam;
		private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGrid;
		private DevExpress.XtraEditors.LabelControl labelControl2;
	}
}