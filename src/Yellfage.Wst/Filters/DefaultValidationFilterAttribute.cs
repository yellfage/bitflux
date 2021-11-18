using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yellfage.Wst.Filters
{
    public abstract class DefaultValidationFilterAttribute : Attribute, IFilter
    {
        public bool ValidateAllProperties { get; set; } = true;

        public async Task<object?> ApplyAsync<TMarker>(
            IInvocationContext<TMarker> context,
            Func<Task<object?>> next)
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

                if (!Validator.TryValidateObject(
                    argument,
                    validationContext,
                    validationResults,
                    ValidateAllProperties))
                {
                    return await OnFailureAsync(context, validationContext, validationResults);
                }
            }

            return await next.Invoke();
        }

        public virtual Task<object?> OnFailureAsync<TMarker>(
            IInvocationContext<TMarker> context,
            ValidationContext validationContext,
            ICollection<ValidationResult> validationResults)
        {
            throw new InvocationException(
                $"Failed to invoke the '{context.HandlerName}' handler: " +
                $"{validationResults.First().ErrorMessage}");
        }
    }
}
