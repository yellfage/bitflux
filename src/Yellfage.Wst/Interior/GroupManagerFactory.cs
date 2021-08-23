using Yellfage.Wst.Bussing;

namespace Yellfage.Wst.Interior
{
    internal class GroupManagerFactory : IGroupManagerFactory
    {
        private IBusFactory BusFactory { get; }

        public GroupManagerFactory(IBusFactory busFactory)
        {
            BusFactory = busFactory;
        }

        public IGroupManager<TMarker> Create<TMarker>()
        {
            return new GroupManager<TMarker>(BusFactory.Create<TMarker>());
        }
    }
}
