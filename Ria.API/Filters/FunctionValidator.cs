using FluentValidation;
using Microsoft.Azure.WebJobs.Host;

public class ValidationFilter<T> : IFunctionInvocationFilter
{
    private readonly IValidator<T> _validator;

    public ValidationFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
    {
        var model = executingContext.Arguments.Values.OfType<T>().FirstOrDefault();
        if (model == null)
        {
            throw new ArgumentException($"No model of type {typeof(T).Name} found in request");
        }

        var result = await _validator.ValidateAsync(model, cancellationToken);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
    }

    public Task OnExecutedAsync(FunctionExecutedContext executedContext, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}