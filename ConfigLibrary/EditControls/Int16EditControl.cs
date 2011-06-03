using System;
using System.ComponentModel.Composition;

namespace DomainCommonSE.ConfigLibrary.EditControls
{
	public partial class Int16EditControl : NumberEditControl
	{
		public Int16EditControl()
		{
			InitializeComponent();

			IsFloatValue = false;
			MinValue = Int16.MinValue;
			MaxValue = Int16.MaxValue;
		}		

		public object EditValue
		{
			get
			{
				return Convert.ToInt16(Value);
			}
			set
			{
				Value = Convert.ToDecimal(value);
			}
		}		
	}

	[Export(typeof(IDbCommonEditValuePlugin))]
	public class Int16EditValuePlugin : IDbCommonEditValuePlugin
	{
		public Type ValueType
		{
			get { return typeof(Int16); }
		}

		public EditValueControl GetControl()
		{
			return new Int16EditControl();
		}
	}
}
