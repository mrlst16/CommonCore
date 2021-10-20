using System.Threading.Tasks;

namespace CommonCore.Interfaces.Utilities
{
    public interface IMapper<TIn, TOut>
    {
        Task<TOut> Map(TIn source);
    }

    public interface IMapper<TIn1, TIn2, TOut>
    {
        Task<TOut> Map(TIn1 source1, TIn2 source2);
    }

    public interface IMapper<TIn1, TIn2, TIn3, TOut>
    {
        Task<TOut> Map(TIn1 source1, TIn2 source2, TIn3 source3);
    }
}
