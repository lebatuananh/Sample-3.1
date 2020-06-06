using System.Collections.Generic;
using System.Net;

namespace Base.Web.Exceptions
{
    public class ForbiddenException : BaseCustomException
    {
        public ForbiddenException(string message) : base(new List<string> {message}, HttpStatusCode.Forbidden)
        {
        }
    }
}