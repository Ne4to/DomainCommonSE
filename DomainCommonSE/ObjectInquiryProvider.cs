using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

using DomainCommonSE.DomainConfig;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE
{
	public abstract class ObjectInquiryProvider
	{
		public abstract void Deploy();

		public abstract DomainObjectConfigCollection LoadObject();
		public abstract List<DomainLinkConfig> LoadLink();
		public abstract ObjectQueryCollection LoadQuery();
		public abstract void Save();

		public abstract void CreateObject(DomainObjectConfig objConfig);
		public abstract void SaveObject(DomainObjectConfig objConfig);
		public abstract void DeleteObject(DomainObjectConfig objConfig);

		public abstract void CreateObjectProperty(DomainPropertyConfig propConfig);
		public abstract void SaveObjectProperty(DomainPropertyConfig propConfig);
		public abstract void DeleteObjectProperty(DomainPropertyConfig propConfig);

		public abstract void CreateLink(CreateLinkParams createParams);
		public abstract void SaveLink(DomainLinkConfig link, EditLinkParams editParams);
		public abstract void DeleteLink(DomainLinkConfig link);

		public abstract void CreateObjectQuery(ObjectQuery query);
		public abstract void SaveObjectQuery(ObjectQuery query, EditObjectQueryParams editParams);
		public abstract void DeleteObjectQuery(ObjectQuery query);

		protected Type GetValueType(string assemblyFilename, string typeName)
		{
			//throw new NotImplementedException("переделать чтобы повторно не искать типы");

			Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.ManifestModule.Name.Equals(assemblyFilename, StringComparison.InvariantCultureIgnoreCase));
			if (assembly == null)
				throw new DomainException(String.Format("При получении типа {0} из сборки {1} не удалось загрузить сборку.", typeName, assemblyFilename));

			return assembly.GetType(typeName, true);
		}
	}
}