using System;

namespace Yellfage.Wst.Filters
{
    public interface IFilterContext<T>
    {
        IHub<T> Hub { get; }
        IServiceProvider ServiceProvider { get; }
    }
}
