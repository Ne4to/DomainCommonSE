using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.ConfigLibrary.Localization;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class SaveLoginDataForm : XtraForm
	{
		IDbCommonConnectionPlugin m_connectionData;
		ConnectionLoginData m_loginData;

		public SaveLoginDataForm()
		{
			InitializeComponent();
		}

		public void Init(IDbCommonConnectionPlugin connectionData, ConnectionLoginData loginData)
		{
			m_connectionData = connectionData;
			m_loginData = loginData;

			if (m_loginData != null)
			{
				txtConnectionName.Text = m_loginData.ConnectionName;
			}
		}			 

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				string title = txtConnectionName.Text.Trim();
				if (String.IsNullOrEmpty(title))
				{
					XtraMessageBox.Show(SaveLoginDataFormLocalization.EnterLoginDataTitleMessage);
					return;
				}

				m_loginData.ConnectionName = title;

				ConfigInquiry.Instance.LoginData.Add(m_connectionData, m_loginData);

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex) 
			{
				XtraMessageBox.Show(ex.Message);
			}
		}
	}
}