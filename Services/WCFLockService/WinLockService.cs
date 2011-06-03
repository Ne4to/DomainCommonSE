using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace WCFLockService
{
	public partial class WinLockService : ServiceBase
	{
		public const string WinServiceName = "EntityObjectORMLockService";

		internal static ServiceHost myServiceHost = null;

		public WinLockService()
		{
			InitializeComponent();
			ServiceName = WinServiceName;
		}

		protected override void OnStart(string[] args)
		{
			if (myServiceHost != null)
			{
				myServiceHost.Close();
			}

			myServiceHost = new ServiceHost(typeof(LockService));
			myServiceHost.Open();
		}

		protected override void OnStop()
		{
			if (myServiceHost != null)
			{
				myServiceHost.Close();
				myServiceHost = null;
			}
		}
	}
}
