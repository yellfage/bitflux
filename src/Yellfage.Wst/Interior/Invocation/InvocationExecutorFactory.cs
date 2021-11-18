using Yellfage.Wst.Interior.Filters;

namespace Yellfage.Wst.Interior.Invocation
{
    internal class InvocationExecutorFactory<TMarker> : IInvocationExecutorFactory<TMarker>
    {
        private IHandlerStore<TMarker> HandlerStore { get; }
        private IFilterExecutor<TMarker> FilterExecutor { get; }

        public InvocationExecutorFactory(
            IHandlerStore<TMarker> handlerStore,
            IFilterExecutor<TMarker> filterExecutor)
        {
            HandlerStore = handlerStore;
            FilterExecutor = filterExecutor;
        }

        public IInvocationExecutor<TMarker> Create(
            IHandlerExecutor<TMarker> handlerExecutor,
            IInvocationResponder<TMarker> invocationResponder)
        {
            return new InvocationExecutor<TMarker>(
                HandlerStore,
                FilterExecutor,
                handlerExecutor,
                invocationResponder);
        }
    }
}
