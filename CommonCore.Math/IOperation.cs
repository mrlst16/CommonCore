using System.Threading.Tasks;

namespace CommonCore.Math
{
    public interface IOperation
    {
        Task<IOperation> Factor();
        Task<double> Evaluate(ISubstitutionProvider substitutionProvider);
    }
}
