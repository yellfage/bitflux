using System;
using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal class MessageDispatcher<T> : IMessageDispatcher
    {
        private IHub<T> Hub { get; }
        private IClient<T> Client { get; }
        private IMessageReceiver MessageReceiver { get; }
        private IMessageDeserializer MessageDeserializer { get; }
        private IMessageTransmitter MessageTransmitter { get; }
        private IInvocationProcessor InvocationProcessor { get; }
        private IServiceProvider ServiceProvider { get; }

        public MessageDispatcher(
            IHub<T> hub,
            IClient<T> client,
            IMessageReceiver messageReceiver,
            IMessageDeserializer messageDeserializer,
            IMessageTransmitter messageTransmitter,
            IInvocationProcessor invocationProcessor,
            IServiceProvider serviceProvider)
        {
            Hub = hub;
            Client = client;
            MessageReceiver = messageReceiver;
            MessageDeserializer = messageDeserializer;
            MessageTransmitter = messageTransmitter;
            InvocationProcessor = invocationProcessor;
            ServiceProvider = serviceProvider;
        }

        public async Task StartAcceptingAsync()
        {
            await MessageReceiver.StartReceivingAsync(ProcessMessageBytesAsync);
        }

        private async Task ProcessMessageBytesAsync(ArraySegment<byte> bytes)
        {
            if (MessageDeserializer.TryDeserialize(bytes, out IncomingMessage? incomingMessage))
            {
                if (!incomingMessage.IsValid())
                {
                    await Client.DisconnectAsync("Incoming message is invalid");

                    return;
                }

                switch (incomingMessage)
                {
                    case IncomingRegularInvocationMessage message:
                        await ProcessRegularInvocationMessageAsync(message);

                        break;

                    case IncomingNotifiableInvocationMessage message:
                        await ProcessNotifiableInvocationMessageAsync(message);

                        break;

                    default:
                        await Client.DisconnectAsync("Unknown message type");

                        break;
                }
            }
            else
            {
                await Client.DisconnectAsync("Unable to deserialize received data");
            }
        }

        private async Task ProcessRegularInvocationMessageAsync(IncomingRegularInvocationMessage message)
        {
            var context = new RegularInvocationContext<T>(
                    Hub,
                    ServiceProvider,
                    Client,
                    message.HandlerName,
                    message.Args,
                    message.InvocationId,
                    false,
                    MessageTransmitter!);

            await InvocationProcessor.ProcessAsync(context);
        }

        private async Task ProcessNotifiableInvocationMessageAsync(IncomingNotifiableInvocationMessage message)
        {
            var context = new NotifiableInvocationContext<T>(
                    Hub,
                    ServiceProvider,
                    Client,
                    message.HandlerName,
                    message.Args);

            await InvocationProcessor.ProcessAsync(context);
        }
    }
}
