using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Connection
{
    internal class ConnectionProcessorFactory<TMarker> : IConnectionProcessorFactory<TMarker>
    {
        private IHub<TMarker> Hub { get; }

        public ConnectionProcessorFactory(IHub<TMarker> hub)
        {
            Hub = hub;
        }

        public IConnectionProcessor<TMarker> Create(
            IClient<TMarker> client,
            IMessageDispatcher<TMarker> messageDispatcher)
        {
            return new ConnectionProcessor<TMarker>(
                Hub,
                client,
                messageDispatcher);
        }
    }
}
