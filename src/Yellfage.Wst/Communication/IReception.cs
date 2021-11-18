using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Yellfage.Wst.Communication
{
    public interface IReception<TMarker>
    {
        string TransportName { get; }

        /// <exception cref="ReceptionException" />
        Task<ITransport<TMarker>> AcceptAsync(HttpContext context);
    }
}
