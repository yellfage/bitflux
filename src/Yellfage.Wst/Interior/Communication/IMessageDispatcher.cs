using System.Threading.Tasks;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IMessageDispatcher<TMarker>
    {
        Task StartAsync();
    }
}
