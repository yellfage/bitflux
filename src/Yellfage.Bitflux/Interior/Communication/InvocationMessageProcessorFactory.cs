using System;

using Yellfage.Bitflux.Interior.Invocation;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class InvocationMessageProcessorFactory<TMarker> : IInvocationMessageProcessorFactory<TMarker>
    {
        private IHub<TMarker> Hub { get; }
        private IServiceProvider ServiceProvider { get; }
        private IInvocationExecutorFactory<TMarker> InvocationExecutorFactory { get; }

        public InvocationMessageProcessorFactory(
            IHub<TMarker> hub,
            IServiceProvider serviceProvider,
            IInvocationExecutorFactory<TMarker> invocationExecutorFactory)
        {
            Hub = hub;
            ServiceProvider = serviceProvider;
            InvocationExecutorFactory = invocationExecutorFactory;
        }

        public IInvocationMessageProcessor<TMarker> Create(
            IClient<TMarker> client,
            IArgumentBinder<TMarker> argumentBinder,
            IHandlerExecutor<TMarker> handlerExecutor,
            IRegularInvocationResponder<TMarker> regularInvocationResponder,
            INotifiableInvocationResponder<TMarker> notifiableInvocationResponder)
        {
            return new InvocationMessageProcessor<TMarker>(
                Hub,
                client,
                ServiceProvider,
                InvocationExecutorFactory,
                argumentBinder,
                handlerExecutor,
                regularInvocationResponder,
                notifiableInvocationResponder);
        }
    }
}
