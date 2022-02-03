namespace Yellfage.Bitflux
{
    public interface IWorker<TMarker>
    {
        IInvocationContext<TMarker> Context { get; set; }
    }
}
