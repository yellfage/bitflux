using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yellfage.Wst.Samples.Echo
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IEchoHub EchoHub { get; }

        public HomeController(IEchoHub echoHub)
        {
            EchoHub = echoHub;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await EchoHub.Clients.NotifyAllAsync("Echo", "Some message");

            return Ok($"Clients: {EchoHub.Clients.All.Count}");
        }
    }
}
