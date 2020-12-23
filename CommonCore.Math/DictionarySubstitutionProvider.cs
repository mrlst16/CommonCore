using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Math
{
    public class DictionarySubstitutionProvider : ISubstitutionProvider
    {
        private readonly IDictionary<string, double> _storage;

        public DictionarySubstitutionProvider(
            IDictionary<string, double> storage
            )
        {
            _storage = storage;
        }

        public async Task<double> Subsitute(string variableName)
            => _storage.TryGetValue(variableName, out double v) ? v : throw new Exception($"Argument {variableName} not provided");
    }
}
