using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Math.Operations
{
    public class Exponent : IOperation
    {
        public double Power { get; set; }
        public IOperation Operation { get; set; }

        public async Task<double> Evaluate()
            => System.Math.Pow(await Operation.Evaluate(), Power);
    }
}
