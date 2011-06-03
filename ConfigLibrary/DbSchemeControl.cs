using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class DbSchemeControl : DevExpress.XtraEditors.XtraUserControl
	{
		public DbSchemeControl()
		{
			InitializeComponent();
		}

		public void BuildTree(DbCommonScheme scheme)
		{			
			tree.ClearNodes();

			foreach (DbCommonSchemeTable table in scheme.Tables)
			{
				TreeListNode tableNode = tree.AppendNode(new object[] { table.Name }, null, table);
				foreach (DbCommonSchemeTableField field in table.Fields)
				{
					tree.AppendNode(new object[] { field.Name, field.DataType }, tableNode, field);
				}
			}
		}

		private void tree_DragDrop(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}
	}
}
