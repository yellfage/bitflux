using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Invocation
{
    internal abstract class InvocationExecutionContext<TMarker> : IInvocationExecutionContext<TMarker>
    {
        public IHub<TMarker> Hub { get; }
        public IClient<TMarker> Client { get; }
        public IServiceProvider ServiceProvider { get; }
        public string HandlerName { get; }
        public IList<object?> Arguments { get; }
        public object? Result { get; set; }

        public InvocationExecutionContext(
            IHub<TMarker> hub,
            IServiceProvider serviceProvider,
            IClient<TMarker> client,
            string handlerName,
            IList<object?> arguments)
        {
            Hub = hub;
            Client = client;
            ServiceProvider = serviceProvider;
            HandlerName = handlerName;
            Arguments = arguments;
        }

        public abstract Task ReplyAsync(CancellationToken cancellationToken = default);
        public abstract Task ReplyAsync(Func<object?> createResult, CancellationToken cancellationToken = default);
        public abstract Task ReplyErrorAsync(string error, CancellationToken cancellationToken = default);
    }
}
