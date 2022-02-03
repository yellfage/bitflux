using Microsoft.AspNetCore.Builder;

namespace Yellfage.Bitflux
{
    public interface IBitfluxHubApplicationConfigurator<TMarker>
    {
        IApplicationBuilder Application { get; }
    }
}
