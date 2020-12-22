using System.Threading.Tasks;

namespace CommonCore.Math
{
    public interface IOperation
    {
        Task<double> Evaluate();
    }
}
