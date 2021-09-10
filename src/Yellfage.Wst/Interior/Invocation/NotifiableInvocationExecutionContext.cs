using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class NotifiableInvocationExecutionContext<TMarker> : InvocationExecutionContext<TMarker>
    {
        public NotifiableInvocationExecutionContext(
            IHub<TMarker> hub,
            IServiceProvider serviceProvider,
            IClient<TMarker> caller,
            string handlerName,
            IList<object?> arguments) : base(hub, serviceProvider, caller, handlerName, arguments)
        {
        }

        public override Task ReplyAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public override Task ReplyAsync(Func<object?> createResult, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public override Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
