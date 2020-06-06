using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Static.Utilities
{
    public class WebUtils
    {
        public static string StandardizeUri(string baseSiteUrl, string uri)
        {
            var comparedUri = uri.Replace("http://www.", "http://")
                .Replace("https://www.", "https://");

            if (comparedUri.StartsWith("https://") || comparedUri.StartsWith("http://"))
                return uri;

            if (comparedUri.StartsWith(baseSiteUrl))
                return uri;

            var url = $"{baseSiteUrl}/{uri.TrimStart('/')}";
            return url;
        }
        public static WebPage ParseArticleUrl(string url)
        {

            var pathsBySchema = url.Split("://");
            var scheme = pathsBySchema[0];
            var pathsBySlash = pathsBySchema[1].Split("/");
            var domain = pathsBySlash[0];

            var elementsOfPath = ((string[])pathsBySlash.Clone()).ToList();
            elementsOfPath.RemoveAt(0);
            var path = string.Join("/", elementsOfPath);

            var webPage = new WebPage()
            {
                Scheme = scheme,
                Domain = domain,
                Path = path
            };
            return webPage;
        }
    }
    public class WebPage
    {
        public string Scheme { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }
    }
}
