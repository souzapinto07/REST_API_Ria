using FluentValidation;

namespace Ria.API.Filters
{
    public class ValidatorFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();
            if (validator is not null)
            {
                var obj = context.Arguments
                    .OfType<T>()
                    .FirstOrDefault(a => a?.GetType() == typeof(T));
                if (obj is not null)
                {
                    var results = await validator.ValidateAsync((obj));
                    if (!results.IsValid)
                    {
                        throw new ValidationException(results.Errors);
                    }
                }
                else
                {
                    throw new ValidationException("Error Not Found");
                }
            }

            return await next(context);
        }
    }
}
