using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal class MessageDispatcher<T> : IMessageDispatcher<T>
    {
        private IHub<T> Hub { get; }
        private IMessageReceiver MessageReceiver { get; }
        private IInvocationProcessor InvocationProcessor { get; }
        private IMessageTransmitter? MessageTransmitter { get; set; }

        public MessageDispatcher(
            IHub<T> hub,
            IMessageReceiver messageReceiver,
            IInvocationProcessor invocationProcessor)
        {
            Hub = hub;
            MessageReceiver = messageReceiver;
            InvocationProcessor = invocationProcessor;
        }

        public async Task StartAcceptingAsync(
            WebSocket webSocket,
            IProtocol protocol,
            IClient<T> client)
        {
            MessageTransmitter = new MessageTransmitter(webSocket, protocol);

            await MessageReceiver.StartReceivingAsync(
                webSocket,
                bytes => ProcessMessageBytesAsync(bytes, protocol, client));
        }

        private async Task ProcessMessageBytesAsync(
            ArraySegment<byte> bytes,
            IProtocol protocol,
            IClient<T> client)
        {
            if (protocol.TryDeserialize(bytes, out IncomingMessage? incomingMessage))
            {
                if (!incomingMessage.IsValid())
                {
                    await client.DisconnectAsync("Incoming message is invalid");

                    return;
                }

                switch (incomingMessage)
                {
                    case IncomingRegularInvocationMessage message:
                        await ProcessRegularInvocationMessageAsync(client, message, protocol);

                        break;

                    case IncomingNotifiableInvocationMessage message:
                        await ProcessNotifiableInvocationMessageAsync(client, message, protocol);

                        break;

                    default:
                        await client.DisconnectAsync("Unknown message type");

                        break;
                }
            }
            else
            {
                await client.DisconnectAsync("Unable to deserialize received data");
            }
        }

        private async Task ProcessRegularInvocationMessageAsync(
            IClient<T> client,
            IncomingRegularInvocationMessage message,
            IProtocol protocol)
        {
            var context = new RegularInvocationContext<T>(
                    Hub,
                    client,
                    message.HandlerName,
                    message.Args,
                    message.InvocationId,
                    false,
                    MessageTransmitter!);

            await InvocationProcessor.ProcessAsync(context, protocol);
        }

        private async Task ProcessNotifiableInvocationMessageAsync(
            IClient<T> client,
            IncomingNotifiableInvocationMessage message,
            IProtocol protocol)
        {
            var context = new NotifiableInvocationContext<T>(
                    Hub,
                    client,
                    message.HandlerName,
                    message.Args);

            await InvocationProcessor.ProcessAsync(context, protocol);
        }
    }
}
