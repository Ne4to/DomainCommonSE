using System;
using System.Collections.Generic;
using System.Globalization;

namespace DomainCommonSE.MsSqlCe40.Config
{
	public class LocaleID
	{
		public CultureInfo Culture { get; private set; }

		public LocaleID(CultureInfo culture)
		{
			Culture = culture;
		}

		public override string ToString()
		{
			return String.Format("{0} - {1}: {2}", Culture.NativeName, Culture.Name, Culture.LCID);
		}

		static List<LocaleID> m_allList = null;
		public static List<LocaleID> GetFullLocaleList()
		{
			if (m_allList != null)
				return m_allList;

			int currentCultureLCID = CultureInfo.CurrentCulture.LCID;

			LocaleID firstLocale = null;
			m_allList = new List<LocaleID>();

			foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
			{
				if (culture.LCID == currentCultureLCID)
				{
					firstLocale = new LocaleID(culture);
				}
				else
				{
					m_allList.Add(new LocaleID(culture));
				}
			}

			if (firstLocale != null)
				m_allList.Insert(0, firstLocale);			

			return m_allList;
		}
	}
}
