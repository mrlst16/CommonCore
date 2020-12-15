using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.TestObjects
{
    public class Balls
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Balls> Children { get; set; }
    }
}
