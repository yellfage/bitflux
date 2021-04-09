using System.Threading.Tasks;

namespace Yellfage.Wst.Samples.Echo
{
    [WorkerInvocationFilter]
    public class EchoWorker : Worker<IEchoHub>
    {
        [HandlerInvocationFilter]
        public async Task<string> Echo(string message)
        {
            Context.Hub.Foo();
            Context.Hub.Bar();
            Context.Hub.Baz();

            await Context.Hub.Clients.NotifyAllAsync("Echo", message);

            return message;
        }
    }
}
