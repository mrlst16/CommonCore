using System.Threading.Tasks;

namespace CommonCore.Interfaces.RuleTrees
{
    public interface IRuleTreeValueProvider
    {
        Task<object> GetValue(string key);
    }
}
