using CommonCore.Models.RuleTrees.Comparison;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Models.RuleTrees
{
    public class InclusiveRangeSearchParameter<T2> : ComparisonRule<T2>
    {
        public T2 From { get; set; }
        public T2 To { get; set; }

        public async override Task<bool> Passes()
        {
            return true;
        }
    }
}
