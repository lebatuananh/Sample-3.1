using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Base.Web.Exceptions
{
    public class BadRequestException : BaseCustomException
    {
        public BadRequestException(string message = "Bad request") : base(new List<string> { message },
            HttpStatusCode.BadRequest)
        {
        }
        public BadRequestException(List<string> messages) : base(messages, HttpStatusCode.BadRequest)
        {
        }
    }
}
