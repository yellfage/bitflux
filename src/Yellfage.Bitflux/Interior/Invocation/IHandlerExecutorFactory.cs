namespace Yellfage.Bitflux.Interior.Invocation
{
    internal interface IHandlerExecutorFactory<TMarker>
    {
        IHandlerExecutor<TMarker> Create();
    }
}
