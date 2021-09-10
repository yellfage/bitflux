using System;

namespace Yellfage.Wst.Filtration
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class AbstractValidationFilterAttribute : FilterAttribute
    {
        public AbstractValidationFilterAttribute()
        {
            Priority = (int)AbstractFilterPriority.Validation;
        }
    }
}
