using System.Text.RegularExpressions;

namespace GetPriceUrl.Helpers
{
    public static class GetPriceHelper
    {
        public static string GetDomainFromUrl(string url)
        {
            Uri uri = new Uri(url);
            string domain = uri.Host;
            return domain.StartsWith("www.") ? domain.Substring(4) : domain;
        }
        public static string RegexPrice(string price)
        {
            return Regex.Replace(price, "[^0-9]", "");
        }
    }
}
