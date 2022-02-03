namespace Yellfage.Bitflux
{
    public class ClientRemovedEvent<TMarker> : ClientEvent<TMarker>
    {
        public IClient<TMarker> Client { get; }

        public ClientRemovedEvent(
            IClientManager<TMarker> target,
            IClient<TMarker> client) : base(target)
        {
            Client = client;
        }
    }
}
