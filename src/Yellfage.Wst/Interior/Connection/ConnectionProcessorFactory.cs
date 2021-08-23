using System;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Connection
{
    internal class ConnectionProcessorFactory : IConnectionProcessorFactory
    {
        private IServiceProvider ServiceProvider { get; }

        public ConnectionProcessorFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IConnectionProcessor Create<TMarker>(
            IClient<TMarker> client,
            IMessageDispatcher messageDispatcher)
        {
            IHub<TMarker> hub = ServiceProvider.GetRequiredService<IHub<TMarker>>();

            return new ConnectionProcessor<TMarker>(
                hub,
                client,
                messageDispatcher);
        }
    }
}
