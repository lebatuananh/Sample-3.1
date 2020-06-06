using System.Diagnostics;
using System.Text.Encodings.Web;
using Base.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Base.Web.ViewEngine
{
    public class CustomRazorViewEngine : RazorViewEngine, IRazorViewEngine
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CustomRazorViewEngine(IRazorPageFactoryProvider pageFactory,
            IRazorPageActivator pageActivator,
            HtmlEncoder htmlEncoder,
            IOptions<RazorViewEngineOptions> optionsAccessor,
            RazorProjectFileSystem razorFileSystem,
            ILoggerFactory loggerFactory,
            DiagnosticSource diagnosticSource,
            IHttpContextAccessor httpContextAccessor
        )
            : base(pageFactory,
                pageActivator,
                htmlEncoder,
                optionsAccessor,
                razorFileSystem,
                loggerFactory,
                diagnosticSource
            )
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public new RazorPageResult FindPage(ActionContext context, string pageName)
        {
            var name = GetFileNameByDeviceContext(context, pageName);
            if (!name.Equals(pageName))
            {
                var page = base.FindPage(context, name);
                if (page.Page != null)
                    return page;
            }

            return base.FindPage(context, pageName);
        }

        public new ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            var name = GetFileNameByDeviceContext(context, viewName);

            if (!name.Equals(viewName))
            {
                var view = base.FindView(context, name, isMainPage);
                if (view.Success)
                    return view;
            }

            return base.FindView(context, viewName, isMainPage);
        }

        public new RazorPageResult GetPage(string executingFilePath, string pagePath)
        {
            var razorPagePath = GetFilePathByDeviceContext(pagePath);
            if (!razorPagePath.Equals(pagePath))
            {
                var page = base.GetPage(executingFilePath, razorPagePath);
                if (page.Page != null)
                    return page;
            }

            return base.GetPage(executingFilePath, pagePath);
        }

        public new ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            var razorViewPath = GetFilePathByDeviceContext(viewPath);
            if (!razorViewPath.Equals(viewPath))
            {
                var view = base.GetView(executingFilePath, razorViewPath, isMainPage);
                if (view.Success)
                    return view;
            }

            return base.GetView(executingFilePath, viewPath, isMainPage);
        }

        private string GetFileNameByDeviceContext(ActionContext context, string inputName)
        {
            if (context.HttpContext.FromMobile() && !inputName.Contains(".mobile"))
                return inputName + ".mobile";
            return inputName;
        }

        private string GetFilePathByDeviceContext(string razorFilePath)
        {
            var fromMobile = httpContextAccessor.HttpContext.FromMobile();

            if (fromMobile && razorFilePath.EndsWith(".cshtml") && !razorFilePath.EndsWith(".mobile.cshtml"))
                return razorFilePath.Replace(".cshtml", ".mobile.cshtml");
            if (fromMobile && !razorFilePath.EndsWith(".cshtml") && !razorFilePath.EndsWith(".mobile"))
                return razorFilePath + ".mobile";
            return razorFilePath;
        }
    }
}