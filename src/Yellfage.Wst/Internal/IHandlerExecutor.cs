using System.Threading.Tasks;

namespace Yellfage.Wst.Internal
{
    internal interface IHandlerExecutor
    {
        Task ExecuteAsync<T>(HandlerDescriptor handlerDescriptor, IInvocationContext<T> context);
    }
}
