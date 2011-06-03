using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections.Generic;

using DomainCommonSE.DbCommon;
using DomainCommonSE.MsSqlCe40.Config.Localization;

namespace DomainCommonSE.MsSqlCe40.Config
{
	public partial class MsSqlCe40ConnectControl : XtraUserControl, IDbCommonConnectionConnectControl
	{
		Dictionary<int, int> m_localeIndex;

		private LocaleID SelectedLocaleID
		{
			get
			{
				return (LocaleID)txtLocale.SelectedItem;
			}
		}

		public MsSqlCe40ConnectControl()
		{
			InitializeComponent();

			FillLocaleId();
		}

		private void FillLocaleId()
		{
			m_localeIndex = new Dictionary<int, int>();
			txtLocale.Properties.Items.Clear();

			txtLocale.Properties.Items.BeginUpdate();
			foreach (LocaleID locale in LocaleID.GetFullLocaleList())
			{
				int index = txtLocale.Properties.Items.Add(locale);
				m_localeIndex.Add(locale.Culture.LCID, index);
			}
			txtLocale.Properties.Items.EndUpdate();

			txtLocale.SelectedIndex = 0;
		}

		public IDbCommonConnection GetConnection()
		{
			string filePath = txtFilePath.Text.Trim();

			string password = txtPassword.Text.Trim();
			if (password.Length == 0)
			{
				XtraMessageBox.Show(MsSqlCe40ConnectControlLocalization.EnterPasswordWarning);
				return null;
			}

			return new DbCommonMsSqlCe40Connection(DbCommonMsSqlCe40Connection.GetConnectionString(filePath, password, SelectedLocaleID.Culture.LCID));
		}

		private void txtFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			switch ((string)e.Button.Tag)
			{
				case "save":
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
						txtFilePath.Text = saveFileDialog.FileName;
					break;

				case "load":
					if (openFileDialog.ShowDialog() == DialogResult.OK)
						txtFilePath.Text = openFileDialog.FileName;
					break;
			}
		}

		public ConnectionLoginData GetLoginData()
		{
			return new MsSqlCe40LoginData(txtFilePath.Text.Trim(), txtPassword.Text.Trim(), SelectedLocaleID.Culture.LCID);
		}

		public void SetLoginData(ConnectionLoginData loginData)
		{
			MsSqlCe40LoginData data = loginData as MsSqlCe40LoginData;

			txtFilePath.Text = data.FilePath;
			txtPassword.Text = data.Password;
			txtLocale.SelectedIndex = m_localeIndex[data.LCID];
		}
	}
}
