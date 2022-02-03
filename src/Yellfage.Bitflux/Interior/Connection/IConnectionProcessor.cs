using System.Threading.Tasks;

namespace Yellfage.Bitflux.Interior.Connection
{
    internal interface IConnectionProcessor<TMarker>
    {
        Task StartAsync();
    }
}
