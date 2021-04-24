using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    internal interface IMessageDispatcher
    {
        Task StartAcceptingAsync();
    }
}
