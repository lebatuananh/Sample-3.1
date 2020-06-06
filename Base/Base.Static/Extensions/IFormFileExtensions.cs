using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace Base.Static.Extensions
{
    public static class IFormFileExtensions
    {
        public static List<string> ImageContentTypes = new List<string>
        {
            MediaTypeNames.Image.Gif,
            MediaTypeNames.Image.Jpeg,
            MediaTypeNames.Image.Tiff,
            "image/bmp",
            "image/png",
            "image/jpg"
        };

        public static Dictionary<string, List<string>> ContentTypeExtensions = new Dictionary<string, List<string>>
        {
            {MediaTypeNames.Image.Gif, new List<string> {".gif"}},
            {MediaTypeNames.Image.Jpeg, new List<string> {".jpeg"}},
            {MediaTypeNames.Image.Tiff, new List<string> {".tiff"}},
            {"image/bmp", new List<string> {".bmp"}},
            {"image/png", new List<string> {".png"}},
            {"image/jpg", new List<string> {".jpg"}}
        };

        public static List<string> ImageExtensions = new List<string>
        {
            ".gif", ".jpg", ".jpeg", ".tiff", ".bmp", ".png"
        };

        public static Dictionary<string, string> ExtensionContentypeMap = new Dictionary<string, string>
        {
            {"gif", MediaTypeNames.Image.Gif},
            {"jpeg", MediaTypeNames.Image.Jpeg},
            {"tiff", MediaTypeNames.Image.Tiff},
            {"bmp", "image/bmp"},
            {"png", "image/png"},
            {"jpg", "image/jpg"}
        };

        public static List<string> VideoContentTypes = new List<string>
        {
            "video/mp4"
        };

        public static bool IsVideo(this IFormFile file)
        {
            return VideoContentTypes.Contains(file.ContentType);
        }

        public static bool IsImage(this IFormFile file)
        {
            return ImageContentTypes.Contains(file.ContentType);
        }
    }
}