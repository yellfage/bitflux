using Microsoft.AspNetCore.Builder;

namespace Yellfage.Bitflux.Interior
{
    internal class BitfluxHubApplicationConfigurator<TMarker> : IBitfluxHubApplicationConfigurator<TMarker>
    {
        public IApplicationBuilder Application { get; }

        public BitfluxHubApplicationConfigurator(IApplicationBuilder application)
        {
            Application = application;
        }
    }
}
