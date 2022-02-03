using System;
using System.Collections.Generic;

namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class InvocationContext<TMarker> : IInvocationContext<TMarker>
    {
        public IHub<TMarker> Hub { get; }
        public IClient<TMarker> Client { get; }
        public IServiceProvider ServiceProvider { get; }
        public string Id { get; }
        public string HandlerName { get; }
        public IList<object?> Arguments { get; }

        public InvocationContext(
            IHub<TMarker> hub,
            IClient<TMarker> client,
            IServiceProvider serviceProvider,
            string id,
            string handlerName,
            IList<object?> arguments)
        {
            Hub = hub;
            Client = client;
            ServiceProvider = serviceProvider;
            Id = id;
            HandlerName = handlerName;
            Arguments = arguments;
        }
    }
}
