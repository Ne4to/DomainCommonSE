using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using ServiceConfig.WCFLockService;
using System.ServiceProcess;
using System.Security.Principal;
using DevExpress.XtraEditors;

namespace ServiceConfig
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			var binding = new NetTcpBinding();
			var address = new EndpointAddress(@"net.tcp://localhost:8523/EntityObjectORMLockService");

			ClientCallback clientCallback = new ClientCallback();
			InstanceContext context = new InstanceContext(clientCallback);
			DuplexChannelFactory<ILockService> factory = new DuplexChannelFactory<ILockService>(context, binding, address);
			ILockService serviceClient = factory.CreateChannel();

			MessageBox.Show(serviceClient.DoWork("Hello World!"));
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			ServiceControllerStatus currentStatus = serviceController.Status;

			if (currentStatus != ServiceControllerStatus.Stopped)
			{
				XtraMessageBox.Show(String.Format("Запуск невозможен, текущий статус службы {0}", currentStatus));
				return;
			}

			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			WindowsPrincipal principal = new WindowsPrincipal(identity);
			bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
			
			if (isAdmin)
			{
				serviceController.Start();
			}
			else
				XtraMessageBox.Show("Не админ"); 
			//ServiceControllerPermissionAccess.
			//serviceController.Start();
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			ServiceControllerStatus currentStatus = serviceController.Status;

			if (currentStatus != ServiceControllerStatus.Running)
			{
				XtraMessageBox.Show(String.Format("Остановка невозможна, текущий статус службы {0}", currentStatus));
				return;
			}

			serviceController.Stop();
		}
	}

	class ClientCallback : ILockServiceCallback
	{
		public void LockIsAvailable(ObjectIdentifier objectId)
		{
			MessageBox.Show(String.Format("objectId = {0}, ", objectId));
		}
	}
}
