using System;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.MsSqlCe40.Config
{	
	public class MsSqlCe40LoginData : ConnectionLoginData
	{
		public string FilePath { get; set; }
		public string Password { get; set; }
		public int LCID { get; set; }

		public MsSqlCe40LoginData(string filePath, string password, int lcid)
		{
			FilePath = filePath;
			Password = password;
			LCID = lcid;
		}

		public MsSqlCe40LoginData()
		{
		}


		public override bool Equals(object obj)
		{
			MsSqlCe40LoginData data = obj as MsSqlCe40LoginData;

			return FilePath == data.FilePath && Password == data.Password && LCID == data.LCID;
		}

		public override int GetHashCode()
		{
			return FilePath.GetHashCode() ^ Password.GetHashCode() ^ LCID.GetHashCode();
		}
	}
}
