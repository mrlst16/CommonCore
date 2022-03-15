using System;

namespace CommonCore.Models.Exceptions
{
    public class HttpException : Exception
    {
        public int StatusCode { get; set; }
        public HttpException(
            string message
            ) : base(message)
        {
        }

        public HttpException(
            string message, int errorCode
            ) : base(message)
        {
            StatusCode = errorCode;
        }
    }
}
