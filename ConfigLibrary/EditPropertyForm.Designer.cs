namespace DomainCommonSE.ConfigLibrary
{
	partial class EditPropertyForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPropertyForm));
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new DevExpress.XtraEditors.LabelControl();
			this.txtCode = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new DevExpress.XtraEditors.LabelControl();
			this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
			this.label3 = new DevExpress.XtraEditors.LabelControl();
			this.txtDataType = new DevExpress.XtraEditors.ComboBoxEdit();
			this.label4 = new DevExpress.XtraEditors.LabelControl();
			this.txtLength = new System.Windows.Forms.NumericUpDown();
			this.label5 = new DevExpress.XtraEditors.LabelControl();
			this.txtCodeName = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.editValuePanel = new DevExpress.XtraEditors.PanelControl();
			((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDataType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCodeName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.editValuePanel)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAdd
			// 
			resources.ApplyResources(this.btnAdd, "btnAdd");
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// txtCode
			// 
			resources.ApplyResources(this.txtCode, "txtCode");
			this.txtCode.Name = "txtCode";
			this.txtCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCode.Properties.MaxLength = 50;
			this.txtCode.EditValueChanged += new System.EventHandler(this.txtCode_EditValueChanged);
			this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// txtDescription
			// 
			resources.ApplyResources(this.txtDescription, "txtDescription");
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Properties.MaxLength = 200;
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// txtDataType
			// 
			resources.ApplyResources(this.txtDataType, "txtDataType");
			this.txtDataType.Name = "txtDataType";
			this.txtDataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtDataType.Properties.Buttons"))))});
			this.txtDataType.Properties.DropDownRows = 12;
			this.txtDataType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.txtDataType.SelectedIndexChanged += new System.EventHandler(this.txtDataType_SelectedIndexChanged);
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// txtLength
			// 
			resources.ApplyResources(this.txtLength, "txtLength");
			this.txtLength.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.txtLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.txtLength.Name = "txtLength";
			this.txtLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// txtCodeName
			// 
			resources.ApplyResources(this.txtCodeName, "txtCodeName");
			this.txtCodeName.Name = "txtCodeName";
			this.txtCodeName.Properties.MaxLength = 50;
			// 
			// labelControl1
			// 
			resources.ApplyResources(this.labelControl1, "labelControl1");
			this.labelControl1.Name = "labelControl1";
			// 
			// editValuePanel
			// 
			resources.ApplyResources(this.editValuePanel, "editValuePanel");
			this.editValuePanel.Name = "editValuePanel";
			// 
			// EditPropertyForm
			// 
			this.AcceptButton = this.btnAdd;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ControlBox = false;
			this.Controls.Add(this.editValuePanel);
			this.Controls.Add(this.txtCodeName);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtLength);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDataType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditPropertyForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDataType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCodeName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.editValuePanel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnAdd;
		private DevExpress.XtraEditors.LabelControl label1;
		private DevExpress.XtraEditors.TextEdit txtCode;
		private DevExpress.XtraEditors.LabelControl label2;
		private DevExpress.XtraEditors.MemoEdit txtDescription;
		private DevExpress.XtraEditors.LabelControl label3;
		private DevExpress.XtraEditors.ComboBoxEdit txtDataType;
		private DevExpress.XtraEditors.LabelControl label4;
		private System.Windows.Forms.NumericUpDown txtLength;
		private DevExpress.XtraEditors.LabelControl label5;
		private DevExpress.XtraEditors.TextEdit txtCodeName;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.PanelControl editValuePanel;
	}
}