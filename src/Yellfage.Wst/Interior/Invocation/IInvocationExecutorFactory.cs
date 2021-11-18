namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IInvocationExecutorFactory<TMarker>
    {
        IInvocationExecutor<TMarker> Create(IHandlerExecutor<TMarker> handlerExecutor, IInvocationResponder<TMarker> invocationResponder);
    }
}
