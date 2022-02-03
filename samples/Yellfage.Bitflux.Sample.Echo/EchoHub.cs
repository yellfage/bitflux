using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yellfage.Bitflux.Sample.Echo
{
    [HubFilter]
    [ValidationFilter]
    public class EchoHub : Hub<EchoHub>
    {
        public EchoHub(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Clients.Added += OnClientAddedAsync;
            Clients.Removed += OnClientRemovedAsync;

            Groups.Added += OnClientAddedToGroupAsync;
            Groups.Removed += OnClientRemovedFromGroupAsync;
        }

        private async Task OnClientAddedAsync(ClientAddedEvent<EchoHub> ev)
        {
            Console.WriteLine($"Client with '{ev.Client.Id}' id added");

            IList<string> chatIds = new List<string>() { "1", "2", "3" };

            await Groups.AddManyAsync("chat:", chatIds, ev.Client);
        }

        private Task OnClientRemovedAsync(ClientRemovedEvent<EchoHub> ev)
        {
            Console.WriteLine($"Client with '{ev.Client.Id}' id removed");

            return Task.CompletedTask;
        }

        private Task OnClientAddedToGroupAsync(ClientAddedToGroupEvent<EchoHub> ev)
        {
            Console.WriteLine($"Client with '{ev.Client.Id}' id added to '{ev.GroupName}' group");

            return Task.CompletedTask;
        }

        private Task OnClientRemovedFromGroupAsync(ClientRemovedFromGroupEvent<EchoHub> ev)
        {
            Console.WriteLine($"Client with '{ev.Client.Id}' id removed from '{ev.GroupName}' group");

            return Task.CompletedTask;
        }
    }
}
