using System;
using System.Collections.Generic;
using DomainCommonSE.DbCommon;

namespace DomainCommonSE.ObjQuery
{
	public class ObjectQuery
	{
		public long Id { get; private set; }
		public string Code { get; private set; }
		public string ObjectType { get; private set; }
		public string Source { get; private set; }
		public string Notes { get; private set; }

		public IDbCommonConnection Connection { get; set; }
	
		public ObjectQueryParameterCollection Parameters { get; private set; }
		//protected Dictionary<string, DbCommonCommandParameter> m_parameter = new Dictionary<string, DbCommonCommandParameter>();

		//public DbCommonCommandParameter this[string code]
		//{
		//    get
		//    {
		//        if (!m_parameter.ContainsKey(code))
		//            throw new EntityObjectException(String.Format("Не найден параметер с кодом '{0}'", code));

		//        return m_parameter[code];
		//    }
		//}

		//internal void UpdateParameter(string newCode, ObjectQueryParameter parameter)
		//{
		//    if (Parameters.Contains(newCode))
		//        throw new EntityObjectException();

		//    Parameters.ChangeKey(parameter.Code, newCode, parameter);
		//}


		//public DbCommonCommandParameter AddParameter(string code, Type dataType, bool isCollection, object value)
		//{
		//    if (m_parameter.ContainsKey(code))
		//        throw new EntityObjectException(String.Format("Параметер с кодом '{0}' уже существует", code));

		//    DbCommonCommandParameter result = new DbCommonCommandParameter(code, dataType, value, isCollection);
		//    m_parameter.Add(code, result);

		//    return result;
		//}

		//public DbCommonCommandParameter AddParameter(string code, Type dataType, bool isCollection)
		//{
		//    return AddParameter(code, dataType, isCollection, null);
		//}

		//public DbCommonCommandParameter AddParameter(string code, Type dataType)
		//{
		//    return AddParameter(code, dataType, false, null);
		//}

		internal ObjectQuery(long id, string code, string objectType, string source, string notes, IDbCommonConnection connection = null)
		{
			Id = id;
			Code = code;
			ObjectType = objectType;
			Source = source;
			Notes = notes;
			Connection = connection;

			Parameters = new ObjectQueryParameterCollection();
		}

		internal void Update(EditObjectQueryParams editParams)
		{
			Code = editParams.Code;
			ObjectType = editParams.ObjectType;
			Source = editParams.Source;
			Notes = editParams.Notes;
		}

		public Preview GetPreview(SessionIdentifier session)
		{
			throw new NotImplementedException();

			//DbCommonCommand command = new DbCommonCommand(Source, Connection);
			//foreach (DbCommonCommandParameter param in m_parameter.Values)
			//    command.AddParameter(param.Code, param.DataType, param.IsCollection, param.Value);

			//return new Preview(session, ObjectType, command.ExecuteTable(session));
		}

		public void Execute(SessionIdentifier session)
		{
			throw new NotImplementedException();

			//DbCommonCommand command = new DbCommonCommand(Source, Connection);
			//foreach (DbCommonCommandParameter param in m_parameter.Values)
			//    command.AddParameter(param.Code, param.DataType, param.IsCollection, param.Value);

			//command.ExecuteNonQuery(session);
		}
	}

	public class EditObjectQueryParams
	{
		public string Code { get; set; }
		public string ObjectType { get; set; }
		public string Source { get; set; }
		public string Notes { get; set; }
	}
}
