using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class DbConnectControl : RuntimeControl
	{
		Control connectControl;
		IDbCommonConnectionPlugin m_connectionData;

		public IDbCommonConnection GetConnection()
		{
			return (connectControl as IDbCommonConnectionConnectControl).GetConnection();
		}

		public DbConnectControl()
		{
			InitializeComponent();
		}

		public void Init(IDbCommonConnectionPlugin data = null)
		{
			m_connectionData = data;

			if (m_connectionData != null)
			{
				txtProfile.SelectedItem = m_connectionData;
			}
		}

		private void DbConnectControl_Load(object sender, EventArgs e)
		{
			if (IsRuntime)
			{
				foreach (IDbCommonConnectionPlugin connectionPlugin in ConfigInquiry.Instance.ConnectPlugin)
				{
					txtProfile.Properties.Items.Add(connectionPlugin);
				}

				// выбираем первый элемент
				if (txtProfile.Properties.Items.Count > 0)
					txtProfile.SelectedIndex = 0;
			}
		}

		private void txtProfile_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				// удаляем старый контрол если он есть
				if (connectControl != null)
				{
					connectControlPanel.Controls.Remove(connectControl);
					//if (!connectControl.IsDisposed)
					//    connectControl.Dispose();
				}

				IDbCommonConnectionPlugin connectionData = txtProfile.SelectedItem as IDbCommonConnectionPlugin;
				Type controlType = connectionData.ControlType;
				Control control = Activator.CreateInstance(controlType) as Control;
				control.Dock = DockStyle.Fill;

				connectControl = control;

				connectControlPanel.Controls.Add(control);

				txtLoginData.Properties.Items.Clear();
				foreach (ConnectionLoginData dataItem in ConfigInquiry.Instance.LoginData.GetData(connectionData))
				{
					txtLoginData.Properties.Items.Add(dataItem);
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void txtLoginData_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (connectControl != null)
					(connectControl as IDbCommonConnectionConnectControl).SetLoginData(txtLoginData.SelectedItem as ConnectionLoginData);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (connectControl == null)
					return;

				using (SaveLoginDataForm form = new SaveLoginDataForm())
				{
					IDbCommonConnectionPlugin connectionData = txtProfile.SelectedItem as IDbCommonConnectionPlugin;
					form.Init(connectionData, (connectControl as IDbCommonConnectionConnectControl).GetLoginData());
					form.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}
	}

	public class DbConnectionConnectControl : RuntimeControl, IDbCommonConnectionConnectControl
	{
		public virtual ConnectionLoginData GetLoginData()
		{
			throw new NotImplementedException();
		}

		public virtual void SetLoginData(ConnectionLoginData loginData)
		{
			throw new NotImplementedException();
		}

		public virtual IDbCommonConnection GetConnection()
		{
			throw new NotImplementedException();
		}
	}

}
