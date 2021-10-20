using CommonCore.Models.Responses;
using System;
using System.Collections.Generic;

namespace CommonCore.Api.Extensions
{
    public static class ExceptionExtensions
    {
        public static ApiResponse<string> AsApiResponse(this Exception exception)
        {
            var response = new ApiResponse<string>()
            {
                FailureMessage = "Failed to validate request",
                Errors = new List<ErrorResponse>() {
                    new ErrorResponse(){
                        StackTrace = exception.StackTrace,
                        Message = exception.Message
                    }
                },
                Sucess = false,
                Data = null
            };
            return response;
        }
    }
}
