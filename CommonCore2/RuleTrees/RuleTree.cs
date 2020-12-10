using CommonCore.Interfaces.RuleTrees;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class RuleTree: IRuleTree
    {

        public IRuleNode BaseNode { get; set; }
        public virtual async Task<bool> Passes()
            => await BaseNode.Passes();


        public static async Task<bool> PassesAnd<T>(IEnumerable<T> Children)
            where T : IRuleNode
        {
            foreach (var item in Children)
            {
                if (!await item.Passes())
                    return false;
            }
            return true;
        }

        public static async Task<bool> PassesOr<T>(IEnumerable<T> Children)
            where T : IRuleNode
        {
            foreach (var item in Children)
            {
                if (await item.Passes())
                    return true;
            }
            return !Children.Any();
        }
    }
}
