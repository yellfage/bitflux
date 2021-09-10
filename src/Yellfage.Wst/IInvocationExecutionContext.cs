using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst
{
    public interface IInvocationExecutionContext<TMarker> : IInvocationContext<TMarker>
    {
        Task ReplyAsync(object? result, CancellationToken cancellationToken = default);
        Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default);
    }
}
