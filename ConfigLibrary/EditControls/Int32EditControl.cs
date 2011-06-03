using System;
using System.ComponentModel.Composition;

namespace DomainCommonSE.ConfigLibrary.EditControls
{
	public partial class Int32EditControl : NumberEditControl
	{
		public Int32EditControl()
		{
			InitializeComponent();

			IsFloatValue = false;
			MinValue = Int32.MinValue;
			MaxValue = Int32.MaxValue;
		}

		public object EditValue
		{
			get
			{
				return Convert.ToInt32(Value);
			}
			set
			{
				Value = Convert.ToDecimal(value);
			}
		}
	}

	[Export(typeof(IDbCommonEditValuePlugin))]
	public class Int32EditValuePlugin : IDbCommonEditValuePlugin
	{
		public Type ValueType
		{
			get { return typeof(Int32); }
		}

		public EditValueControl GetControl()
		{
			return new Int32EditControl();
		}
	}
}
