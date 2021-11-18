using Microsoft.AspNetCore.Builder;

namespace Yellfage.Wst
{
    public interface IWstHubApplicationConfigurator<TMarker>
    {
        IApplicationBuilder Application { get; }
    }
}
