using Yellfage.Wst.Filters;

namespace Yellfage.Wst
{
    public interface IDisconnectionContext<T> : IFilterContext<T>
    {
        IClient<T> Client { get; }
        string? Reason { get; }
    }
}
