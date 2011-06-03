using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServiceConfig
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			WCFTestService.MyServiceClient myService = new WCFTestService.MyServiceClient();
			MessageBox.Show(myService.DoWork("Hello World!"));
			myService.Close();
		}
	}
}
