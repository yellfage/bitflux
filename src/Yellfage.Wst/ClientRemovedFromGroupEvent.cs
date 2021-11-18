namespace Yellfage.Wst
{
    public class ClientRemovedFromGroupEvent<TMarker> : ClientGroupEvent<TMarker>
    {
        public ClientRemovedFromGroupEvent(
            IGroupManager<TMarker> target,
            string groupName,
            IClient<TMarker> client) : base(target, groupName, client)
        {
        }
    }
}
