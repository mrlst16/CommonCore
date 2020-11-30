using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CommonCore.Models.Responses
{
    public class SimpleResponse<T>
    {
        public T Data { get; set; }

        public bool Sucess { get; set; }

        public IEnumerable<ErrorResponse> Errors { get; set; }

        [JsonIgnore]
        public string FailureMessage { get; set; }
        [JsonIgnore]
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
}
