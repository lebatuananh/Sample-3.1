using System.Collections.Generic;
using System.Net;

namespace Base.Web.Exceptions
{
    public class NotFoundException : BaseCustomException
    {
        public NotFoundException(string message = "Cannot find object") : base(new List<string> {message},
            HttpStatusCode.NotFound)
        {
        }
    }
}