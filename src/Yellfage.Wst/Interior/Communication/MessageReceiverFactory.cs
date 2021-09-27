using System;
using System.Net.WebSockets;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Yellfage.Wst.Configuration;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageReceiverFactory : IMessageReceiverFactory
    {
        private IServiceProvider ServiceProvider { get; }

        public MessageReceiverFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IMessageReceiver Create<TMarker>(
            WebSocket webSocket,
            IMessageDeserializer messageDeserializer)
        {
            IOptions<HubOptions<TMarker>> options = ServiceProvider
                .GetRequiredService<IOptions<HubOptions<TMarker>>>();

            CommunicationSettings communicationSettings = options.Value.Communication;

            return new MessageReceiver(
                communicationSettings.MessageSegmentSize,
                communicationSettings.MessageSegmentSize * communicationSettings.MaxMessageSegments,
                webSocket,
                messageDeserializer);
        }
    }
}
