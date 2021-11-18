using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Yellfage.Wst.Interior.Invocation;

namespace Yellfage.Wst.Interior.Communication
{
    internal class InvocationMessageProcessor<TMarker> : IInvocationMessageProcessor<TMarker>
    {
        private IHub<TMarker> Hub { get; }
        private IClient<TMarker> Client { get; }
        private IServiceProvider ServiceProvider { get; }
        private IInvocationExecutorFactory<TMarker> InvocationExecutorFactory { get; }
        private IHandlerExecutor<TMarker> HandlerExecutor { get; }
        private IRegularInvocationResponder<TMarker> RegularInvocationResponder { get; }
        private INotifiableInvocationResponder<TMarker> NotifiableInvocationResponder { get; }

        public InvocationMessageProcessor(
            IHub<TMarker> hub,
            IClient<TMarker> client,
            IServiceProvider serviceProvider,
            IInvocationExecutorFactory<TMarker> invocationExecutorFactory,
            IHandlerExecutor<TMarker> handlerExecutor,
            IRegularInvocationResponder<TMarker> regularInvocationResponder,
            INotifiableInvocationResponder<TMarker> notifiableInvocationResponder)
        {
            Hub = hub;
            Client = client;
            ServiceProvider = serviceProvider;
            InvocationExecutorFactory = invocationExecutorFactory;
            HandlerExecutor = handlerExecutor;
            RegularInvocationResponder = regularInvocationResponder;
            NotifiableInvocationResponder = notifiableInvocationResponder;
        }

        public async Task ProcessAsync(IncomingInvocationMessage message)
        {
            using IServiceScope scope = ServiceProvider.CreateScope();

            IInvocationContext<TMarker> context = new InvocationContext<TMarker>(
                Hub,
                Client,
                scope.ServiceProvider,
                message.Id,
                message.HandlerName,
                message.Arguments);

            IInvocationResponder<TMarker> invocationResponder = message switch
            {
                IncomingRegularInvocationMessage => RegularInvocationResponder,

                IncomingNotifiableInvocationMessage => NotifiableInvocationResponder,

                _ => throw new InvalidOperationException("Unknown invocation message type")
            };

            await InvocationExecutorFactory
                .Create(HandlerExecutor, invocationResponder)
                .ExecuteAsync(context);
        }
    }
}
