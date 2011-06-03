using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainCommonSE.DomainConfig;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE
{
	public class InquiryFileProvider : ObjectInquiryProvider
	{
		string m_filePath;
		public InquiryFileProvider(string filePath)
		{
			m_filePath = filePath;
		}

		public override void Deploy()
		{
			throw new NotImplementedException();
		}

		public override DomainObjectConfigCollection LoadObject()
		{
			throw new NotImplementedException();
		}

		public override List<DomainLinkConfig> LoadLink()
		{
			throw new NotImplementedException();
		}

		public override ObjectQueryCollection LoadQuery()
		{
			throw new NotImplementedException();
		}

		public override void Save()
		{
			throw new NotImplementedException();
		}

		public override void CreateObject(DomainObjectConfig objConfig)
		{
			throw new NotImplementedException();
		}

		public override void SaveObject(DomainObjectConfig objConfig)
		{
			throw new NotImplementedException();
		}

		public override void DeleteObject(DomainObjectConfig objConfig)
		{
			throw new NotImplementedException();
		}

		public override void CreateObjectProperty(DomainPropertyConfig propConfig)
		{
			throw new NotImplementedException();
		}

		public override void SaveObjectProperty(DomainPropertyConfig propConfig)
		{
			throw new NotImplementedException();
		}

		public override void DeleteObjectProperty(DomainPropertyConfig propConfig)
		{
			throw new NotImplementedException();
		}

		public override void CreateLink(CreateLinkParams createParams)
		{
			throw new NotImplementedException();
		}

		public override void SaveLink(DomainLinkConfig link, EditLinkParams editParams)
		{
			throw new NotImplementedException();
		}

		public override void DeleteLink(DomainLinkConfig link)
		{
			throw new NotImplementedException();
		}

		public override void CreateObjectQuery(ObjectQuery query)
		{
			throw new NotImplementedException();
		}

		public override void SaveObjectQuery(ObjectQuery query, EditObjectQueryParams editParams)
		{
			throw new NotImplementedException();
		}

		public override void DeleteObjectQuery(ObjectQuery query)
		{
			throw new NotImplementedException();
		}
	}
}
