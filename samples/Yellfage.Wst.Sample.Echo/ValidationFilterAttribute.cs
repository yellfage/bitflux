using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using Yellfage.Wst.Validation;

namespace Yellfage.Wst.Sample.Echo
{
    public class ValidationFilterAttribute : DefaultValidationFilterAttribute
    {
        public override Task OnFailureAsync<TMarker>(
            IInvocationExecutionContext<TMarker> context,
            ValidationContext validationContext,
            ICollection<ValidationResult> validationResults)
        {
            // Handle the validation failure in your own way

            return base.OnFailureAsync(context, validationContext, validationResults);
        }
    }
}
