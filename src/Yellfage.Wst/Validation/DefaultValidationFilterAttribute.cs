using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yellfage.Wst.Validation
{
    public class DefaultValidationFilterAttribute : AbstractValidationFilterAttribute
    {
        public bool ValidateAllProperties { get; set; }

        public DefaultValidationFilterAttribute()
        {
            ValidateAllProperties = true;
        }

        public override async Task ApplyAsync<TMarker>(
            IInvocationExecutionContext<TMarker> context,
            Func<Task> next)
        {
            foreach (object? argument in context.Arguments)
            {
                if (argument is null || !argument.GetType().IsClass)
                {
                    continue;
                }

                var validationContext = new ValidationContext(
                    argument,
                    context.ServiceProvider,
                    new Dictionary<object, object?>());

                var validationResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(argument, validationContext, validationResults, ValidateAllProperties))
                {
                    await OnFailureAsync(context, validationContext, validationResults);

                    return;
                }
            }

            await next();
        }

        public virtual Task OnFailureAsync<TMarker>(
            IInvocationExecutionContext<TMarker> context,
            ValidationContext validationContext,
            ICollection<ValidationResult> validationResults)
        {
            return context.ReplyErrorAsync(
                $"Failed to invoke the '{context.HandlerName}' handler: " +
                $"{validationResults.First().ErrorMessage}");
        }
    }
}
