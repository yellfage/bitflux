using System;
using System.Net.WebSockets;

using Microsoft.Extensions.DependencyInjection;

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
            HubOptions<TMarker> options = ServiceProvider
                .GetRequiredService<HubOptions<TMarker>>();

            return new MessageReceiver(
                options.Communication.MessageSegmentSize,
                options.Communication.MessageSegmentSize * options.Communication.MaxMessageSegments,
                webSocket,
                messageDeserializer);
        }
    }
}
