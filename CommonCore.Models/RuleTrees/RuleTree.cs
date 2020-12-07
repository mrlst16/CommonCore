using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonCore.Models.RuleTrees
{
    public class RuleTree
    {
        public RuleNode BaseNode { get; set; }
        public virtual async Task<bool> Passes()
            => await BaseNode.Passes();


        public static async Task<bool> PassesAnd<T>(List<T> Children)
            where T : RuleNode
        {
            foreach (var item in Children)
            {
                if (!await item.Passes())
                    return false;
            }
            return true;
        }

        public static async Task<bool> PassesOr<T>(List<T> Children)
            where T : RuleNode
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
