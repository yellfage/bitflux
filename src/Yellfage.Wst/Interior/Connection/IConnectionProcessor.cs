using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Connection
{
    internal interface IConnectionProcessor<TMarker>
    {
        Task StartAsync();
    }
}
