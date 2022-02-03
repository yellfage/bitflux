using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using Yellfage.Bitflux.Filters;

namespace Yellfage.Bitflux.Sample.Echo
{
    public class ValidationFilterAttribute : DefaultValidationFilterAttribute
    {
        public override Task<object?> OnFailureAsync<TMarker>(
            IInvocationContext<TMarker> context,
            ValidationContext validationContext,
            ICollection<ValidationResult> validationResults)
        {
            // Handle the validation failure in your own way

            return base.OnFailureAsync(context, validationContext, validationResults);
        }
    }
}
