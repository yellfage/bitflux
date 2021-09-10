using System;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.ExceptionHandling
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
