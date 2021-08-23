namespace Yellfage.Wst
{
    public class ClientRemovedEvent<TMarker>
    {
        public IClient<TMarker> Client { get; }

        public ClientRemovedEvent(IClient<TMarker> client)
        {
            Client = client;
        }
    }
}
