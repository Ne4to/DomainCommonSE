using System;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.DomainConfig
{
	internal class DomainObjectBroker
	{
		public const string ObjectIdField = "ID";

		DomainObjectBrokerBuilder m_brokerBuilder;

		readonly Lazy<DbCommonCommand> m_newItemCommand;
		public DbCommonCommand NewItemCommand { get { return m_newItemCommand.Value; } }

		readonly Lazy<DbCommonCommand> m_loadItemsCommand;
		public DbCommonCommand LoadItemsCommand { get { return m_loadItemsCommand.Value; } }

		readonly Lazy<DbCommonCommand> m_loadLinkedItemsCommand;
		public DbCommonCommand LoadLinkedItemsCommand { get { return m_loadLinkedItemsCommand.Value; } }

		readonly Lazy<DbCommonCommand> m_saveItemCommand;
		public DbCommonCommand SaveItemCommand { get { return m_saveItemCommand.Value; } }

		readonly Lazy<DbCommonCommand> m_deleteItemsCommand;
		public DbCommonCommand DeleteItemsCommand { get { return m_deleteItemsCommand.Value; } }

		public DomainLinkConfig GetLinkConfig(string linkCode)
		{
			return m_brokerBuilder.GetLinkConfig(linkCode);
		}
		
		public DomainObjectBroker(DomainObjectBrokerBuilder brokerBuilder)
		{
			m_brokerBuilder = brokerBuilder;

			m_newItemCommand = new Lazy<DbCommonCommand>(m_brokerBuilder.GetNewItemCommand);
			m_loadItemsCommand = new Lazy<DbCommonCommand>(m_brokerBuilder.GetLoadItemsCommand);
			m_loadLinkedItemsCommand = new Lazy<DbCommonCommand>(m_brokerBuilder.GetLoadLinkedItemsCommand);
			m_saveItemCommand = new Lazy<DbCommonCommand>(m_brokerBuilder.GetSaveItemCommand);
			m_deleteItemsCommand = new Lazy<DbCommonCommand>(m_brokerBuilder.GetDeleteItemsCommand);
		}
	}
}