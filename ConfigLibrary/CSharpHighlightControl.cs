using System;
using System.Drawing;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class CSharpHighlightControl : DomainCommonSE.ConfigLibrary.HighlightRichEditControl
	{
		public CSharpHighlightControl()
		{
			InitializeComponent();
		}

		private void CSharpHighlightControl_Load(object sender, EventArgs e)
		{
			if (m_isRuntime)
			{
				m_wrapper.AddColorHighlight(Color.Blue, new string[] { "class", "public", "private", "internal", "protected", "partial" });
				m_wrapper.Prepare();
			}
		}
	}
}
