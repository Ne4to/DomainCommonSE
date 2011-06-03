using System;

namespace DomainCommonSE.DomainConfig
{
	/// <summary>
	/// Свойство объекта предметной области
	/// </summary>
	public class DomainPropertyConfig
	{
		public long Id { get; private set; }
		/// <summary>
		/// Код свойства
		/// </summary>
		public string Code { get; private set; }
		/// <summary>
		/// Описание
		/// </summary>
		public string Description { get; private set; }
		/// <summary>
		/// Владелец свойства
		/// </summary>
		public DomainObjectConfig Owner { get; private set; }
		/// <summary>
		/// Тип данных
		/// </summary>
		public Type DataType { get; private set; }
		/// <summary>
		/// Поле в БД
		/// </summary>
		public string FieldName { get; private set; }

		/// <summary>
		/// Значение по умолчанию
		/// </summary>
		public object DefaultValue  { get; private set; }

		/// <summary>
		/// Максимальный размер
		/// </summary>
		public int Size { get; private set; }
		/// <summary>
		/// Код свойства в классе
		/// </summary>
		public string CodeName { get; private set; }

		internal DomainPropertyConfig(long id, string code, string description, DomainObjectConfig owner, Type dataType, string fieldName, object defaultValue, int size, string codeName)
		{
			Id = id;
			Code = code;
			Description = description;
			Owner = owner;
			DataType = dataType;
			DefaultValue = defaultValue;
			FieldName = fieldName;
			Size = size;
			CodeName = codeName;		
		}

		internal void Update(string newCodeName, string newDescription, object newDefaultValue)
		{
			CodeName = newCodeName;
			Description = newDescription;
			DefaultValue = newDefaultValue;
		}
	}
}