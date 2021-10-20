using System;
using System.Collections.Generic;

namespace CommonCore.Models.Responses
{
    public class MethodResponse<T> : MethodResponse, IResponse<T>
    {
        public T Data { get; set; }

        public static implicit operator bool(MethodResponse<T> response) => response.Sucess;
        public static implicit operator T(MethodResponse<T> response) => response.Data;

        public new MethodResponse<T> AddError(string errorMessage)
        {
            Errors.Add(new ErrorResponse()
            {
                Message = errorMessage
            });
            return this;
        }

        public new MethodResponse<T> AddError(string errorMessage, string errorCode)
        {
            Errors.Add(new ErrorResponse()
            {
                Message = errorMessage,
                ErrorCode = errorCode
            });
            return this;
        }

        public new MethodResponse<T> AddError(string errorMessage, string errorCode, string stackTrace)
        {
            Errors.Add(new ErrorResponse()
            {
                Message = errorMessage,
                ErrorCode = errorCode,
                StackTrace = stackTrace
            });
            return this;
        }

        public new MethodResponse<T> AddError(Exception e, string errorCode)
        {
            Errors.Add(new ErrorResponse()
            {
                Message = e.Message,
                ErrorCode = errorCode,
                StackTrace = e.StackTrace
            });
            return this;
        }

        public new MethodResponse<T> AsSucces()
        {
            this.Sucess = true;
            return this;
        }

        public new MethodResponse<T> AsFailure()
        {
            this.Sucess = false;
            return this;
        }
    }

    public class MethodResponse : IResponse
    {

        public bool Sucess { get; set; }
        public IList<ErrorResponse> Errors { get; set; } = new List<ErrorResponse>();

        public static implicit operator bool(MethodResponse response) => response.Sucess;

        public MethodResponse AddError(string errorMessage)
        {
            Errors.Add(new ErrorResponse()
            {
                Message = errorMessage
            });
            return this;
        }

        public MethodResponse AddError(string errorMessage, string errorCode)
        {
            Errors.Add(new ErrorResponse()
            {
                Message = errorMessage,
                ErrorCode = errorCode
            });
            return this;
        }

        public MethodResponse AddError(string errorMessage, string errorCode, string stackTrace)
        {
            Errors.Add(new ErrorResponse()
            {
                Message = errorMessage,
                ErrorCode = errorCode,
                StackTrace = stackTrace
            });
            return this;
        }

        public MethodResponse AddError(Exception e, string errorCode)
        {
            Errors.Add(new ErrorResponse()
            {
                Message = e.Message,
                ErrorCode = errorCode,
                StackTrace = e.StackTrace
            });
            return this;
        }

        public MethodResponse AsSucces()
        {
            this.Sucess = true;
            return this;
        }

        public MethodResponse AsFailure()
        {
            this.Sucess = false;
            return this;
        }
    }
}
