using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yellfage.Wst.Communication
{
    public interface ITransport<TMarker> : IDisposable
    {
        Task StartAsync(Func<ArraySegment<byte>, Task> processBytesAsync);
        Task StopAsync(string reason, CancellationToken cancellationToken = default);
        Task SendAsync(ArraySegment<byte> data, TransferFormat transferFormat, CancellationToken cancellationToken = default);
    }
}
