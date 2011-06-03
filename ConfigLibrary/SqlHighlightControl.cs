using System;
using System.Drawing;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class SqlHighlightControl : DomainCommonSE.ConfigLibrary.HighlightRichEditControl
	{
		public SqlHighlightControl()
		{
			InitializeComponent();
		}

		private void SqlHighlightControl_Load(object sender, EventArgs e)
		{
			if (m_isRuntime)
			{
				m_wrapper.AddColorHighlight(Color.Blue, new string[] { "INSERT", "SELECT", "UPDATE", "DELETE", "FROM", "WHERE", "TABLE", "NOT", "NULL", "IS", "AS", "AND", "OR", "IN", "INTO" });
				m_wrapper.Prepare();
			}
		}
	}
}
