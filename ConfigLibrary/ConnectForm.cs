using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.ConfigLibrary.Localization;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class ConnectForm : XtraForm
	{
		public DomainObjectInquiry NewInquiry { get; private set; }

		public ConnectForm(IDbCommonConnectionPlugin data = null)
		{
			InitializeComponent();
		}

		private void ConnectForm_Load(object sender, EventArgs e)
		{
			txtInquiryProvider.Properties.Items.Add(new InquiryDbProviderManager());
			txtInquiryProvider.Properties.Items.Add(new InquiryFileProviderManager());

			txtInquiryProvider.SelectedIndex = 0;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				IDbCommonConnection dbConnection = dbConnectControl.GetConnection();
				ObjectInquiryProvider inquiryProvider = null;

				if (checkInquirySameAsDb.Checked)
				{
					inquiryProvider = new InquiryDbProvider(dbConnection);
				}

				NewInquiry = new DomainObjectInquiry(inquiryProvider, dbConnection);

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnDeployDB_Click(object sender, EventArgs e)
		{
			try
			{
				ObjectInquiryProvider inquiryProvider = null;
				if (checkInquirySameAsDb.Checked)
				{
					IDbCommonConnection dbConnection = dbConnectControl.GetConnection();
					inquiryProvider = new InquiryDbProvider(dbConnection);
				}
				else
				{
					if (inquiryProviderControlPanel.Controls.Count > 0)
					{
						InquiryProviderControl providerControl = inquiryProviderControlPanel.Controls[0] as InquiryProviderControl;
						inquiryProvider = providerControl.GetInquiryProvider();
					}
				}

				if (inquiryProvider != null)
				{
					inquiryProvider.Deploy();
					XtraMessageBox.Show(ConnectFormLocalization.DeployORMSchemeCompletedMessage);
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void checkInquirySameAsDb_CheckedChanged(object sender, EventArgs e)
		{
			txtInquiryProvider.Enabled = !checkInquirySameAsDb.Checked;
			inquiryProviderControlPanel.Enabled = !checkInquirySameAsDb.Checked;
		}

		private void txtInquiryProvider_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				inquiryProviderControlPanel.Controls.Clear();
				InquiryProviderManager providerManager = txtInquiryProvider.SelectedItem as InquiryProviderManager;

				Control customizationControl = providerManager.GetCustomizationControl();
				customizationControl.Dock = DockStyle.Fill;
				inquiryProviderControlPanel.Controls.Add(customizationControl);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnDeploySequenceScheme_Click(object sender, EventArgs e)
		{
			try
			{
				IDbCommonConnection connection = dbConnectControl.GetConnection();
				connection.DeployORMSequenceScheme();
				connection.CloseConnection();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}
	}

	public abstract class InquiryProviderManager
	{
		public abstract string Title { get; }
		public abstract InquiryProviderControl GetCustomizationControl();

		public override string ToString()
		{
			return Title;
		}
	}

	public class InquiryDbProviderManager : InquiryProviderManager
	{
		public override string Title
		{
			get { return "Database"; }
		}

		public override InquiryProviderControl GetCustomizationControl()
		{
			return new InquiryDbProviderControl();
		}
	}

	public class InquiryFileProviderManager : InquiryProviderManager
	{
		public override string Title
		{
			get { return "File"; }
		}

		public override InquiryProviderControl GetCustomizationControl()
		{
			return new InquiryFileProviderControl();
		}
	}

	public class InquiryProviderControl : RuntimeControl
	{
		public virtual ObjectInquiryProvider GetInquiryProvider()
		{
			throw new NotImplementedException();
		}
	}
}