using System.Collections.Generic;
using System.Net;

namespace Base.Web.Exceptions
{
    public class AuthorizationException : BaseCustomException
    {
        public AuthorizationException(string message) : base(new List<string> {message}, HttpStatusCode.Unauthorized)
        {
        }
    }
}