using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Yellfage.Wst.Interior.Connection
{
    internal interface IConnectionRequestProcessor<TMarker>
    {
        Task ProcessAsync(HttpContext context);
    }
}
