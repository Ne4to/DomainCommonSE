using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.ConfigLibrary.UndoRedo;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE.ConfigLibrary.PropertyEditRow
{
	public partial class EditObjectQueryParameterCollectionForm : XtraForm
	{
		UndoRedoManager undoRedoManager;
		DomainObjectInquiry m_inquiry;
		ObjectQuery m_query;

		public EditObjectQueryParameterCollectionForm()
		{
			InitializeComponent();
		}

		public void Init(DomainObjectInquiry inquiry, ObjectQuery query)
		{
			undoRedoManager = new UndoRedoManager();
			m_inquiry = inquiry;
			m_query = query;
		}

		private void EditObjectQueryParameterCollectionForm_Load(object sender, EventArgs e)
		{
			foreach (ObjectQueryParameter param in m_query.Parameters)
			{
				listMembers.Items.Add(new MemberNode(param));
			}
		}

		private void listMembers_SelectedValueChanged(object sender, EventArgs e)
		{
			MemberNode node = listMembers.SelectedItem as MemberNode;
			if (node == null)
				return;
			propertyGrid.SelectedObject = node.Value;
		}

		private void btnAddParam_Click(object sender, EventArgs e)
		{
			try
			{
				ObjectQueryParameterCollectionAddItemCommand newCommand = new ObjectQueryParameterCollectionAddItemCommand(m_inquiry, m_query);

				newCommand.Execute();

				undoRedoManager.AddCommand(newCommand);

				int index = listMembers.Items.Add(new MemberNode(newCommand.Param));
				listMembers.SelectedIndex = index;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnRemoveParam_Click(object sender, EventArgs e)
		{
			try
			{
				MemberNode node = listMembers.SelectedItem as MemberNode;
				if (node == null)
					return;

				ObjectQueryParameterCollectionDeleteItemCommand command = new ObjectQueryParameterCollectionDeleteItemCommand(m_inquiry, m_query, node.Value);

				command.Execute();

				undoRedoManager.AddCommand(command);

				listMembers.Items.Remove(node);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			undoRedoManager.UndoAll();
			DialogResult = DialogResult.Cancel;
		}
	}

	public class MemberNode
	{
		public ObjectQueryParameter Value { get; private set; }

		public MemberNode(ObjectQueryParameter value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return Value.Code;
		}
	}
}