namespace DomainCommonSE.ConfigLibrary
{
	partial class PropertyControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyControl));
			this.propertyGrid = new DevExpress.XtraVerticalGrid.PropertyGridControl();
			this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			((System.ComponentModel.ISupportInitialize)(this.propertyGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// propertyGrid
			// 
			resources.ApplyResources(this.propertyGrid, "propertyGrid");
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
			// 
			// repositoryItemButtonEdit1
			// 
			resources.ApplyResources(this.repositoryItemButtonEdit1, "repositoryItemButtonEdit1");
			this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
			// 
			// PropertyControl
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.propertyGrid);
			this.Name = "PropertyControl";
			this.Load += new System.EventHandler(this.PropertyControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.propertyGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGrid;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
	}
}
