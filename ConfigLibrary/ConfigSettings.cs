using System;
using System.Collections.Generic;

namespace DomainCommonSE.ConfigLibrary
{
	public class ConfigSettings : ICloneable
	{
		public List<string> DbConnectionPlugin { get; set; }

		public ConfigSettings()
		{
			DbConnectionPlugin = new List<string>();
		}

		public object Clone()
		{
			ConfigSettings result = new ConfigSettings();
			result.DbConnectionPlugin.AddRange(DbConnectionPlugin);
			return result;
		}	
	}
}
