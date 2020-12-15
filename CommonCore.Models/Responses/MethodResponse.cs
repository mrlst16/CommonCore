using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Models.Responses
{
    public class MethodResponse<T> : MethodRespsonse, IResponse<T>
    {
        public T Data { get; set; }

    }

    public class MethodRespsonse : IResponse
    {
        public bool Sucess { get; set; }
        public IEnumerable<ErrorResponse> Errors { get; set; }
    }
}
