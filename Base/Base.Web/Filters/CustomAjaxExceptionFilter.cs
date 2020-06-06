using System.Collections.Generic;
using System.Net;
using Base.Web.Exceptions;
using Base.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Base.Web.Filters
{
    public class CustomAjaxExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.OK;
            if (exception is BaseCustomException customException)
            {
                var errorModel = new ErrorModel(customException.StatusCode, customException.Messages);
                if (customException.AdditionalData != null)
                    errorModel.AdditionalData = customException.AdditionalData;
                context.Result = new JsonResult(errorModel);
            }
            else
            {
                context.Result = new JsonResult(
                    new ErrorModel(
                        HttpStatusCode.InternalServerError,
                        new List<string>
                        {
                            string.Format("Có lỗi xảy ra ({0})", exception.Message ?? "")
                        }
                    )
                );
            }

            //base.OnException(context);
        }
    }
}