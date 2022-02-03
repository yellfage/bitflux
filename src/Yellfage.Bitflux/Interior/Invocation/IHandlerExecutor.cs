using System.Threading.Tasks;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IHandlerExecutor<TMarker>
    {
        /// <exception cref="ArgumentBindingException" />
        /// <exception cref="InvocationException" />
        Task<object?> ExecuteAsync(IHandler handler, IInvocationContext<TMarker> context);
    }
}
