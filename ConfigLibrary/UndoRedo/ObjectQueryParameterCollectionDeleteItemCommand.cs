using System;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE.ConfigLibrary.UndoRedo
{
	public class ObjectQueryParameterCollectionDeleteItemCommand : Command
	{
		DomainObjectInquiry m_inquiry;
		ObjectQueryParameter m_param;

		public ObjectQuery Query { get; private set; }

		public ObjectQueryParameterCollectionDeleteItemCommand(DomainObjectInquiry inquiry, ObjectQuery query, ObjectQueryParameter param)
		{
			m_inquiry = inquiry;
			Query = query;
			m_param = param;
		}

		public override void Execute()
		{
			throw new NotImplementedException();
			//m_inquiry.RemoveQueryParameter(m_param);
		}

		public override void UnExecute()
		{
			throw new NotImplementedException();
			//ObjectQueryParameter newParam = m_inquiry.CreateQueryParameter(Query);

			//newParam.Code = m_param.Code;
			//newParam.DataType = m_param.DataType;
		}
	}
}
