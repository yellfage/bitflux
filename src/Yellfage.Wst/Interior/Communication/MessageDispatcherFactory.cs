using System;
using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Interior.Invocation;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageDispatcherFactory : IMessageDispatcherFactory
    {
        private IServiceProvider ServiceProvider { get; }

        public MessageDispatcherFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IMessageDispatcher Create<TMarker>(
            IClient<TMarker> client,
            IMessageReceiver messageReceiver,
            IMessageTransmitter messageTransmitter,
            IInvocationProcessor invocationProcessor)
        {
            IHub<TMarker> hub = ServiceProvider.GetRequiredService<IHub<TMarker>>();

            return new MessageDispatcher<TMarker>(
                hub,
                client,
                ServiceProvider,
                messageReceiver,
                messageTransmitter,
                invocationProcessor);
        }
    }
}
