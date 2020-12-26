using System.Collections.Generic;

namespace CommonCore.Models.Responses
{

    public class ApiResponse<T> : IResponse<T>
    {
        public T Data { get; set; }

        public bool Sucess { get; set; }

        public IList<ErrorResponse> Errors { get; set; }

        public string FailureMessage { protected get; set; }
        public string SuccessMessage { protected get; set; }

        private string _message = null;
        public string Message
        {
            get
            {
                if (_message != null)
                    return _message;

                return Sucess ? SuccessMessage : FailureMessage;
            }
        }
    }
}
