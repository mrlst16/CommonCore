using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Models.Responses
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; }
    }

    public interface IResponse
    {
        bool Sucess { get; }
        IEnumerable<ErrorResponse> Errors { get; set; }
    }
}
