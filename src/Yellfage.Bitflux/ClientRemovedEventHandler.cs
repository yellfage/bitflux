using System.Threading.Tasks;

namespace Yellfage.Bitflux
{
    public delegate Task ClientRemovedEventHandler<TMarker>(ClientRemovedEvent<TMarker> ev);
}
