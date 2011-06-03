using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using DomainCommonSE.ConfigLibrary.EditControls;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ConfigLibrary
{
	public class ConfigInquiry
	{
		const string SettingsFileName = "config.xml";
		const string ApplicationFolder = "DomainCommonSE";
		string m_settingsFullFilePath;
		string SettingsFullFilePath
		{
			get
			{
				if (String.IsNullOrEmpty(m_settingsFullFilePath))
				{
					m_settingsFullFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), ApplicationFolder, SettingsFileName);
				}

				return m_settingsFullFilePath;
			}
		}

		public ConfigSettings CfgSettings { get; private set; }
		public LoginDataSettings LoginData { get; private set; }

		private static ConfigInquiry m_instance;
		public static ConfigInquiry Instance
		{
			get
			{
				if (m_instance == null)
				{
					m_instance = new ConfigInquiry();
				}

				return m_instance;
			}
		}

		[ImportMany(typeof(IDbCommonConnectionPlugin))]
		public IEnumerable<IDbCommonConnectionPlugin> ConnectPlugin { get; private set; }

		[ImportMany(typeof(IDbCommonEditValuePlugin))]
		public IEnumerable<IDbCommonEditValuePlugin> EditValuePlugin { get; private set; }

		public EditValueControl GetEditControl(Type dataType)
		{
			IDbCommonEditValuePlugin plugin = EditValuePlugin.FirstOrDefault<IDbCommonEditValuePlugin>(pl => pl.ValueType == dataType);
			if (plugin == null)
				return null;

			return plugin.GetControl();
		}

		private ConfigInquiry()
		{
			try
			{
				CfgSettings = Utils.DeserializeObjectXMLFile<ConfigSettings>(SettingsFullFilePath);
			}
			catch (Exception)
			{
				CfgSettings = new ConfigSettings();
			}

			LoadPlugins();

			LoginData = new LoginDataSettings();
		}

		const string DbPluginFolder = "DbPlugin";
		public void LoadPlugins()
		{
			AggregateCatalog catalog = new AggregateCatalog();

			Assembly callingAssembly = Assembly.GetCallingAssembly();
			catalog.Catalogs.Add(new AssemblyCatalog(callingAssembly));

			string pluginFolderFullPath = Path.Combine(Directory.GetParent(callingAssembly.Location).FullName, DbPluginFolder);
			if (Directory.Exists(pluginFolderFullPath))
			{
				foreach (string assemblyPath in Directory.GetFiles(pluginFolderFullPath, "*.dll"))
				{
					catalog.Catalogs.Add(new AssemblyCatalog(Assembly.LoadFrom(assemblyPath)));
				}
			}

			CompositionContainer container = new CompositionContainer(catalog);
			container.ComposeParts(this);
		}

		public void SaveSettings(ConfigSettings newSettings)
		{
			CfgSettings = newSettings;
			Utils.SerializeObjectXMLFile<ConfigSettings>(CfgSettings, SettingsFullFilePath);
		}
	}

	public interface IDbCommonEditValuePlugin
	{
		Type ValueType { get; }
		EditValueControl GetControl();
	}
}
