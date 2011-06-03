using System;
using System.Collections.Generic;
using System.Globalization;

namespace EntityObjectORM.ConfigLibrary
{
	public class LocaleID
	{
		public const int RussianLCID = 1049;
		public CultureInfo Culture { get; private set; }

		public LocaleID(CultureInfo culture)
		{			
			Culture = culture;
		}

		public override string ToString()
		{
			return String.Format("{0} - {1}: {2}", Culture.NativeName, Culture.Name, Culture.LCID);
		}

		public static List<LocaleID> GetFullLocaleList()
		{
			LocaleID firstLocale = null;
			List<LocaleID> result = new List<LocaleID>();

			foreach (var culture in CultureInfo.GetCultures(CultureTypes.FrameworkCultures))
			{
				if (culture.LCID == RussianLCID)
				{
					firstLocale = new LocaleID(culture);
				}
				else
				{
					result.Add(new LocaleID(culture));
				}
			}

			result.Insert(0, firstLocale);			

			return result;
		}
	}
}
