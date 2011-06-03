using System;

namespace DomainCommonSE.DbCommon
{
	/// <summary>
	/// Параметер SQL комманды
	/// </summary>
	public class DbCommonCommandParameter
	{
		public Type DataType { get; private set; }
		/// <summary>
		/// Код
		/// </summary>
		public string Code { get; private set; }
		/// <summary>
		/// Значение
		/// </summary>
		public object Value { get; set; }
		/// <summary>
		/// Параметер является коллекцией
		/// </summary>
		public bool IsCollection { get; private set; }
		/// <summary>
		/// Разрешено пустое значение
		/// </summary>
		public bool AllowNull { get; set; }

		internal DbCommonCommandParameter(string code, Type dataType, object value, bool isCollection = false, bool allowNull = true)			
		{
			DataType = dataType;
			Code = code;
			Value = value;
			IsCollection = isCollection;
			AllowNull = allowNull;
		}
	}
}
