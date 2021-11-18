using Microsoft.AspNetCore.Builder;

namespace Yellfage.Wst.Interior
{
    internal class WstHubApplicationConfigurator<TMarker> : IWstHubApplicationConfigurator<TMarker>
    {
        public IApplicationBuilder Application { get; }

        public WstHubApplicationConfigurator(IApplicationBuilder application)
        {
            Application = application;
        }
    }
}
