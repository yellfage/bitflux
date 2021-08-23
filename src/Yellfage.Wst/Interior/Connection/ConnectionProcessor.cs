using System.Threading.Tasks;

using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Connection
{
    internal class ConnectionProcessor<TMarker> : IConnectionProcessor
    {
        private IHub<TMarker> Hub { get; }
        private IClient<TMarker> Client { get; }
        private IMessageDispatcher MessageDispatcher { get; }

        public ConnectionProcessor(
            IHub<TMarker> hub,
            IClient<TMarker> client,
            IMessageDispatcher messageDispatcher)
        {
            Hub = hub;
            Client = client;
            MessageDispatcher = messageDispatcher;
        }

        public async Task StartProcessingAsync()
        {
            await Hub.Clients.AddAsync(Client);

            await MessageDispatcher.StartAcceptingAsync();

            await Hub.Clients.RemoveAsync(Client);
        }
    }
}
