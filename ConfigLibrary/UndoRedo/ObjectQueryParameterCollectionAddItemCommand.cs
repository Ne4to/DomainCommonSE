using System;
using DomainCommonSE.ObjQuery;

namespace DomainCommonSE.ConfigLibrary.UndoRedo
{
	public class ObjectQueryParameterCollectionAddItemCommand : Command
	{
		DomainObjectInquiry m_inquiry;
		public ObjectQueryParameter Param { get; private set; }

		public ObjectQuery Query { get; private set; }

		public ObjectQueryParameterCollectionAddItemCommand(DomainObjectInquiry inquiry, ObjectQuery query)
		{
			m_inquiry = inquiry;
			Query = query;
		}

		public override void Execute()
		{
			throw new NotImplementedException();
			//Param = m_inquiry.CreateQueryParameter(Query);
		}

		public override void UnExecute()
		{
			throw new NotImplementedException();
			//m_inquiry.RemoveQueryParameter(Param);
		}
	}
}
