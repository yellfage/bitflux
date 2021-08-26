using System;

using Yellfage.Wst.Filtration;

namespace Yellfage.Wst.ExceptionHandling
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DisableExceptionFilterAttribute : DisableFilterAttribute
    {
        public DisableExceptionFilterAttribute() : base(typeof(AbstractExceptionFilterAttribute))
        {
        }
    }
}
