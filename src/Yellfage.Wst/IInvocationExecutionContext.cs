using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst
{
    public interface IInvocationExecutionContext<TMarker> : IInvocationContext<TMarker>
    {
        object? Result { get; set; }

        Task ReplyAsync(CancellationToken cancellationToken = default);
        Task ReplyAsync(Func<object?> createResult, CancellationToken cancellationToken = default);
        Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default);
    }
}
