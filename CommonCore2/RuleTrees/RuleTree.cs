using CommonCore.Interfaces.RuleTrees;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class RuleTree : IRuleTree
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
            return false;
        }

        public static async Task<bool> PassesAnd(IEnumerable<IRuleNode> Children)
        {
            foreach (var item in Children)
            {
                if (!await item.Passes())
                    return false;
            }
            return true;
        }

        public static async Task<bool> PassesOr(IEnumerable<IRuleNode> Children)
        {
            foreach (var item in Children)
            {
                if (await item.Passes())
                    return true;
            }
            return false;
        }

        public static async Task<bool> PassesLimitNotAllPass(IEnumerable<IRuleNode> Children, int limit = 1)
        {
            var results = new List<bool>();

            if (Children.Count() < limit + 1) return false;
            foreach (var item in Children)
            {
                var itemResult = await item.Passes();
                results.Add(itemResult);
            }
            return results.Count(x => x) <= limit;
        }
    }
}
