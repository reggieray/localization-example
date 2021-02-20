using System.Globalization;

namespace Localization.Example.Weather
{
    public static class WeatherLocale
    {
        public const string DefaultLocale = "en-US";

        public static CultureInfo GetLocale(string lang)
        {
            try
            {
                return new CultureInfo(lang);
            }
            catch (CultureNotFoundException)
            {
                return new CultureInfo(DefaultLocale);
            }
        }
    }
}
