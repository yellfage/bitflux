namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IMessageDispatcherFactory<TMarker>
    {
        IMessageDispatcher<TMarker> Create(IInvocationMessageProcessor<TMarker> invocationMessageProcessor, IMessageReceiver<TMarker> messageReceiver);
    }
}
