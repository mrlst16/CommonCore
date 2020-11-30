using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Models.Responses
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public string StackTrace { get; set; }
    }
}
