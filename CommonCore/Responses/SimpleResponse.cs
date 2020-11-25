using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCore.Responses
{
    public class SimpleResponse : IResponse
    {
        public bool Sucess { get; set; }

        public List<Exception> Exceptions { get; set; }

        public List<string> Messages { get; set; }
    }
}
