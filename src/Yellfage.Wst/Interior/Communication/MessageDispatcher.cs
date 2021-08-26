using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Communication;
using Yellfage.Wst.Interior.Invocation;

namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageDispatcher<TMarker> : IMessageDispatcher
    {
        private IHub<TMarker> Hub { get; }
        private IClient<TMarker> Client { get; }
        private IServiceProvider GlobalServiceProvider { get; }
        private IMessageReceiver MessageReceiver { get; }
        private IMessageTransmitter MessageTransmitter { get; }
        private IInvocationProcessor InvocationProcessor { get; }

        public MessageDispatcher(
            IHub<TMarker> hub,
            IClient<TMarker> client,
            IServiceProvider globalServiceProvider,
            IMessageReceiver messageReceiver,
            IMessageTransmitter messageTransmitter,
            IInvocationProcessor invocationProcessor)
        {
            Hub = hub;
            Client = client;
            GlobalServiceProvider = globalServiceProvider;
            MessageReceiver = messageReceiver;
            MessageTransmitter = messageTransmitter;
            InvocationProcessor = invocationProcessor;
        }

        public async Task StartAcceptingAsync()
        {
            await MessageReceiver.StartReceivingAsync(ProcessMessageAsync);
        }

        private async Task ProcessMessageAsync(IncomingMessage incomingMessage)
        {
            using IServiceScope scope = GlobalServiceProvider.CreateScope();

            InvocationContext<TMarker> context = incomingMessage switch
            {
                IncomingRegularInvocationMessage message => CreateRegularInvocationContext(scope, message),

                IncomingNotifiableInvocationMessage message => CreateNotifiableInvocationContext(scope, message),

                _ => throw new InvalidOperationException("Unknown message type")
            };

            await InvocationProcessor.ProcessAsync(context);
        }

        private RegularInvocationContext<TMarker> CreateRegularInvocationContext(
            IServiceScope scope,
            IncomingRegularInvocationMessage message)
        {
            return new(
                Hub,
                scope.ServiceProvider,
                Client,
                message.HandlerName,
                message.Arguments,
                message.InvocationId,
                false,
                MessageTransmitter);
        }

        private NotifiableInvocationContext<TMarker> CreateNotifiableInvocationContext(
            IServiceScope scope,
            IncomingNotifiableInvocationMessage message)
        {
            return new(
                Hub,
                scope.ServiceProvider,
                Client,
                message.HandlerName,
                message.Arguments);
        }
    }
}
