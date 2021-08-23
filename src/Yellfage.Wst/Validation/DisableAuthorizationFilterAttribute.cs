using System;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DisableValidationFilterAttribute : DisableFilterAttribute
    {
        public DisableValidationFilterAttribute() : base(typeof(AbstractValidationFilterAttribute))
        {
        }
    }
}
