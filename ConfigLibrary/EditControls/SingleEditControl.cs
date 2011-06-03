using System;
using System.ComponentModel.Composition;

namespace DomainCommonSE.ConfigLibrary.EditControls
{
	public partial class SingleEditControl : NumberEditControl
	{
		public SingleEditControl()
		{
			InitializeComponent();

			IsFloatValue = true;
			MinValue = Convert.ToDecimal(Single.MinValue);
			MaxValue = Convert.ToDecimal(Single.MaxValue);
		}		

		public object EditValue
		{
			get
			{
				return Convert.ToSingle(Value);
			}
			set
			{
				Value = Convert.ToDecimal(value);
			}
		}
	}

	[Export(typeof(IDbCommonEditValuePlugin))]
	public class SingleEditValuePlugin : IDbCommonEditValuePlugin
	{
		public Type ValueType
		{
			get { return typeof(Single); }
		}

		public EditValueControl GetControl()
		{
			return new SingleEditControl();
		}
	}
}
