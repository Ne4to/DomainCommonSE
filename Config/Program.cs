using System;
using System.Windows.Forms;
using DomainCommonSE.ConfigLibrary;
using System.Globalization;
using System.Threading;

namespace DomainCommonSE.Config
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
#if DEBUG
			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en");
#endif
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
