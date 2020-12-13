using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab
{

    public class Balls
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Balls> Children { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            

        }
    }
}
