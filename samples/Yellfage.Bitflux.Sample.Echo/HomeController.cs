using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace Yellfage.Bitflux.Sample.Echo
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IHub<EchoHub> EchoHub { get; }

        public HomeController(IHub<EchoHub> echoHub)
        {
            EchoHub = echoHub;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await EchoHub.Clients.NotifyAllAsync("Notify", "Some message");

            return Ok("All clients notified");
        }
    }
}
