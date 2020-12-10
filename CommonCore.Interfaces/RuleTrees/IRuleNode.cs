using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.RuleTrees
{
    public interface IRuleNode
    {
        IEnumerable<IRuleNode> Children { get; set; }
        Guid ID { get; set; }
        Guid ParentID { get; set; }
        Task<bool> Passes();
    }

    public interface IRuleNode<T> : IRuleNode
    {
        new Task<bool> Passes();
        Task<bool> Passes(T comparrisonValue);
    }
}
