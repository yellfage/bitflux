using System;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class AbstractValidationFilterAttribute : FilterAttribute
    {
        public AbstractValidationFilterAttribute()
        {
            Priority = AbstractFilterPriority.Validation;
        }
    }
}
