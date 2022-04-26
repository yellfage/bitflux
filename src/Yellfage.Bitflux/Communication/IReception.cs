using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Yellfage.Bitflux.Communication
{
    public interface IReception<TMarker>
    {
        string TransportName { get; }

        /// <exception cref="ReceptionException" />
        /// <exception cref="ProtocolException" />
        Task<IAgreement<TMarker>> AcceptAsync(HttpContext context);
    }
}
