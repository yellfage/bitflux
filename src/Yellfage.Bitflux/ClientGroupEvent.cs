namespace Yellfage.Bitflux
{
    public abstract class ClientGroupEvent<TMarker> : GroupEvent<TMarker>
    {
        public IClient<TMarker> Client { get; }

        public ClientGroupEvent(
            IGroupManager<TMarker> target,
            string groupName,
            IClient<TMarker> client) : base(target, groupName)
        {
            Client = client;
        }
    }
}
