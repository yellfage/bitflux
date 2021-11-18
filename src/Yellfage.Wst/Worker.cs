#pragma warning disable CS8618

namespace Yellfage.Wst
{
    public abstract class Worker<TMarker> : IWorker<TMarker>
    {
        public IInvocationContext<TMarker> Context { get; set; }
    }
}
