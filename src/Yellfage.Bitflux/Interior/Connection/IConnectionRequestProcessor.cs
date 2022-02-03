using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Yellfage.Bitflux.Interior.Connection
{
    internal interface IConnectionRequestProcessor<TMarker>
    {
        Task ProcessAsync(HttpContext context);
    }
}
