using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace Base.Static.Utilities
{
    public class HtmlUtils
    {
        public static async Task<UrlContent> GetUrlContent(string url)
        {
            var pageContent = await LoadUrlContent(url);
            var htmlContent = GetHtmlContent(pageContent);
            var urlContent = new UrlContent
            {
                Url = url,
                Title = htmlContent.Title,
                Image = htmlContent.Image,
                Description = htmlContent.Description
            };
            return urlContent;
        }

        public static async Task<string> GetPlayableFacebookVideoUrl(string inputUrl)
        {
            var webClient = new WebClient();
            webClient.Headers.Add(
                HttpRequestHeader.UserAgent,
                "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/75.4.124 Chrome/69.4.3497.124 Safari/537.36"
            );
            webClient.Headers.Add("Accept", "text/html");
            var content = await webClient.DownloadStringTaskAsync(inputUrl);

            var pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(content);
            var rootNode = pageDocument.DocumentNode;

            var metaNodes = rootNode.SelectNodes("/html/head/meta");
            foreach (var metaNode in metaNodes)
                if (metaNode.GetAttributeValue("property", "").Equals("og:video"))
                {
                    var url = metaNode.GetAttributeValue("content", "");
                    url = HttpUtility.UrlDecode(url);
                    url = url.Replace("&amp;", "&");
                    return url;
                }

            return "";
        }

        public static async Task<string> LoadUrlContent(string url)
        {
            var httpClient = new HttpClient();
            var document = await httpClient.GetStringAsync(url);
            return document;
        }

        public static string GetOriginText(string source)
        {
            if (Encoded(source))
                return HttpUtility.HtmlDecode(source);
            return source;
        }

        public static bool Encoded(string source)
        {
            return source != HttpUtility.HtmlDecode(source);
        }

        public static HtmlContent GetHtmlContent(string content)
        {
            var pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(content);

            var result = new HtmlContent();

            var rootNode = pageDocument.DocumentNode;

            var metaNodes = rootNode.SelectNodes("/html/head/meta");

            var titleDone = false;
            var imageDone = false;
            var descriptionDone = false;

            foreach (var metaNode in metaNodes)
            {
                if (metaNode.GetAttributeValue("name", "").Contains("title") && !titleDone)
                {
                    result.Title = metaNode.GetAttributeValue("content", null);
                    titleDone = true;
                }

                if (!imageDone && metaNode.GetAttributeValue("property", "").Contains("title") && !titleDone)
                {
                    result.Title = metaNode.GetAttributeValue("content", null);
                    titleDone = true;
                }

                if (metaNode.GetAttributeValue("name", "").Contains("image") && !imageDone)
                {
                    result.Image = metaNode.GetAttributeValue("content", null);
                    imageDone = true;
                }

                if (!imageDone && metaNode.GetAttributeValue("property", "").Contains("image"))
                {
                    result.Image = metaNode.GetAttributeValue("content", null);
                    imageDone = true;
                }

                if (metaNode.GetAttributeValue("name", "").Contains("description") && !descriptionDone)
                {
                    result.Description = metaNode.GetAttributeValue("content", null);
                    descriptionDone = true;
                }

                if (titleDone && imageDone && descriptionDone)
                    break;
            }

            if (!titleDone)
            {
                var titleNodes = rootNode.SelectNodes("/html/head/title");
                if (titleNodes.Count > 0)
                {
                    result.Title = titleNodes[0].InnerText;
                    titleDone = true;
                }
            }

            return result;
        }
    }

    public class HtmlContent
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class UrlContent
    {
        public string Url { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}