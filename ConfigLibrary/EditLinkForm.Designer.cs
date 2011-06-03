namespace DomainCommonSE.ConfigLibrary
{
	partial class EditLinkForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLinkForm));
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.gridRightObject = new DevExpress.XtraGrid.GridControl();
			this.viewRightObject = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridRightObjectCodeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridLinkObjectDescriptionColumn = new DevExpress.XtraGrid.Columns.GridColumn();
			this.txtLeftToRightDescription = new DevExpress.XtraEditors.MemoEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.txtLinkCode = new DevExpress.XtraEditors.TextEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.cbIsRightToLeft = new DevExpress.XtraEditors.CheckEdit();
			this.cbIsLeftToRight = new DevExpress.XtraEditors.CheckEdit();
			this.rgRightRelation = new DevExpress.XtraEditors.RadioGroup();
			this.rgLeftRelation = new DevExpress.XtraEditors.RadioGroup();
			this.txtLeftIdField = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.txtRightIdField = new DevExpress.XtraEditors.TextEdit();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.txtRightToLeftDescription = new DevExpress.XtraEditors.MemoEdit();
			this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
			this.gridLeftObject = new DevExpress.XtraGrid.GridControl();
			this.viewLeftObject = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridLeftObjectCodeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
			this.txtLeftCollectionName = new DevExpress.XtraEditors.TextEdit();
			this.txtRightCollectionName = new DevExpress.XtraEditors.TextEdit();
			this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
			this.txtLinkTableName = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.gridRightObject)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.viewRightObject)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLeftToRightDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLinkCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbIsRightToLeft.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbIsLeftToRight.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rgRightRelation.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rgLeftRelation.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLeftIdField.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRightIdField.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRightToLeftDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLeftObject)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.viewLeftObject)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLeftCollectionName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRightCollectionName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLinkTableName.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			// 
			// btnSave
			// 
			resources.ApplyResources(this.btnSave, "btnSave");
			this.btnSave.Name = "btnSave";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// gridRightObject
			// 
			resources.ApplyResources(this.gridRightObject, "gridRightObject");
			this.gridRightObject.MainView = this.viewRightObject;
			this.gridRightObject.Name = "gridRightObject";
			this.gridRightObject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewRightObject});
			// 
			// viewRightObject
			// 
			this.viewRightObject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridRightObjectCodeColumn,
            this.gridLinkObjectDescriptionColumn});
			this.viewRightObject.GridControl = this.gridRightObject;
			this.viewRightObject.Name = "viewRightObject";
			this.viewRightObject.OptionsBehavior.Editable = false;
			this.viewRightObject.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.viewRightObject.OptionsSelection.EnableAppearanceHideSelection = false;
			this.viewRightObject.OptionsView.ShowAutoFilterRow = true;
			this.viewRightObject.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.viewRightObject.OptionsView.ShowGroupPanel = false;
			// 
			// gridRightObjectCodeColumn
			// 
			resources.ApplyResources(this.gridRightObjectCodeColumn, "gridRightObjectCodeColumn");
			this.gridRightObjectCodeColumn.FieldName = "Code";
			this.gridRightObjectCodeColumn.Name = "gridRightObjectCodeColumn";
			this.gridRightObjectCodeColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
			// 
			// gridLinkObjectDescriptionColumn
			// 
			resources.ApplyResources(this.gridLinkObjectDescriptionColumn, "gridLinkObjectDescriptionColumn");
			this.gridLinkObjectDescriptionColumn.FieldName = "Description";
			this.gridLinkObjectDescriptionColumn.Name = "gridLinkObjectDescriptionColumn";
			this.gridLinkObjectDescriptionColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
			// 
			// txtLeftToRightDescription
			// 
			resources.ApplyResources(this.txtLeftToRightDescription, "txtLeftToRightDescription");
			this.txtLeftToRightDescription.Name = "txtLeftToRightDescription";
			this.txtLeftToRightDescription.Properties.MaxLength = 200;
			// 
			// labelControl1
			// 
			resources.ApplyResources(this.labelControl1, "labelControl1");
			this.labelControl1.Name = "labelControl1";
			// 
			// labelControl2
			// 
			resources.ApplyResources(this.labelControl2, "labelControl2");
			this.labelControl2.Name = "labelControl2";
			// 
			// txtLinkCode
			// 
			resources.ApplyResources(this.txtLinkCode, "txtLinkCode");
			this.txtLinkCode.Name = "txtLinkCode";
			this.txtLinkCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLinkCode.Properties.MaxLength = 50;
			// 
			// labelControl3
			// 
			resources.ApplyResources(this.labelControl3, "labelControl3");
			this.labelControl3.Name = "labelControl3";
			// 
			// cbIsRightToLeft
			// 
			resources.ApplyResources(this.cbIsRightToLeft, "cbIsRightToLeft");
			this.cbIsRightToLeft.Name = "cbIsRightToLeft";
			this.cbIsRightToLeft.Properties.Caption = resources.GetString("cbIsRightToLeft.Properties.Caption");
			// 
			// cbIsLeftToRight
			// 
			resources.ApplyResources(this.cbIsLeftToRight, "cbIsLeftToRight");
			this.cbIsLeftToRight.Name = "cbIsLeftToRight";
			this.cbIsLeftToRight.Properties.Caption = resources.GetString("cbIsLeftToRight.Properties.Caption");
			// 
			// rgRightRelation
			// 
			resources.ApplyResources(this.rgRightRelation, "rgRightRelation");
			this.rgRightRelation.Name = "rgRightRelation";
			this.rgRightRelation.Properties.Columns = 2;
			this.rgRightRelation.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgRightRelation.Properties.Items"), resources.GetString("rgRightRelation.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgRightRelation.Properties.Items2"), resources.GetString("rgRightRelation.Properties.Items3"))});
			this.rgRightRelation.EditValueChanged += new System.EventHandler(this.rgRelation_EditValueChanged);
			// 
			// rgLeftRelation
			// 
			resources.ApplyResources(this.rgLeftRelation, "rgLeftRelation");
			this.rgLeftRelation.Name = "rgLeftRelation";
			this.rgLeftRelation.Properties.Columns = 2;
			this.rgLeftRelation.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgLeftRelation.Properties.Items"), resources.GetString("rgLeftRelation.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("rgLeftRelation.Properties.Items2"), resources.GetString("rgLeftRelation.Properties.Items3"))});
			this.rgLeftRelation.EditValueChanged += new System.EventHandler(this.rgRelation_EditValueChanged);
			// 
			// txtLeftIdField
			// 
			resources.ApplyResources(this.txtLeftIdField, "txtLeftIdField");
			this.txtLeftIdField.Name = "txtLeftIdField";
			this.txtLeftIdField.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLeftIdField.Properties.MaxLength = 50;
			// 
			// labelControl4
			// 
			resources.ApplyResources(this.labelControl4, "labelControl4");
			this.labelControl4.Name = "labelControl4";
			// 
			// txtRightIdField
			// 
			resources.ApplyResources(this.txtRightIdField, "txtRightIdField");
			this.txtRightIdField.Name = "txtRightIdField";
			this.txtRightIdField.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRightIdField.Properties.MaxLength = 50;
			// 
			// labelControl5
			// 
			resources.ApplyResources(this.labelControl5, "labelControl5");
			this.labelControl5.Name = "labelControl5";
			// 
			// labelControl6
			// 
			resources.ApplyResources(this.labelControl6, "labelControl6");
			this.labelControl6.Name = "labelControl6";
			// 
			// txtRightToLeftDescription
			// 
			resources.ApplyResources(this.txtRightToLeftDescription, "txtRightToLeftDescription");
			this.txtRightToLeftDescription.Name = "txtRightToLeftDescription";
			this.txtRightToLeftDescription.Properties.MaxLength = 200;
			// 
			// labelControl7
			// 
			resources.ApplyResources(this.labelControl7, "labelControl7");
			this.labelControl7.Name = "labelControl7";
			// 
			// gridLeftObject
			// 
			resources.ApplyResources(this.gridLeftObject, "gridLeftObject");
			this.gridLeftObject.MainView = this.viewLeftObject;
			this.gridLeftObject.Name = "gridLeftObject";
			this.gridLeftObject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewLeftObject});
			// 
			// viewLeftObject
			// 
			this.viewLeftObject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridLeftObjectCodeColumn,
            this.gridColumn2});
			this.viewLeftObject.GridControl = this.gridLeftObject;
			this.viewLeftObject.Name = "viewLeftObject";
			this.viewLeftObject.OptionsBehavior.Editable = false;
			this.viewLeftObject.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.viewLeftObject.OptionsSelection.EnableAppearanceHideSelection = false;
			this.viewLeftObject.OptionsView.ShowAutoFilterRow = true;
			this.viewLeftObject.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.viewLeftObject.OptionsView.ShowGroupPanel = false;
			// 
			// gridLeftObjectCodeColumn
			// 
			resources.ApplyResources(this.gridLeftObjectCodeColumn, "gridLeftObjectCodeColumn");
			this.gridLeftObjectCodeColumn.FieldName = "Code";
			this.gridLeftObjectCodeColumn.Name = "gridLeftObjectCodeColumn";
			this.gridLeftObjectCodeColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
			// 
			// gridColumn2
			// 
			resources.ApplyResources(this.gridColumn2, "gridColumn2");
			this.gridColumn2.FieldName = "Description";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
			// 
			// labelControl8
			// 
			resources.ApplyResources(this.labelControl8, "labelControl8");
			this.labelControl8.Name = "labelControl8";
			// 
			// labelControl9
			// 
			resources.ApplyResources(this.labelControl9, "labelControl9");
			this.labelControl9.Name = "labelControl9";
			// 
			// labelControl10
			// 
			resources.ApplyResources(this.labelControl10, "labelControl10");
			this.labelControl10.Name = "labelControl10";
			// 
			// txtLeftCollectionName
			// 
			resources.ApplyResources(this.txtLeftCollectionName, "txtLeftCollectionName");
			this.txtLeftCollectionName.Name = "txtLeftCollectionName";
			// 
			// txtRightCollectionName
			// 
			resources.ApplyResources(this.txtRightCollectionName, "txtRightCollectionName");
			this.txtRightCollectionName.Name = "txtRightCollectionName";
			// 
			// labelControl11
			// 
			resources.ApplyResources(this.labelControl11, "labelControl11");
			this.labelControl11.Name = "labelControl11";
			// 
			// labelControl12
			// 
			resources.ApplyResources(this.labelControl12, "labelControl12");
			this.labelControl12.Name = "labelControl12";
			// 
			// txtLinkTableName
			// 
			resources.ApplyResources(this.txtLinkTableName, "txtLinkTableName");
			this.txtLinkTableName.Name = "txtLinkTableName";
			this.txtLinkTableName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLinkTableName.Properties.MaxLength = 50;
			// 
			// EditLinkForm
			// 
			this.AcceptButton = this.btnSave;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.txtLinkTableName);
			this.Controls.Add(this.labelControl12);
			this.Controls.Add(this.txtRightCollectionName);
			this.Controls.Add(this.labelControl11);
			this.Controls.Add(this.txtLeftCollectionName);
			this.Controls.Add(this.labelControl10);
			this.Controls.Add(this.labelControl9);
			this.Controls.Add(this.labelControl8);
			this.Controls.Add(this.labelControl7);
			this.Controls.Add(this.gridLeftObject);
			this.Controls.Add(this.labelControl6);
			this.Controls.Add(this.txtRightToLeftDescription);
			this.Controls.Add(this.txtRightIdField);
			this.Controls.Add(this.labelControl5);
			this.Controls.Add(this.txtLeftIdField);
			this.Controls.Add(this.labelControl4);
			this.Controls.Add(this.rgLeftRelation);
			this.Controls.Add(this.rgRightRelation);
			this.Controls.Add(this.cbIsLeftToRight);
			this.Controls.Add(this.cbIsRightToLeft);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.txtLinkCode);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.txtLeftToRightDescription);
			this.Controls.Add(this.gridRightObject);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditLinkForm";
			this.ShowIcon = false;
			((System.ComponentModel.ISupportInitialize)(this.gridRightObject)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.viewRightObject)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLeftToRightDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLinkCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbIsRightToLeft.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbIsLeftToRight.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rgRightRelation.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rgLeftRelation.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLeftIdField.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRightIdField.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRightToLeftDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLeftObject)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.viewLeftObject)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLeftCollectionName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtRightCollectionName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLinkTableName.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraGrid.GridControl gridRightObject;
		private DevExpress.XtraGrid.Views.Grid.GridView viewRightObject;
		private DevExpress.XtraEditors.MemoEdit txtLeftToRightDescription;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit txtLinkCode;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.CheckEdit cbIsRightToLeft;
		private DevExpress.XtraEditors.CheckEdit cbIsLeftToRight;
		private DevExpress.XtraEditors.RadioGroup rgRightRelation;
		private DevExpress.XtraEditors.RadioGroup rgLeftRelation;
		private DevExpress.XtraGrid.Columns.GridColumn gridRightObjectCodeColumn;
		private DevExpress.XtraGrid.Columns.GridColumn gridLinkObjectDescriptionColumn;
		private DevExpress.XtraEditors.TextEdit txtLeftIdField;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.TextEdit txtRightIdField;
		private DevExpress.XtraEditors.LabelControl labelControl5;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.MemoEdit txtRightToLeftDescription;
		private DevExpress.XtraEditors.LabelControl labelControl7;
		private DevExpress.XtraGrid.GridControl gridLeftObject;
		private DevExpress.XtraGrid.Views.Grid.GridView viewLeftObject;
		private DevExpress.XtraGrid.Columns.GridColumn gridLeftObjectCodeColumn;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraEditors.LabelControl labelControl8;
		private DevExpress.XtraEditors.LabelControl labelControl9;
		private DevExpress.XtraEditors.LabelControl labelControl10;
		private DevExpress.XtraEditors.TextEdit txtLeftCollectionName;
		private DevExpress.XtraEditors.TextEdit txtRightCollectionName;
		private DevExpress.XtraEditors.LabelControl labelControl11;
		private DevExpress.XtraEditors.LabelControl labelControl12;
		private DevExpress.XtraEditors.TextEdit txtLinkTableName;
	}
}