using System;
using System.Linq;
using Base.Web.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Base.Web.Behaviors
{
    public class CustomApiBehaviorOptions
    {
        public static Func<ActionContext, IActionResult> InvalidModelStateResponseFactory = actionContext =>
        {
            var errors = actionContext.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .Select(e => string.Format("{0}: {1}", e.Key, e.Value.Errors.First().ErrorMessage))
                .ToList();

            throw new UnprocessableEntityException(errors);
            //var errorModel = new ErrorModel(System.Net.HttpStatusCode.BadRequest, errors);
            //return new BadRequestObjectResult(errorModel);
        };
    }
}