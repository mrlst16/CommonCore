using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Models.Responses
{
    public interface IResponse<T>
    {
        T Data { get; }
        bool Sucess { get; }
        List<Exception> Exceptions { get; }
        List<string> Messages { get; }
    }
}
