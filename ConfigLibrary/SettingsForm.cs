using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class SettingsForm : XtraForm
	{
		ConfigSettings m_settings;
		bool m_connectionPluginChanged;

		public SettingsForm()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				ConfigInquiry.Instance.SaveSettings(m_settings);
				ConfigInquiry.Instance.LoadPlugins();

				if (m_connectionPluginChanged)
					UI.Instance.CallConnectionPluginChanged();

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			m_settings = ConfigInquiry.Instance.CfgSettings.Clone() as ConfigSettings;

			dbProfileList.DataSource = m_settings.DbConnectionPlugin;
		}

		private void btnDeleteDbProfile_Click(object sender, EventArgs e)
		{
			try
			{
				dbProfileList.Items.BeginUpdate();

				List<string> removeItems = new List<string>(dbProfileList.SelectedItems.Count);
				foreach (string item in dbProfileList.SelectedItems)
				{
					removeItems.Add(item);
				}

				foreach (string item in removeItems)
				{
					m_settings.DbConnectionPlugin.Remove(item);
				}

				dbProfileList.Items.EndUpdate();

				m_connectionPluginChanged = true;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnAddDbProfile_Click(object sender, EventArgs e)
		{
			try
			{
				if (openDbProfileFileDialog.ShowDialog() != DialogResult.OK)
					return;

				dbProfileList.BeginUpdate();
				foreach (string fileName in openDbProfileFileDialog.FileNames)
				{
					if (m_settings.DbConnectionPlugin.Contains(fileName))
						continue;
					
					m_settings.DbConnectionPlugin.Add(fileName);
				}
				dbProfileList.EndUpdate();

				m_connectionPluginChanged = true;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}
	}
}