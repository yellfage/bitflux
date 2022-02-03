using System;
using System.Threading.Tasks;

namespace Yellfage.Bitflux.Sample.Echo
{
    [WorkerFilter]
    public class EchoWorker : Worker<EchoHub>
    {
        [HandlerFilter]
        public void Authenticate()
        {
            if (Context.Client.IsAuthenticated())
            {
                return;
            }

            Context.Client.Authenticate(new Random().Next(1, int.MaxValue));
        }

        [HandlerFilter]
        [AuthorizationFilter]
        [HandlerName("Echo")]
        public string HandlerName(EchoPayload payload)
        {
            Console.WriteLine($"User id: {Context.Client.GetUserId()}");

            return payload.Message;
        }

        [HandlerFilter]
        public async Task Notify(NotifyPayload payload)
        {
            await Context.Hub.Clients.NotifyAllAsync("Notify", payload.Message);
        }
    }
}
