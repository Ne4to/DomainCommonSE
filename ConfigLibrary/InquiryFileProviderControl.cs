using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class InquiryFileProviderControl : DomainCommonSE.ConfigLibrary.InquiryProviderControl
	{
		public InquiryFileProviderControl()
		{
			InitializeComponent();
		}

		public override ObjectInquiryProvider GetInquiryProvider()
		{
			string filePath = txtFilePath.Text.Trim();
			return new InquiryFileProvider(filePath);
		}

		private void txtFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			try
			{
				if (openFileDialog.ShowDialog() != DialogResult.OK)
					return;

				txtFilePath.Text = openFileDialog.FileName;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}
	}
}
