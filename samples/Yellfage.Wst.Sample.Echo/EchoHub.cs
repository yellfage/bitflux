using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yellfage.Wst.Sample.Echo
{
    [HubFilter]
    [ValidationFilter]
    public class EchoHub : Hub<EchoHub>
    {
        public EchoHub(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Clients.Added += OnClientAddedAsync;
            Clients.Removed += OnClientRemovedAsync;
        }

        private async Task OnClientAddedAsync(ClientAddedEvent<EchoHub> ev)
        {
            Console.WriteLine($"Client with '{ev.Client.Id}' id added");

            IList<string> chatIds = new List<string>() { "1", "2", "3" };

            await Groups.AddManyAsync(chatIds, ev.Client);
        }

        private Task OnClientRemovedAsync(ClientRemovedEvent<EchoHub> ev)
        {
            Console.WriteLine($"Client with '{ev.Client.Id}' id removed");

            return Task.CompletedTask;
        }
    }
}
