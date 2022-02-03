using System.Threading.Tasks;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IInvocationExecutor<TMarker>
    {
        Task ExecuteAsync(IInvocationContext<TMarker> context);
    }
}
