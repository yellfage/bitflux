namespace Yellfage.Wst.Interior.Communication
{
    internal class MessageDispatcherFactory<TMarker> : IMessageDispatcherFactory<TMarker>
    {
        public IMessageDispatcher<TMarker> Create(
            IInvocationMessageProcessor<TMarker> invocationMessageProcessor,
            IMessageReceiver<TMarker> messageReceiver)
        {
            return new MessageDispatcher<TMarker>(invocationMessageProcessor, messageReceiver);
        }
    }
}
