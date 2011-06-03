using System;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.DomainConfig
{
	internal class DomainLinkBroker
	{
		public const string LeftObjectIdParam = "LEFT_ID";
		public const string RightObjectIdParam = "RIGHT_ID";

		readonly Lazy<DbCommonCommand> m_newItemCommand;
		public DbCommonCommand NewItemCommand { get { return m_newItemCommand.Value; } }

		readonly Lazy<DbCommonCommand> m_deleteItemCommand;
		public DbCommonCommand DeleteItemCommand { get { return m_deleteItemCommand.Value; } }

		public DomainLinkBroker(DomainLinkBrokerBuilder brokerBuilder)
		{
			m_newItemCommand = new Lazy<DbCommonCommand>(brokerBuilder.GetNewItemCommand);
			m_deleteItemCommand = new Lazy<DbCommonCommand>(brokerBuilder.GetDeleteItemCommand);
		}
	}
}
