using System.Collections.Generic;
using System.Net;

namespace Core.Helpers
{
    public class HttpResult<T>
    {
        public HttpResult(HttpStatusCode status, string message = null)
        {
            HttpStatus = status;
            Message = message;
        }

        public HttpResult(IList<T> result, HttpStatusCode status, string message = null)
        {
            Result = result;
            HttpStatus = status;
            Message = message;
        }

        public IList<T> Result { get; set; }
        public string Message { get; set; }
        public HttpStatusCode HttpStatus { get; set; }
    }
}
