namespace Yellfage.Bitflux.Interior.Invocation
{
    internal class HandlerExecutorFactory<TMarker> : IHandlerExecutorFactory<TMarker>
    {
        private IMethodExecutor<TMarker> MethodExecutor { get; }

        public HandlerExecutorFactory(IMethodExecutor<TMarker> methodExecutor)
        {
            MethodExecutor = methodExecutor;
        }

        public IHandlerExecutor<TMarker> Create()
        {
            return new HandlerExecutor<TMarker>(MethodExecutor);
        }
    }
}
