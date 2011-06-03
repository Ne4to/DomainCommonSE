using System;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.DomainConfig
{
	internal class DomainLinkBrokerBuilder
	{
		readonly DomainLinkConfig m_linkConfig;
		readonly IDbCommonConnection m_dbConnection;

		public DomainLinkBrokerBuilder(DomainLinkConfig linkConfig, IDbCommonConnection dbConnection)
		{
			m_linkConfig = linkConfig;
			m_dbConnection = dbConnection;
		}

		public DbCommonCommand GetNewItemCommand()
		{
			string query;

			if (m_linkConfig.LeftRelation == eRelation.Many && m_linkConfig.RightRelation == eRelation.Many) // n-n
			{
				query = String.Format("INSERT INTO {0} ({1}, {2}) VALUES (@{{LEFT_ID}}, @{{RIGHT_ID}})", m_linkConfig.LinkTable, m_linkConfig.LeftObjectIdField, m_linkConfig.RightObjectIdField);
			}
			else
			{
				if (m_linkConfig.LeftRelation == eRelation.One) // 1-n
				{
					query = String.Format("UPDATE {0} SET {1} = @{{LEFT_ID}} WHERE {2} = @{{RIGHT_ID}}", m_linkConfig.RightObject.TableName, m_linkConfig.LeftObjectIdField, m_linkConfig.RightObject.IdField);
				}
				else // n-1
				{
					query = String.Format("UPDATE {0} SET {1} = @{{RIGHT_ID}} WHERE {2} = @{{LEFT_ID}}", m_linkConfig.LeftObject.TableName, m_linkConfig.RightObjectIdField, m_linkConfig.LeftObject.IdField);
				}
			}

			DbCommonCommand command = new DbCommonCommand(query, m_dbConnection);
			command.AddParameter(DomainLinkBroker.LeftObjectIdParam, typeof(long));
			command.AddParameter(DomainLinkBroker.RightObjectIdParam, typeof(long));

			return command;
		}

		public DbCommonCommand GetDeleteItemCommand()
		{
			string query;

			if (m_linkConfig.LeftRelation == eRelation.Many && m_linkConfig.RightRelation == eRelation.Many) // n-n
			{
				query = String.Format("DELETE FROM {0} WHERE {1} = @{{LEFT_ID}} AND {2} = @{{RIGHT_ID}}", m_linkConfig.LinkTable, m_linkConfig.LeftObjectIdField, m_linkConfig.RightObjectIdField);
			}
			else
			{
				if (m_linkConfig.LeftRelation == eRelation.One) // 1-n
				{
					query = String.Format("UPDATE {0} SET {1} = NULL WHERE {1} = @{{LEFT_ID}} AND {2} = @{{RIGHT_ID}}", m_linkConfig.RightObject.TableName, m_linkConfig.LeftObjectIdField, m_linkConfig.RightObject.IdField);
				}
				else // n-1
				{
					query = String.Format("UPDATE {0} SET {1} = NULL WHERE {1} = @{{RIGHT_ID}} AND {2} = @{{LEFT_ID}}", m_linkConfig.LeftObject.TableName, m_linkConfig.RightObjectIdField, m_linkConfig.LeftObject.IdField);
				}
			}

			DbCommonCommand command = new DbCommonCommand(query, m_dbConnection);
			command.AddParameter(DomainLinkBroker.LeftObjectIdParam, typeof(long));
			command.AddParameter(DomainLinkBroker.RightObjectIdParam, typeof(long));

			return command;
		}
	}
}
