using Yellfage.Wst.Bussing;

namespace Yellfage.Wst.Interior
{
    internal class ClientManagerFactory : IClientManagerFactory
    {
        private IBusFactory BusFactory { get; }

        public ClientManagerFactory(IBusFactory busFactory)
        {
            BusFactory = busFactory;
        }

        public IClientManager<TMarker> Create<TMarker>()
        {
            return new ClientManager<TMarker>(BusFactory.Create<TMarker>());
        }
    }
}
