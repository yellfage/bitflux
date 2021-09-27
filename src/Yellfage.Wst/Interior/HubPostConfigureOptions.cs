using Microsoft.Extensions.Options;

namespace Yellfage.Wst.Interior
{
    internal class HubPostConfigureOptions<TMarker> : IPostConfigureOptions<HubOptions<TMarker>>
    {
        public void PostConfigure(string name, HubOptions<TMarker> options)
        {
            options.Validate();
        }
    }
}
