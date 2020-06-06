using Base.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Base.Web.Controllers
{
    public class BaseMvcController : Controller
    {
        public bool FromMobile => HttpContext.FromMobile();
    }
}