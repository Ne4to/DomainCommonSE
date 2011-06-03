using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.DbCommon;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class EditQueryForm : XtraForm
	{
		DomainObjectInquiry m_inquiry;
		public ObjectQuery Query { get; private set; }

		public EditQueryForm(DomainObjectInquiry inquiry, ObjectQuery query = null)
		{
			InitializeComponent();

			if (inquiry == null)
				throw new ArgumentNullException("inquiry");

			m_inquiry = inquiry;
			Query = query;

			foreach (DomainObjectConfig obj in inquiry.AObject)
			{
				txtObjectType.Properties.Items.Add(obj.Code);
			}			

			if (query != null)
			{
				txtCode.Enabled = false;
				txtCode.Text = query.Code;
				txtObjectType.Text = query.ObjectType;
				txtSource.TextValue = query.Source;
				txtDescription.Text = query.Notes;				
			}

			DbCommonScheme scheme = inquiry.Connection.Scheme;
			dbScheme.BuildTree(scheme);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				string code = txtCode.Text.Trim();
				string objectType = txtObjectType.Text.Trim();
				string source = txtSource.TextValue.Trim();
				string notes = txtDescription.Text.Trim();

				if (Query == null)
				{					
					Query = m_inquiry.CreateObjectQuery(code, objectType, source, notes);
				}
				else
				{
					EditObjectQueryParams editParams = new EditObjectQueryParams()
					{
						Code = code,
						ObjectType = objectType,
						Source = source,
						Notes = notes,
					};

					m_inquiry.SaveObjectQuery(Query, editParams);
				}

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}
	}
}