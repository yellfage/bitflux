using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class NotifiableInvocationContext<TMarker> : InvocationContext<TMarker>
    {
        public NotifiableInvocationContext(
            IHub<TMarker> hub,
            IServiceProvider serviceProvider,
            IClient<TMarker> caller,
            string handlerName,
            IList<object?> arguments) : base(hub, serviceProvider, caller, handlerName, arguments)
        {
        }

        public override Task ReplyAsync(object? value, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public override Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
