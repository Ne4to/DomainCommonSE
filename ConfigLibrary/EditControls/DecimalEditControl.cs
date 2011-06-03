using System;
using System.ComponentModel.Composition;

namespace DomainCommonSE.ConfigLibrary.EditControls
{
	public partial class DecimalEditControl : NumberEditControl
	{
		public DecimalEditControl()
		{
			InitializeComponent();

			IsFloatValue = true;
			MinValue = Decimal.MinValue;
			MaxValue = Decimal.MaxValue;
		}

		public object EditValue
		{
			get
			{
				return Value;
			}
			set
			{
				Value = Convert.ToDecimal(value);
			}
		}
	}

	[Export(typeof(IDbCommonEditValuePlugin))]
	public class DecimalEditValuePlugin : IDbCommonEditValuePlugin
	{
		public Type ValueType
		{
			get { return typeof(Decimal); }
		}

		public EditValueControl GetControl()
		{
			return new DecimalEditControl();
		}
	}
}
