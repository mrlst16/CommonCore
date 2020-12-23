using System.Threading.Tasks;

namespace CommonCore.Math
{
    public interface IOperation
    {
        Task<IOperation> Evaluate();
        Task<double> Evaluate(ISubstitutionProvider substitutionProvider);
    }
}
