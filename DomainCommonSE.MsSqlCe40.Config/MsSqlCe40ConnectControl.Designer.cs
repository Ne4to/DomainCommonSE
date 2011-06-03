namespace DomainCommonSE.MsSqlCe40.Config
{
	partial class MsSqlCe40ConnectControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsSqlCe40ConnectControl));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			this.txtLocale = new DevExpress.XtraEditors.ComboBoxEdit();
			this.txtPassword = new DevExpress.XtraEditors.TextEdit();
			this.txtFilePath = new DevExpress.XtraEditors.ButtonEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.txtLocale.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtMsCe35Locale
			// 
			resources.ApplyResources(this.txtLocale, "txtMsCe35Locale");
			this.txtLocale.Name = "txtMsCe35Locale";
			this.txtLocale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtMsCe35Locale.Properties.Buttons"))))});
			this.txtLocale.Properties.Sorted = true;
			this.txtLocale.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// txtMsCe35Password
			// 
			resources.ApplyResources(this.txtPassword, "txtMsCe35Password");
			this.txtPassword.Name = "txtMsCe35Password";
			this.txtPassword.Properties.PasswordChar = '*';
			// 
			// txtMsCe35File
			// 
			resources.ApplyResources(this.txtFilePath, "txtMsCe35File");
			this.txtFilePath.Name = "txtMsCe35File";
			this.txtFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtMsCe35File.Properties.Buttons"))), resources.GetString("txtMsCe35File.Properties.Buttons1"), ((int)(resources.GetObject("txtMsCe35File.Properties.Buttons2"))), ((bool)(resources.GetObject("txtMsCe35File.Properties.Buttons3"))), ((bool)(resources.GetObject("txtMsCe35File.Properties.Buttons4"))), ((bool)(resources.GetObject("txtMsCe35File.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("txtMsCe35File.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("txtMsCe35File.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("txtMsCe35File.Properties.Buttons8"), resources.GetString("txtMsCe35File.Properties.Buttons9"), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("txtMsCe35File.Properties.Buttons10"))), ((bool)(resources.GetObject("txtMsCe35File.Properties.Buttons11")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtMsCe35File.Properties.Buttons12"))), resources.GetString("txtMsCe35File.Properties.Buttons13"), ((int)(resources.GetObject("txtMsCe35File.Properties.Buttons14"))), ((bool)(resources.GetObject("txtMsCe35File.Properties.Buttons15"))), ((bool)(resources.GetObject("txtMsCe35File.Properties.Buttons16"))), ((bool)(resources.GetObject("txtMsCe35File.Properties.Buttons17"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("txtMsCe35File.Properties.Buttons18"))), ((System.Drawing.Image)(resources.GetObject("txtMsCe35File.Properties.Buttons19"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("txtMsCe35File.Properties.Buttons20"), resources.GetString("txtMsCe35File.Properties.Buttons21"), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("txtMsCe35File.Properties.Buttons22"))), ((bool)(resources.GetObject("txtMsCe35File.Properties.Buttons23"))))});
			this.txtFilePath.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFilePath_ButtonClick);
			// 
			// labelControl4
			// 
			resources.ApplyResources(this.labelControl4, "labelControl4");
			this.labelControl4.Name = "labelControl4";
			// 
			// labelControl3
			// 
			resources.ApplyResources(this.labelControl3, "labelControl3");
			this.labelControl3.Name = "labelControl3";
			// 
			// labelControl2
			// 
			resources.ApplyResources(this.labelControl2, "labelControl2");
			this.labelControl2.Name = "labelControl2";
			// 
			// saveFileDialog
			// 
			resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
			this.saveFileDialog.RestoreDirectory = true;
			// 
			// openFileDialog
			// 
			resources.ApplyResources(this.openFileDialog, "openFileDialog");
			// 
			// MsSqlCe35ConnectControl
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtLocale);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtFilePath);
			this.Controls.Add(this.labelControl4);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.labelControl2);
			this.Name = "MsSqlCe35ConnectControl";
			((System.ComponentModel.ISupportInitialize)(this.txtLocale.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFilePath.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.ComboBoxEdit txtLocale;
		private DevExpress.XtraEditors.TextEdit txtPassword;
		private DevExpress.XtraEditors.ButtonEdit txtFilePath;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}
