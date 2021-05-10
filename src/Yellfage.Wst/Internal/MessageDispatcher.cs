using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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
        private IServiceProvider GlobalServiceProvider { get; }

        public MessageDispatcher(
            IHub<T> hub,
            IClient<T> client,
            IMessageReceiver messageReceiver,
            IMessageDeserializer messageDeserializer,
            IMessageTransmitter messageTransmitter,
            IInvocationProcessor invocationProcessor,
            IServiceProvider globalServiceProvider)
        {
            Hub = hub;
            Client = client;
            MessageReceiver = messageReceiver;
            MessageDeserializer = messageDeserializer;
            MessageTransmitter = messageTransmitter;
            InvocationProcessor = invocationProcessor;
            GlobalServiceProvider = globalServiceProvider;
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

                using IServiceScope scope = GlobalServiceProvider.CreateScope();

                IServiceProvider serviceProvider = scope.ServiceProvider;

                InvocationContext<T> context = incomingMessage switch
                {
                    IncomingRegularInvocationMessage message => new RegularInvocationContext<T>(
                        Hub,
                        serviceProvider,
                        Client,
                        message.HandlerName,
                        message.Args,
                        message.InvocationId,
                        false,
                        MessageTransmitter!),

                    IncomingNotifiableInvocationMessage message => new NotifiableInvocationContext<T>(
                        Hub,
                        serviceProvider,
                        Client,
                        message.HandlerName,
                        message.Args),

                    _ => throw new InvalidOperationException("Unknown message type")
                };

                await InvocationProcessor.ProcessAsync(context);
            }
            else
            {
                await Client.DisconnectAsync("Unable to deserialize received data");
            }
        }
    }
}
