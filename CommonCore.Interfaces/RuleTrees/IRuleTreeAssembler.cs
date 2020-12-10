using System.Threading.Tasks;

namespace CommonCore.Interfaces.RuleTrees
{
    public interface IRuleTreeAssembler
    {
        Task Assemble(IRuleTree ruleTree);
    }
}
