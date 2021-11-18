namespace Yellfage.Wst.Interior.Invocation
{
    internal class HandlerExecutorFactory<TMarker> : IHandlerExecutorFactory<TMarker>
    {
        private IMethodExecutor<TMarker> MethodExecutor { get; }

        public HandlerExecutorFactory(IMethodExecutor<TMarker> methodExecutor)
        {
            MethodExecutor = methodExecutor;
        }

        public IHandlerExecutor<TMarker> Create(IArgumentBinder<TMarker> argumentBinder)
        {
            return new HandlerExecutor<TMarker>(argumentBinder, MethodExecutor);
        }
    }
}
