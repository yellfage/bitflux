using System.Threading.Tasks;

namespace Yellfage.Wst
{
    public delegate Task ClientRemovedEventHandler<TMarker>(ClientRemovedEvent<TMarker> ev);
}
