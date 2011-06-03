using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.DomainConfig
{
	internal class DomainObjectBrokerBuilder
	{
		readonly DomainObjectConfig m_objectConfig;
		readonly Dictionary<string, DomainLinkConfig> m_links;
		readonly IDbCommonConnection m_dbConnection;

		public DomainObjectBrokerBuilder(DomainObjectConfig objectConfig, IEnumerable<DomainLinkConfig> links, IDbCommonConnection dbConnection)
		{
			m_objectConfig = objectConfig;
			m_links = links.ToDictionary(link => link.Code);
			m_dbConnection = dbConnection;
		}

		public DomainLinkConfig GetLinkConfig(string linkCode)
		{
			return m_links[linkCode];
		}

		public DbCommonCommand GetNewItemCommand()
		{
			StringBuilder query = new StringBuilder();
			query.AppendFormat("INSERT INTO {0} ({1}", m_objectConfig.TableName, m_objectConfig.IdField);
			foreach (DomainPropertyConfig property in m_objectConfig.Property)
				query.AppendFormat(", {0}", property.FieldName);

			query.Append(") VALUES (@{ID} ");
			foreach (DomainPropertyConfig property in m_objectConfig.Property)
				query.AppendFormat(", @{{{0}}}", property.Code);
			query.Append(")");

			DbCommonCommand command = new DbCommonCommand(query.ToString(), m_dbConnection);
			command.AddParameter("ID", typeof(long));
			foreach (DomainPropertyConfig property in m_objectConfig.Property)
				command.AddParameter(property.Code, property.DataType);

			return command;
		}

		public DbCommonCommand GetLoadItemsCommand()
		{
			StringBuilder query = new StringBuilder();
			query.AppendFormat("SELECT {0} as ID", m_objectConfig.IdField);

			foreach (DomainPropertyConfig property in m_objectConfig.Property)
			{
				query.AppendFormat(", {0} AS {1}", m_dbConnection.GetReadTypeString(property.DataType, property.FieldName), property.FieldName);
			}

			query.AppendFormat(" FROM {0} WHERE REMOVED = {1} AND {2} IN(@{{ID}})", m_objectConfig.TableName, m_dbConnection.GetTypeValue(false), m_objectConfig.IdField);

			DbCommonCommand command = new DbCommonCommand(query.ToString(), m_dbConnection);
			command.AddParameter("ID", typeof(long), true);

			return command;
		}

		public DbCommonCommand GetLoadLinkedItemsCommand()
		{
			StringBuilder query = new StringBuilder();

			foreach (DomainLinkConfig link in m_links.Values)
			{
				if (link.LeftRelation == eRelation.Many && link.RightRelation == eRelation.Many)// n-n
				{
					if (link.LeftObject == m_objectConfig)
					{
						query.AppendFormat("SELECT LT.{0} AS LEFT_ID, LT.{1} AS RIGHT_ID, {2} AS LINK_CODE FROM {3} LT, {4} OT WHERE LT.{0} IN (@{{ID}}) AND LT.{1} = OT.{5} AND OT.REMOVED = {6}",
							link.LeftObjectIdField, link.RightObjectIdField, m_dbConnection.GetTypeValue(link.Code), link.LinkTable, link.RightObject.TableName, link.RightObject.IdField, m_dbConnection.GetTypeValue(false));
					}
					else
					{
						query.AppendFormat("SELECT LT.{0} AS LEFT_ID, LT.{1} AS RIGHT_ID, {2} AS LINK_CODE FROM {3} LT, {4} OT WHERE LT.{1} IN (@{{ID}}) AND LT.{0} = OT.{5} AND OT.REMOVED = {6}",
							link.LeftObjectIdField, link.RightObjectIdField, m_dbConnection.GetTypeValue(link.Code), link.LinkTable, link.LeftObject.TableName, link.LeftObject.IdField, m_dbConnection.GetTypeValue(false));
					}
				}
				else
				{
					throw new NotImplementedException();
				}
			}

			DbCommonCommand command = new DbCommonCommand(query.ToString(), m_dbConnection);
			command.AddParameter("ID", typeof(long), true);

			return command;
		}

		public DbCommonCommand GetSaveItemCommand()
		{
			StringBuilder query = new StringBuilder();
			query.AppendFormat("UPDATE {0} SET ", m_objectConfig.TableName);

			bool isFirst = true;
			foreach (DomainPropertyConfig property in m_objectConfig.Property)
			{
				if (isFirst == false)
					query.Append(", ");

				query.AppendFormat("{0} = @{{{1}}}", property.FieldName, property.Code);

				isFirst = false;
			}

			query.AppendFormat(" WHERE {0} = @{{ID}}", m_objectConfig.IdField);

			DbCommonCommand command = new DbCommonCommand(query.ToString(), m_dbConnection);
			command.AddParameter("ID", typeof(long));
			foreach (DomainPropertyConfig property in m_objectConfig.Property)
			{
				command.AddParameter(property.Code, property.DataType);
			}

			return command;
		}

		public DbCommonCommand GetDeleteItemsCommand()
		{
			string sql = String.Format("UPDATE {0} SET REMOVED = {1} WHERE {2} IN (@{{ID}})", m_objectConfig.TableName, m_dbConnection.GetTypeValue(true), m_objectConfig.IdField);

			DbCommonCommand command = new DbCommonCommand(sql, m_dbConnection);
			command.AddParameter("ID", typeof(long), true);

			return command;
		}
	}

	//public void GetLinkFor(long id, eLinkSide side)
	//{
	//    throw new NotImplementedException();

	//    // вместо линк коде, для ускорения можно составить Dictionary<int, LinkConfig> и в запрос можно пихать этот индекс
	//    // тогда результат запроса будем меньше по памяти и числа быстрее сравнивать чем строки

	//    if (LinkConfig.LeftRelation == eRelation.Many && LinkConfig.RightRelation == eRelation.One)
	//    {
	//        String.Format("SELECT [LEFT_FIELD] OWNER_ID, [RIGHT_FIELD], 'LINK_CODE' AS LINK_CODE FROM [LINK_TABLE] WHERE [LEFT_FIELD] = [ID_PARAM]");
	//    }
	//    else
	//    {
	//        String.Format("SELECT [RIGHT_FIELD] FROM [MANY_TABLE] WHERE [ONE_FIELD] = [ID_PARAM]");
	//    }
	//}
}
