using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IInvocationExecutor<TMarker>
    {
        Task ExecuteAsync(IInvocationContext<TMarker> context);
    }
}
