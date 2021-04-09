using Yellfage.Wst.Filters;

namespace Yellfage.Wst
{
    public interface IConnectionContext<T> : IFilterContext<T>
    {
        IClient<T> Client { get; }
    }
}
