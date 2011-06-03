using System;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Rows;
using DomainCommonSE.ConfigLibrary.Localization;
using DomainCommonSE.ConfigLibrary.PropertyEditRow;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class PropertyControl : DevExpress.XtraEditors.XtraUserControl
	{
		public PropertyControl()
		{
			InitializeComponent();
		}

		private DomainObjectInquiry m_inquiry;

		public object EditValue
		{
			get
			{
				return propertyGrid.SelectedObject;
			}
			private set
			{				
				if (value == null)
				{
					propertyGrid.SelectedObject = null;
					return;
				}

				propertyGrid.BeginUpdate();
				propertyGrid.Rows.Clear();

				Type valueType = value.GetType();
				if (valueType == typeof(ObjectQuery))
				{
					ObjectQuery queryValue = value as ObjectQuery;

					AddRow(PropertyControlLocalization.ObjectQueryCodeCaption, "Code");
					AddObjectConfigCodeRow(PropertyControlLocalization.ObjectQueryObjectTypeCaption, "ObjectType", m_inquiry.AObject);
					AddObjectQueryParameterCollectionRow(PropertyControlLocalization.ObjectQueryParametersCaption, "Parameters");
					AddRow(PropertyControlLocalization.ObjectQueryNotesCaption, "Notes");								
				}

				propertyGrid.SelectedObject = value;

				propertyGrid.BestFit();
				propertyGrid.EndUpdate();
			}
		}			

		private void AddRow(string caption, string fieldName)
		{
			EditorRow row = new EditorRow(fieldName);
			row.Properties.Caption = caption;
			propertyGrid.Rows.Add(row);
		}

		private void AddObjectConfigCodeRow(string caption, string fieldName, DomainObjectConfigCollection objList)
		{
			EditorRow row = new EditorRow(fieldName);
			row.Properties.Caption = caption;
			row.Properties.UnboundType = UnboundColumnType.String;
			
			RepositoryItemComboBox rowEdit = new RepositoryItemComboBox();

			rowEdit.MaxLength = 200;
			rowEdit.NullValuePrompt = PropertyControlLocalization.SelectReturnObjectTypeNullPrompt;
			rowEdit.NullValuePromptShowForEmptyValue = true;
			foreach (DomainObjectConfig obj in objList)
			{
				rowEdit.Items.Add(obj.Code);
			}

			row.Properties.RowEdit = rowEdit;					

			propertyGrid.Rows.Add(row);
		}

		private void AddObjectQueryParameterCollectionRow(string caption, string fieldName)
		{
			EditorRow row = new EditorRow(fieldName);
			row.Properties.Caption = caption;	

			RepositoryItemButtonEdit rowEdit = new RepositoryItemButtonEdit();
			rowEdit.TextEditStyle = TextEditStyles.DisableTextEditor;
			rowEdit.ButtonClick += rowEdit_ButtonClick;

			row.Properties.RowEdit = rowEdit;

			propertyGrid.Rows.Add(row);
		}

		void rowEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			try
			{
				ObjectQuery editQuery = ((sender as ButtonEdit).Parent as DevExpress.XtraVerticalGrid.PropertyGridControl).SelectedObject as ObjectQuery;
				//ObjectQueryParameterCollection editParams = (sender as ButtonEdit).EditValue as ObjectQueryParameterCollection;

				using (EditObjectQueryParameterCollectionForm form = new EditObjectQueryParameterCollectionForm())
				{
					form.Init(m_inquiry, editQuery);
					form.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void PropertyControl_Load(object sender, EventArgs e)
		{
			UI.Instance.ShowPropertyRequest += Instance_ShowPropertyRequest;
		}

		void Instance_ShowPropertyRequest(object sender, ShowPropertyRequestArgs e)
		{
			EditValue = e.EditValue;
			m_inquiry = e.Inquiry;
		}
	}
}
