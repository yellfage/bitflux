using System.Threading.Tasks;

namespace Yellfage.Wst
{
    public delegate Task ClientAddedEventHandler<TMarker>(ClientAddedEvent<TMarker> ev);
}
