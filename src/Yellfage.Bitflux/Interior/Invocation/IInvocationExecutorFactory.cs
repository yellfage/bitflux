namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IInvocationExecutorFactory<TMarker>
    {
        IInvocationExecutor<TMarker> Create(IArgumentBinder<TMarker> argumentBinder, IHandlerExecutor<TMarker> handlerExecutor, IInvocationResponder<TMarker> invocationResponder);
    }
}
