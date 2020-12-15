using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.Utilities
{
    public interface IMapper<TIn, TOut>
    {
        Task<TOut> Map(TIn source);
    }
}
