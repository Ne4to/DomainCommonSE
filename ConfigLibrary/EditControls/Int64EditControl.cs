using System;
using System.ComponentModel.Composition;

namespace DomainCommonSE.ConfigLibrary.EditControls
{
	public partial class Int64EditControl : NumberEditControl
	{
		public Int64EditControl()
		{
			InitializeComponent();

			IsFloatValue = false;
			MinValue = Int64.MinValue;
			MaxValue = Int64.MaxValue;
		}

		public object EditValue
		{
			get
			{
				return Convert.ToInt64(Value);
			}
			set
			{
				Value = Convert.ToDecimal(value);
			}
		}
	}

	[Export(typeof(IDbCommonEditValuePlugin))]
	public class Int64EditValuePlugin : IDbCommonEditValuePlugin
	{
		public Type ValueType
		{
			get { return typeof(Int64); }
		}

		public EditValueControl GetControl()
		{
			return new Int64EditControl();
		}
	}
}
