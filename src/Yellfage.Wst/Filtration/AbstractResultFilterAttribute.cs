using System;

namespace Yellfage.Wst.Filtration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class AbstractResultFilterAttribute : FilterAttribute
    {
        public AbstractResultFilterAttribute()
        {
            Priority = (int)AbstractFilterPriority.Result;
        }
    }
}
