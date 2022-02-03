using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Yellfage.Bitflux.Interior.Communication
{
    internal interface IAgreementRequestProcessor<TMarker>
    {
        Task ProcessAsync(HttpContext context);
    }
}
