using Yellfage.Wst.Bussing;

namespace Yellfage.Wst.Interior.Bussing
{
    internal class BusFactory : IBusFactory
    {
        public IBus<TMarker> Create<TMarker>()
        {
            return new Bus<TMarker>();
        }
    }
}
