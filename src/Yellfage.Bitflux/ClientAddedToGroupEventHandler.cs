using System.Threading.Tasks;

namespace Yellfage.Bitflux
{
    public delegate Task ClientAddedToGroupEventHandler<TMarker>(ClientAddedToGroupEvent<TMarker> ev);
}
