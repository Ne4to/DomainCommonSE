using System;

namespace DomainCommonSE.ObjQuery
{
	public class ObjectQueryParameter
	{
		public ObjectQuery Owner { get; private set; }
		
		private string m_code = String.Empty;
		public String Code 
		{
			get
			{
				return m_code;
			}
			set
			{
				if (m_code == value)
					return;

				throw new NotImplementedException();

				//Owner.UpdateParameter(value, this);
				m_code = value;
			}
		}
		public Type DataType { get; set; }

		internal ObjectQueryParameter(ObjectQuery owner)
		{
			Owner = owner;
		}
	}
}
