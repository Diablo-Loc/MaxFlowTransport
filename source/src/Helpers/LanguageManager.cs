using src.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace src.Helpers
{
    public class LanguageManager
    {
        public static ResourceManager Resource = src.Localization.Strings.ResourceManager;

        public static void SetLanguage(string langCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);
            src.Localization.Strings.Culture = new CultureInfo(langCode);
        }

        public static string Get(string key)
        {
            return Resource.GetString(key);
        }

    }
}
