using System;

namespace Yellfage.Wst.Filtration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class AbstractExceptionFilterAttribute : FilterAttribute
    {
        public AbstractExceptionFilterAttribute()
        {
            Priority = (int)AbstractFilterPriority.Exception;
        }
    }
}
