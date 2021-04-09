using System.Threading.Tasks;

using Yellfage.Wst.Communication;

namespace Yellfage.Wst.Internal
{
    internal interface IInvocationProcessor
    {
        Task ProcessAsync<T>(IInvocationContext<T> context, IProtocol protocol);
    }
}
