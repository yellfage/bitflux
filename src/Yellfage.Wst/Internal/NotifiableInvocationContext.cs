using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Internal
{
    internal class NotifiableInvocationContext<T> : InvocationContext<T>
    {
        public NotifiableInvocationContext(
            IHub<T> hub,
            IServiceProvider serviceProvider,
            IClient<T> caller,
            string id,
            string handlerName,
            IList<object?> args) : base(hub, serviceProvider, caller, id, handlerName, args)
        {
        }

        public override Task ReplyAsync(object? data, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public override Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
