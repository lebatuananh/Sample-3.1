using System.Collections.Generic;
using System.Net;

namespace Base.Web.Exceptions
{
    public class UnprocessableEntityException : BaseCustomException
    {
        public UnprocessableEntityException(List<string> errors) : base(errors, HttpStatusCode.UnprocessableEntity)
        {
        }

        public UnprocessableEntityException(string error) : base(new List<string> {error},
            HttpStatusCode.UnprocessableEntity)
        {
        }
    }
}