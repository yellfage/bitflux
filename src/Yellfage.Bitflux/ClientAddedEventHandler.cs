using System.Threading.Tasks;

namespace Yellfage.Bitflux
{
    public delegate Task ClientAddedEventHandler<TMarker>(ClientAddedEvent<TMarker> ev);
}
