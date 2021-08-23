using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst.Interior
{
    internal class WstServerBuilder : IWstServerBuilder
    {
        public IServiceCollection Services { get; }

        public WstServerBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
