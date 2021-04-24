using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    internal interface IInvocationProcessor
    {
        Task ProcessAsync<T>(IInvocationContext<T> context);
    }
}
