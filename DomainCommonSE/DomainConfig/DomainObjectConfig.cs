using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DomainCommonSE.DbCommon;
using DomainCommonSE.Domain;

namespace DomainCommonSE.DomainConfig
{
	/// <summary>
	/// Конфигурация объекта предметной области
	/// </summary>
	public class DomainObjectConfig
	{
		public long Id { get; private set; }
		/// <summary>
		/// Код объекта
		/// </summary>
		public string Code { get; private set; }
		/// <summary>
		/// Описание
		/// </summary>
		public string Description { get; private set; }
		/// <summary>
		/// Таблица БД
		/// </summary>
		public string TableName { get; private set; }
		/// <summary>
		/// ID поле в таблице БД
		/// </summary>
		public string IdField { get; private set; }
		/// <summary>
		/// Код класса
		/// </summary>
		public string CodeName { get; private set; }
		/// <summary>
		/// Свойства объекта
		/// </summary>
		public DomainPropertyConfigCollection Property { get; private set; }

		internal DomainObjectConfig(long id, string code, string description, string tableName, string idField, string codeName)
		{
			Id = id;
			Code = code;
			Description = description;
			TableName = tableName;
			IdField = idField;
			CodeName = codeName;

			Property = new DomainPropertyConfigCollection();
		}

		internal void Update(string newCodeName, string newDescription)
		{
			CodeName = newCodeName;
			Description = newDescription;
		}
	}
}