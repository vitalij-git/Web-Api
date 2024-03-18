using System.Net;

namespace BackEnd.ErrorResponseModel
{
    public class HttpStatusException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpStatusException(HttpStatusCode statusCode, string msg) : base(msg)
        {
            StatusCode = statusCode;
        }
    }
}
