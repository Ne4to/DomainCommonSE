namespace DomainCommonSE.ConfigLibrary
{
	partial class DbSchemeControl
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
			this.tree = new DevExpress.XtraTreeList.TreeList();
			this.nameColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.dataTypeColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
			this.SuspendLayout();
			// 
			// tree
			// 
			this.tree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.nameColumn,
            this.dataTypeColumn});
			this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tree.KeyFieldName = "";
			this.tree.Location = new System.Drawing.Point(0, 0);
			this.tree.Name = "tree";
			this.tree.OptionsBehavior.AutoChangeParent = false;
			this.tree.OptionsBehavior.DragNodes = true;
			this.tree.OptionsBehavior.Editable = false;
			this.tree.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.tree.ParentFieldName = "";
			this.tree.Size = new System.Drawing.Size(302, 248);
			this.tree.TabIndex = 0;
			this.tree.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_DragDrop);
			// 
			// nameColumn
			// 
			this.nameColumn.Caption = "Name";
			this.nameColumn.FieldName = "Name";
			this.nameColumn.Name = "nameColumn";
			this.nameColumn.Visible = true;
			this.nameColumn.VisibleIndex = 0;
			// 
			// dataTypeColumn
			// 
			this.dataTypeColumn.Caption = "Data type";
			this.dataTypeColumn.FieldName = "Data type";
			this.dataTypeColumn.Name = "dataTypeColumn";
			this.dataTypeColumn.Visible = true;
			this.dataTypeColumn.VisibleIndex = 1;
			// 
			// DbSchemeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tree);
			this.Name = "DbSchemeControl";
			this.Size = new System.Drawing.Size(302, 248);
			((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraTreeList.TreeList tree;
		private DevExpress.XtraTreeList.Columns.TreeListColumn nameColumn;
		private DevExpress.XtraTreeList.Columns.TreeListColumn dataTypeColumn;
	}
}
