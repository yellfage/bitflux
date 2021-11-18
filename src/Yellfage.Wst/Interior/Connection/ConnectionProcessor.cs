using System.Threading.Tasks;

using Yellfage.Wst.Interior.Communication;

namespace Yellfage.Wst.Interior.Connection
{
    internal class ConnectionProcessor<TMarker> : IConnectionProcessor<TMarker>
    {
        private IHub<TMarker> Hub { get; }
        private IClient<TMarker> Client { get; }
        private IMessageDispatcher<TMarker> MessageDispatcher { get; }

        public ConnectionProcessor(
            IHub<TMarker> hub,
            IClient<TMarker> client,
            IMessageDispatcher<TMarker> messageDispatcher)
        {
            Hub = hub;
            Client = client;
            MessageDispatcher = messageDispatcher;
        }

        public async Task StartAsync()
        {
            await Hub.Clients.AddAsync(Client);

            await MessageDispatcher.StartAsync();

            await Hub.Groups.RemoveAll(Client);

            await Hub.Clients.RemoveAsync(Client);
        }
    }
}
