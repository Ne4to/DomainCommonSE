using System.ComponentModel;

namespace DomainCommonSE.ConfigLibrary.EditControls
{
	public partial class NumberEditControl : EditValueControl
	{
		public NumberEditControl()
		{
			InitializeComponent();
		}

		public decimal Value
		{
			get
			{
				return txtValue.Value;
			}
			set
			{
				txtValue.Value = value;
			}
		}

		[DefaultValue(false)]
		public bool IsFloatValue
		{
			get
			{
				return txtValue.Properties.IsFloatValue;
			}
			set
			{
				txtValue.Properties.IsFloatValue = value;
			}
		}

		public decimal MinValue
		{
			get
			{
				return txtValue.Properties.MinValue;
			}
			set
			{
				txtValue.Properties.MinValue = value;
			}
		}

		public decimal MaxValue
		{
			get
			{
				return txtValue.Properties.MaxValue;
			}
			set
			{
				txtValue.Properties.MaxValue = value;
			}
		}

		//[DefaultValue(0)]
		//public int Precision
		//{
		//    get
		//    {				
		//        return txtValue.Properties.Precision;				
		//    }
		//    set
		//    {
		//        txtValue.Properties.Precision = value;
		//    }
		//}

		[DefaultValue("")]
		public string DisplayFormat
		{
			get
			{
				return txtValue.Properties.DisplayFormat.FormatString;
			}
			set
			{
				txtValue.Properties.DisplayFormat.FormatString = value;
			}
		}

		[DefaultValue("")]
		public string EditFormat
		{
			get
			{
				return txtValue.Properties.EditFormat.FormatString;
			}
			set
			{
				txtValue.Properties.EditFormat.FormatString = value;
			}
		}

		[DefaultValue("")]
		public string EditMask
		{
			get
			{
				return txtValue.Properties.EditMask;
			}
			set
			{
				txtValue.Properties.EditMask = value;
			}
		}
	}
}
