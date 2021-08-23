using Microsoft.Extensions.DependencyInjection;

namespace Yellfage.Wst
{
    public interface IWstServerBuilder
    {
        IServiceCollection Services { get; }
    }
}
