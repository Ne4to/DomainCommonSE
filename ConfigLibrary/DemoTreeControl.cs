using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EnvDTE;

namespace DomainCommonSE.ConfigLibrary
{
	[Guid("4B06D9EA-2850-4854-A4D3-DE14475A58AB")]
	public partial class DemoTreeControl : UserControl, UIHierarchy
	{
		public DemoTreeControl()
		{
			InitializeComponent();
		}

		#region UIHierarchy Members

		public DTE DTE
		{
			get { throw new NotImplementedException(); }
		}

		public void DoDefaultAction()
		{
			throw new NotImplementedException();
		}

		public UIHierarchyItem GetItem(string Names)
		{
			throw new NotImplementedException();
		}

		public new Window Parent
		{
			get { throw new NotImplementedException(); }
		}

		public void SelectDown(vsUISelectionType How, int Count)
		{
			throw new NotImplementedException();
		}

		public void SelectUp(vsUISelectionType How, int Count)
		{
			throw new NotImplementedException();
		}

		public dynamic SelectedItems
		{
			get { throw new NotImplementedException(); }
		}

		public UIHierarchyItems UIHierarchyItems
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}
