using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Math
{
    public interface ISubstitutionProvider
    {
        Task<double> Subsitute(string variableName);
    }
}
