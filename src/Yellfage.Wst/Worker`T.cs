#pragma warning disable CS8618

namespace Yellfage.Wst
{
    public abstract class Worker<T> : Worker
    {
        public IInvocationContext<T> Context { get; set; }
    }
}
