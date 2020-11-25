using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Models.Responses
{
    public class SimpleResponse<T> : IResponse<T>
    {
        public T Data { get; set; }

        public bool Sucess { get; set; }

        public List<Exception> Exceptions { get; set; }

        public List<string> Messages { get; set; }
    }
}
