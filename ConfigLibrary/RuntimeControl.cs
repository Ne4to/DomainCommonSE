using System.ComponentModel;
using DevExpress.XtraEditors;

namespace DomainCommonSE.ConfigLibrary
{
	public partial class RuntimeControl : XtraUserControl
	{		
		public RuntimeControl()
		{
			InitializeComponent();

			IsRuntime = LicenseManager.UsageMode == LicenseUsageMode.Runtime;
		}

		protected bool IsRuntime { get; private set; }
	}
}
