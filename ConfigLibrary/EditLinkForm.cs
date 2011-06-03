using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.DomainConfig;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class EditLinkForm : XtraForm
	{
		DomainObjectInquiry m_inquiry;
		DomainLinkConfig m_link;

		public DomainLinkConfig Link
		{
			get
			{
				return m_link;
			}
		}

		void FillObjects()
		{
			gridLeftObject.DataSource = new DomainObjectConfigCollectionListSource(m_inquiry.AObject);
			gridRightObject.DataSource = new DomainObjectConfigCollectionListSource(m_inquiry.AObject);
		}

		void EnableControlByRelation()
		{
			eRelation leftRelation = rgLeftRelation.SelectedIndex == 0 ? eRelation.One : eRelation.Many;
			eRelation rightRelation = rgRightRelation.SelectedIndex == 0 ? eRelation.One : eRelation.Many;

			bool isManyToMany = leftRelation == eRelation.Many && rightRelation == eRelation.Many;
			txtLinkTableName.Enabled = isManyToMany;
			txtLeftIdField.Enabled = isManyToMany || leftRelation == eRelation.One;
			txtRightIdField.Enabled = isManyToMany || rightRelation == eRelation.One;

			DomainObjectConfig leftObject = viewLeftObject.GetFocusedRow() as DomainObjectConfig;
			DomainObjectConfig rightObject = viewRightObject.GetFocusedRow() as DomainObjectConfig;

			if (leftObject != null)
			{
				txtLeftIdField.Text = leftObject.IdField;
			}
			else
			{
				txtLeftIdField.Text = String.Empty;
			}

			if (rightObject != null)
			{
				txtRightIdField.Text = rightObject.IdField;
			}
			else
			{
				txtRightIdField.Text = String.Empty;
			}
		}

		public EditLinkForm(DomainObjectInquiry inquiry, DomainLinkConfig link = null)
		{
			InitializeComponent();

			m_inquiry = inquiry;
			m_link = link;

			FillObjects();

			if (link != null)
			{
				txtLinkCode.Enabled = false;
				txtLinkTableName.Enabled = false;

				rgLeftRelation.Enabled = false;
				rgRightRelation.Enabled = false;

				txtLeftIdField.Enabled = false;
				txtRightIdField.Enabled = false;

				gridLeftObject.Enabled = false;
				gridRightObject.Enabled = false;

				txtLinkCode.Text = link.Code;
				txtLinkTableName.Text = link.LinkTable;

				rgLeftRelation.SelectedIndex = link.LeftRelation == eRelation.One ? 0 : 1;
				rgRightRelation.SelectedIndex = link.RightRelation == eRelation.One ? 0 : 1;

				txtLeftIdField.Text = link.LeftObjectIdField;
				txtRightIdField.Text = link.RightObjectIdField;

				gridLeftObjectCodeColumn.View.ActiveFilterString = String.Format("[Code] LIKE '{0}'", link.LeftObject.Code);
				gridRightObjectCodeColumn.View.ActiveFilterString = String.Format("[Code] LIKE '{0}'", link.RightObject.Code);

				cbIsLeftToRight.Checked = link.IsLeftToRightActive;
				cbIsRightToLeft.Checked = link.IsRightToLeftActive;

				txtLeftCollectionName.Text = link.LeftCollectionName;
				txtRightCollectionName.Text = link.RightCollectionName;

				txtLeftToRightDescription.Text = link.LeftToRightDescription;
				txtRightToLeftDescription.Text = link.RightToLeftDescription;
			}
			else
			{
				rgLeftRelation.SelectedIndex = 0;
				rgRightRelation.SelectedIndex = 1;
			}

			EnableControlByRelation();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (m_link == null)
				{
					CreateLinkParams createParams = new CreateLinkParams();

					createParams.Code = txtLinkCode.Text.Trim();

					createParams.LeftObject = viewLeftObject.GetFocusedRow() as DomainObjectConfig;
					createParams.RightObject = viewRightObject.GetFocusedRow() as DomainObjectConfig;

					createParams.LeftRelation = rgLeftRelation.SelectedIndex == 0 ? eRelation.One : eRelation.Many;
					createParams.RightRelation = rgRightRelation.SelectedIndex == 0 ? eRelation.One : eRelation.Many;

					createParams.LeftObjectIdField = txtLeftIdField.Text.Trim();
					createParams.RightObjectIdField = txtRightIdField.Text.Trim();

					createParams.LinkTable = txtLinkTableName.Text.Trim();

					m_link = m_inquiry.CreateLink(createParams);
				}

				EditLinkParams editParams = new EditLinkParams();

				editParams.IsLeftToRightActive = cbIsLeftToRight.Checked;
				editParams.IsRightToLeftActive = cbIsRightToLeft.Checked;

				editParams.LeftCollectionName = txtLeftCollectionName.Text.Trim();
				editParams.RightCollectionName = txtRightCollectionName.Text.Trim();

				editParams.LeftToRightDescription = txtLeftToRightDescription.Text.Trim();
				editParams.RightToLeftDescription = txtRightToLeftDescription.Text.Trim();

				m_inquiry.SaveLink(m_link, editParams);

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void rgRelation_EditValueChanged(object sender, EventArgs e)
		{
			EnableControlByRelation();
		}
	}
}
