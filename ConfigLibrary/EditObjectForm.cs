using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.ConfigLibrary.Localization;
using DomainCommonSE.DomainConfig;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class EditObjectForm : XtraForm
	{
		DomainObjectInquiry m_inquiry;
		DomainObjectConfig m_object;

		public DomainObjectConfig Object
		{
			get
			{
				return m_object;
			}
		}

		public EditObjectForm(DomainObjectInquiry inquiry, DomainObjectConfig obj)
		{
			InitializeComponent();
			
			m_inquiry = inquiry;
			m_object = obj;

			if (obj != null)
			{
				txtCode.Enabled = false;
				txtCode.Text = obj.Code;
				txtCodeName.Text = obj.CodeName;
				txtDescription.Text = obj.Description;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			string code = txtCode.Text.Trim();
			string codeName = txtCodeName.Text.Trim();
			string description = txtDescription.Text.Trim();

			if (String.IsNullOrEmpty(code))
			{
				MessageBox.Show(EditObjectFormLocalization.EnterObjectCodeMessage);
				return;
			}

			if (String.IsNullOrEmpty(codeName))
			{
				MessageBox.Show(EditObjectFormLocalization.EnterObjectClassNameMessage);
				return;
			}

			if (m_object == null)
			{
				if (m_inquiry.AObject.Contains(code))
				{
					MessageBox.Show(GetCodeAlreadyExistMessage(code));
					return;
				}

				m_object = m_inquiry.CreateObject(code, description, codeName);
			}
			else
			{
				m_inquiry.SaveObject(m_object, codeName, description);
			}

			DialogResult = DialogResult.OK;
		}

		private void txtCode_EditValueChanged(object sender, EventArgs e)
		{
			txtCodeName.Text = Utils.GetBestName(txtCode.Text);
			txtCode.DoValidate();
		}

		private void txtCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			txtCode.ErrorIconAlignment = ErrorIconAlignment.MiddleRight;
			string code = txtCode.Text.Trim();
			bool goodValidate = !m_inquiry.AObject.Contains(code);
			if (goodValidate)
			{
				txtCode.ErrorText = String.Empty;
				e.Cancel = false;
			}
			else
			{
				txtCode.ErrorText = GetCodeAlreadyExistMessage(code);
				e.Cancel = true;
			}					
		}

		private static string GetCodeAlreadyExistMessage(string code)
		{
			return String.Format(EditObjectFormLocalization.ObjectWithCodeAlreadyExistMessage, code);
		}
	}
}
