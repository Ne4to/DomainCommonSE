using System;
using System.ComponentModel.Composition;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ConfigLibrary.EditControls
{
	public partial class DateTimeEditControl : EditValueControl
	{
		public DateTimeEditControl()
		{
			InitializeComponent();
		}

		public object EditValue
		{
			get
			{
				return dateEdit.DateTime;
			}
			set
			{
				dateEdit.DateTime = (DateTime)value;
			}
		}
	}

	[Export(typeof(IDbCommonEditValuePlugin))]
	public class DateTimeEditValuePlugin : IDbCommonEditValuePlugin
	{
		public Type ValueType
		{
			get { return typeof(DateTime); }
		}

		public EditValueControl GetControl()
		{
			return new DateTimeEditControl();
		}
	}

	public abstract class EditValueControl : RuntimeControl, IEditValueControl
	{
		public object EditValue { get; set; }
	}
}
