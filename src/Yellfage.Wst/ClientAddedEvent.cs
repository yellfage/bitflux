namespace Yellfage.Wst
{
    public class ClientAddedEvent<TMarker>
    {
        public IClient<TMarker> Client { get; }

        public ClientAddedEvent(IClient<TMarker> client)
        {
            Client = client;
        }
    }
}
