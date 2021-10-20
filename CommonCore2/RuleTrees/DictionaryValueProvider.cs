using CommonCore.Interfaces.RuleTrees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonCore2.RuleTrees
{
    public class DictionaryValueProvider : IRuleTreeValueProvider
    {
        private readonly IDictionary<string, object> _source;

        public DictionaryValueProvider(
            IDictionary<string, object> source
            )
        {
            _source = source;
        }

        public async Task<object> GetValue(string key)
        {
            if (_source.TryGetValue(key, out object value))
                return value;
            return null;
        }
    }
}
