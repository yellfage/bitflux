namespace Yellfage.Bitflux
{
    public class ClientAddedToGroupEvent<TMarker> : ClientGroupEvent<TMarker>
    {
        public ClientAddedToGroupEvent(
            IGroupManager<TMarker> target,
            string groupName,
            IClient<TMarker> client) : base(target, groupName, client)
        {
        }
    }
}
