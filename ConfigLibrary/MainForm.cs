using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class MainForm : XtraForm
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void tabControl_CloseButtonClick(object sender, EventArgs e)
		{
			try
			{
				ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
				tabControl.TabPages.Remove(arg.Page as XtraTabPage);
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void ExitButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				Close();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void SettingsButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				using (SettingsForm form = new SettingsForm())
				{
					form.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void NewConnectionButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				UI.Instance.ShowNewConnectionForm();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void NewMainForm_Load(object sender, EventArgs e)
		{
			UI.Instance.ObjectSqlRequest += Instance_ObjectSqlRequest;
			UI.Instance.SourceCodeRequest += Instance_SourceCodeRequest;
		}

		void Instance_ObjectSqlRequest(object sender, ObjectSqlArgs e)
		{
			try
			{
				string sql = String.Empty;
				string tabTitlePostfix = String.Empty;
				switch (e.Kind)
				{
					case ObjectSqlArgs.eKind.Select:
						throw new NotImplementedException();
						//sql = e.Inquiry.GetSelectObjectCommand(e.AObject);
						tabTitlePostfix = "Select";
						break;

					case ObjectSqlArgs.eKind.Insert:
						throw new NotImplementedException();
						//sql = e.Inquiry.GetInsertObjectCommand(e.AObject);
						tabTitlePostfix = "Insert";
						break;

					case ObjectSqlArgs.eKind.Update:
						throw new NotImplementedException();
						//sql = e.Inquiry.GetUpdateObjectCommand(e.AObject);
						tabTitlePostfix = "Update";
						break;

					case ObjectSqlArgs.eKind.Delete:
						throw new NotImplementedException();
						//sql = e.Inquiry.GetDeleteObjectCommand(e.AObject);
						tabTitlePostfix = "Delete";
						break;

					default:
						throw new ArgumentOutOfRangeException("e.Kind");
				}

				SQLQueryControl sqlQuery = new SQLQueryControl(sql);
				sqlQuery.Init(e.Inquiry);
				AddPage(sqlQuery, eTabPageKind.Query, String.Format("{0} ({1} SQL)", e.AObject.Code, tabTitlePostfix));				
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private XtraTabPage AddPage(Control control, eTabPageKind kind, string title)
		{
			XtraTabPage page = new XtraTabPage();
			page.Text = title;

			control.Dock = DockStyle.Fill;
			page.Controls.Add(control);
			page.Tag = kind;

			tabControl.TabPages.Add(page);
			//newTabPage.Text = title;

			//control.Dock = DockStyle.Fill;
			//newTabPage.Controls.Add(control);
			//newTabPage.Tag = kind;

			//tabControl.SelectedTabPage = newTabPage;

			return page;
		}

		void Instance_SourceCodeRequest(object sender, SourceCodeArgs e)
		{
			try
			{
				CSharpHighlightControl control = new CSharpHighlightControl();
				control.TextValue = e.Source;

				AddPage(control, eTabPageKind.SourceCode, "*.cs");							
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void NewMainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				UI.Instance.ObjectSqlRequest -= Instance_ObjectSqlRequest;
				UI.Instance.SourceCodeRequest -= Instance_SourceCodeRequest;

				objectExplorerControl.CloseAllConnections();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnNewQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				SQLQueryControl newControl = new SQLQueryControl();
				newControl.Init(objectExplorerControl.FocusedInquiry);
				AddPage(newControl, eTabPageKind.Query, "new query");
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void tabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
		{
			if (e.Page == null || e.Page.Tag == null)
			{
				queryBar.Visible = false;
				return;
			}

			eTabPageKind kind = (eTabPageKind)e.Page.Tag;
			switch (kind)
			{
				case eTabPageKind.Query:
					queryBar.Visible = true;
					break;

				case eTabPageKind.SourceCode:
					queryBar.Visible = false;
					break;
			}
		}

		private void btnShowDBExplorer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				objectDockPanel.Show();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnShowPropertiesWindow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				propertiesDockPanel.Show();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private TControl GetFocusedControl<TControl>()
			where TControl : class
		{
			return tabControl.SelectedTabPage.Controls[0] as TControl;
		}

		private void btnExecuteQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				SQLQueryControl control = GetFocusedControl<SQLQueryControl>();
				control.ExecuteQuery();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnCommitQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				SQLQueryControl control = GetFocusedControl<SQLQueryControl>();
				control.Commit();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private void btnRollbackQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				SQLQueryControl control = GetFocusedControl<SQLQueryControl>();
				control.Rollback();
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message);
			}
		}

		private enum eTabPageKind
		{
			Query,
			SourceCode
		}

		private void barBtnSaveSession_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{

		}
	}
}