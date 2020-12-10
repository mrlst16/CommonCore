using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.RuleTrees
{
    public interface IRuleTree
    {
        IRuleNode BaseNode { get; set; }
        Task<bool> Passes();
    }
}
