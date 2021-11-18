using System.Threading.Tasks;

namespace Yellfage.Wst
{
    public delegate Task ClientRemovedFromGroupEventHandler<TMarker>(ClientRemovedFromGroupEvent<TMarker> ev);
}
