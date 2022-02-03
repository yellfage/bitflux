using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal class AgreementRequestProcessor<TMarker> : IAgreementRequestProcessor<TMarker>
    {
        private IReceptionProvider<TMarker> ReceptionProvider { get; }
        private IProtocolProvider<TMarker> ProtocolProvider { get; }
        private IAgreementFactory<TMarker> AgreementFactory { get; }

        private IVersion Version { get; } = new Version(1, 0);

        public AgreementRequestProcessor(
            IReceptionProvider<TMarker> receptionProvider,
            IProtocolProvider<TMarker> protocolProvider,
            IAgreementFactory<TMarker> agreementFactory)
        {
            ReceptionProvider = receptionProvider;
            ProtocolProvider = protocolProvider;
            AgreementFactory = agreementFactory;
        }

        public async Task ProcessAsync(HttpContext context)
        {
            IEnumerable<string> transportNames = ReceptionProvider
                .GetAll()
                .Select(reception => reception.TransportName);

            IEnumerable<string> protocolNames = ProtocolProvider
                .GetAll()
                .Select(protocol => protocol.Name);

            IAgreement agreement = AgreementFactory
                .Create(Version, transportNames, protocolNames);

            context.Response.StatusCode = StatusCodes.Status200OK;

            await context.Response.WriteAsJsonAsync(agreement);
        }
    }
}
