namespace Yellfage.Wst.Interior.Invocation
{
    internal interface IHandlerExecutorFactory<TMarker>
    {
        IHandlerExecutor<TMarker> Create();
    }
}
