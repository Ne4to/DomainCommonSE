using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DomainCommonSE.DbCommon;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace DomainCommonSE.MsSqlCe40.Config
{
	[Export(typeof(IDbCommonConnectionPlugin))]
	public class MsSqlCe40Plugin : DbCommonConnectionPlugin
	{
		public override string ConnectionName
		{
			get { return "MsSqlCe40"; }
		}

		public override Type ControlType
		{
			get { return typeof(MsSqlCe40ConnectControl); }
		}

		public override Type ConnectionType
		{
			get { return typeof(DbCommonMsSqlCe40Connection); }
		}

		public override Type LoginDataType
		{
			get { return typeof(MsSqlCe40LoginData); }
		}
	}
}
