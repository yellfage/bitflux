using System.Threading.Tasks;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IMessageDispatcher<TMarker>
    {
        Task StartAsync();
    }
}
