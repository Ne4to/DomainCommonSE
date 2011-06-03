using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.ConfigLibrary.EditControls;
using DomainCommonSE.ConfigLibrary.Localization;
using DomainCommonSE.DomainConfig;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class EditPropertyForm : XtraForm
	{
		DomainObjectInquiry m_inquiry;
		DomainObjectConfig m_object;
		DomainPropertyConfig m_property;

		EditValueControl m_editControl;
		Type m_editType;

		public DomainPropertyConfig Property
		{
			get
			{
				return m_property;
			}
		}

		private void FillDataType()
		{
			txtDataType.Properties.Items.AddRange(m_inquiry.Connection.GetAvailableDataType());

			if (txtDataType.Properties.Items.Count > 0)
				txtDataType.SelectedIndex = 0;
		}

		private object GetDefaultValue()
		{
			if (m_editControl != null && m_editType != null)
			    return m_editControl.EditValue;

			if (m_editType != null)
				return Activator.CreateInstance(m_editType);

			return null;
		}

		public EditPropertyForm(DomainObjectInquiry inquiry, DomainObjectConfig obj, DomainPropertyConfig prop)
		{
			InitializeComponent();

			m_inquiry = inquiry;
			m_object = obj;
			m_property = prop;

			FillDataType();
			
			if (m_property != null)
			{
				txtCode.Text = m_property.Code;
				txtCode.Enabled = false;

				txtCodeName.Text = m_property.CodeName;
				txtDescription.Text = m_property.Description;

				txtDataType.SelectedItem = m_property.DataType;
				txtDataType.Enabled = false;

				txtLength.Value = m_property.Size;
				txtLength.Enabled = false;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				string code = txtCode.Text.Trim();
				string codeName = txtCodeName.Text.Trim();

				if (String.IsNullOrEmpty(code))
				{
					MessageBox.Show(EditPropertyFormLocalization.EnterPropertyCodeMessage);
					return;
				}

				if (String.IsNullOrEmpty(codeName))
				{
					MessageBox.Show(EditPropertyFormLocalization.EnterPropertyFieldNameMessage);
					return;
				}

				if (m_property == null && m_object.Property.Contains(code))
				{
					MessageBox.Show(GetPropertyAlreadyExistMessage(code));
					return;
				}

				Type dataType = (Type)txtDataType.SelectedItem;
				string description = txtDescription.Text.Trim();
				object defaultValue = null;
				int length = (int)txtLength.Value;

				try
				{
					defaultValue = GetDefaultValue();
				}
				catch (Exception ex)
				{
					MessageBox.Show(String.Format(EditPropertyFormLocalization.GetDefaultValueErrorMessage, ex.Message));
					return;
				}

				if (m_property == null)
				{
					m_property = m_inquiry.CreateProperty(m_object, code, description, dataType, String.Format("P_{0}", code), defaultValue, length, codeName);
				}
				else
				{
					m_inquiry.SaveProperty(m_property, codeName, description, defaultValue);
				}

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void txtDataType_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				m_editType = (Type)txtDataType.SelectedItem;

				if (m_editControl != null)
				{
					editValuePanel.Controls.Remove(m_editControl);
				}

				m_editControl = ConfigInquiry.Instance.GetEditControl(m_editType);
				if (m_editControl != null)
				{
					m_editControl.Dock = DockStyle.Fill;
					editValuePanel.Controls.Add(m_editControl);
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
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
			bool goodValidate = !m_object.Property.Contains(code);
			if (goodValidate)
			{
				txtCode.ErrorText = String.Empty;
				e.Cancel = false;
			}
			else
			{
				txtCode.ErrorText = GetPropertyAlreadyExistMessage(code);
				e.Cancel = true;
			}	
		}

		private static string GetPropertyAlreadyExistMessage(string code)
		{
			return String.Format(EditPropertyFormLocalization.PropertyWithCodeAlreadyExistMessage, code);
		}
	}
}
