namespace DomainCommonSE.ConfigLibrary
{
	partial class EditObjectForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditObjectForm));
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new DevExpress.XtraEditors.LabelControl();
			this.txtCode = new DevExpress.XtraEditors.TextEdit();
			this.label2 = new DevExpress.XtraEditors.LabelControl();
			this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
			this.txtCodeName = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCodeName.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnCreate
			// 
			resources.ApplyResources(this.btnCreate, "btnCreate");
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
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
			this.txtCode.Properties.NullValuePrompt = resources.GetString("txtCode.Properties.NullValuePrompt");
			this.txtCode.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtCode.Properties.NullValuePromptShowForEmptyValue")));
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
			// EditObjectForm
			// 
			this.AcceptButton = this.btnCreate;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.txtCodeName);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditObjectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtCodeName.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnCreate;
		private DevExpress.XtraEditors.LabelControl label1;
		private DevExpress.XtraEditors.TextEdit txtCode;
		private DevExpress.XtraEditors.LabelControl label2;
		private DevExpress.XtraEditors.MemoEdit txtDescription;
		private DevExpress.XtraEditors.TextEdit txtCodeName;
		private DevExpress.XtraEditors.LabelControl labelControl1;
	}
}