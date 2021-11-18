namespace Yellfage.Wst
{
    public interface IWorker<TMarker>
    {
        IInvocationContext<TMarker> Context { get; set; }
    }
}
