using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Models.Responses
{

    public class SimpleResponse : IResponse
    {
        public bool Sucess { get; set; }

        public IList<ErrorResponse> Errors { get; set; }

        public string FailureMessage { get; set; }
        public string SuccessMessage { get; set; }

        private string _message = null;
        public string Message
        {
            get
            {
                if (_message != null)
                    return _message;

                return Sucess ? SuccessMessage : FailureMessage;
            }

            set
            {
                _message = value;
            }

        }
    }
    public class SimpleResponse<T> :SimpleResponse, IResponse<T>
    {
        public T Data { get; set; }
        
    }
}
