using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Interior.Invocation
{
    internal abstract class InvocationContext<TMarker> : IInvocationContext<TMarker>
    {
        public IHub<TMarker> Hub { get; }
        public IClient<TMarker> Client { get; }
        public IServiceProvider ServiceProvider { get; }
        public string HandlerName { get; }
        public IList<object?> Arguments { get; }

        public InvocationContext(
            IHub<TMarker> hub,
            IServiceProvider serviceProvider,
            IClient<TMarker> client,
            string handlerName,
            IList<object?> arguments)
        {
            Hub = hub;
            ServiceProvider = serviceProvider;
            Client = client;
            HandlerName = handlerName;
            Arguments = arguments;
        }

        public abstract Task ReplyAsync(object? value, CancellationToken cancellationToken = default);

        public abstract Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default);
    }
}
