using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Yellfage.Wst.Interior
{
    internal interface IRequestProcessor
    {
        Task ProcessAsync<TMarker>(HttpContext context);
    }
}
