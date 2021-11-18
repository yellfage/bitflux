namespace Yellfage.Wst
{
    public class ClientAddedEvent<TMarker> : ClientEvent<TMarker>
    {
        public IClient<TMarker> Client { get; }

        public ClientAddedEvent(
            IClientManager<TMarker> target,
            IClient<TMarker> client) : base(target)
        {
            Client = client;
        }
    }
}
