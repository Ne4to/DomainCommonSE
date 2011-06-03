using System;
using System.ComponentModel.Composition;

namespace DomainCommonSE.ConfigLibrary.EditControls
{
	public partial class StringEditControl : EditValueControl
	{
		public StringEditControl()
		{
			InitializeComponent();
		}

		public object EditValue
		{
			get 
			{
				return txtEdit.Text; 
			}
			set
			{
				txtEdit.Text = value.ToString();
			}
		}
	}

	[Export(typeof(IDbCommonEditValuePlugin))]
	public class StringEditValuePlugin : IDbCommonEditValuePlugin
	{		
		public Type ValueType
		{
			get { return typeof(string); }
		}

		public EditValueControl GetControl()
		{
			return new StringEditControl();
		}
	}
}
