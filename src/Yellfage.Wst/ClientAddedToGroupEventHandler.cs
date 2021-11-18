using System.Threading.Tasks;

namespace Yellfage.Wst
{
    public delegate Task ClientAddedToGroupEventHandler<TMarker>(ClientAddedToGroupEvent<TMarker> ev);
}
