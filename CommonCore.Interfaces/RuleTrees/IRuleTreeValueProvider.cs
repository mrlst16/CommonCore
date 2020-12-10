using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.RuleTrees
{
    public interface IRuleTreeValueProvider
    {
        Task<object> GetValue(string key);
    }
}
