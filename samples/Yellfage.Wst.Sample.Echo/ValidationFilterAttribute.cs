using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Yellfage.Wst.Validation;

namespace Yellfage.Wst.Sample.Echo
{
    public class ValidationFilterAttribute : DefaultValidationFilterAttribute
    {
        public override Task OnValidationFailedAsync<TMarker>(
            IInvocationContext<TMarker> context,
            ValidationContext validationContext,
            ICollection<ValidationResult> validationResults)
        {
            // Handle the validation failure in your own way

            return base.OnValidationFailedAsync(context, validationContext, validationResults);
        }
    }
}
