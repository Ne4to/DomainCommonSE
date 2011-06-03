using System;
using System.ComponentModel.Composition;

namespace DomainCommonSE.ConfigLibrary.EditControls
{
	public partial class DoubleEditControl : NumberEditControl
	{
		public DoubleEditControl()
		{
			InitializeComponent();

			IsFloatValue = true;
			MinValue = Convert.ToDecimal(Double.MinValue);
			MaxValue = Convert.ToDecimal(Double.MaxValue);
		}

		public object EditValue
		{
			get
			{
				return Convert.ToDecimal(Value);
			}
			set
			{
				Value = Convert.ToDecimal(value);
			}
		}
	}

	[Export(typeof(IDbCommonEditValuePlugin))]
	public class DoubleEditValuePlugin : IDbCommonEditValuePlugin
	{
		public Type ValueType
		{
			get { return typeof(Double); }
		}

		public EditValueControl GetControl()
		{
			return new DoubleEditControl();
		}
	}
}
