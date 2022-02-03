using System.Threading.Tasks;

namespace Yellfage.Bitflux
{
    public delegate Task ClientRemovedFromGroupEventHandler<TMarker>(ClientRemovedFromGroupEvent<TMarker> ev);
}
