using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Yellfage.Wst.Interior.Communication
{
    internal interface IAgreementRequestProcessor<TMarker>
    {
        Task ProcessAsync(HttpContext context);
    }
}
