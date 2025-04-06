using FluentValidation;
using Ria.Domain.Common.Exceptions;
using System.Text.Json;

namespace Ria.API.Middlewares
{

    public sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

 
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

     
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ve)
            {
                _logger.LogError(ve, ve.Message + "\n" + ve.InnerException);
                await HandleExceptionAsync(context, ve);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message + "\n" + e.InnerException);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = exception switch
            {
                DomainException => StatusCodes.Status400BadRequest,
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            await httpContext.Response.WriteAsync(CreateSerializeModel(exception));
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, ValidationException validationException)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            string errorMessage = validationException?.Errors?.FirstOrDefault()?.ErrorMessage ?? "";
            string errorCode = validationException?.Errors?.FirstOrDefault()?.ErrorCode ?? "";

            await httpContext.Response.WriteAsync(CreateSerializeModel(errorMessage, errorCode));
        }

        private static string CreateSerializeModel(Exception exception) => JsonSerializer.Serialize(exception.Message + "\n" + exception.InnerException);

        private static string CreateSerializeModel(string errorMessage, string errorCode) => JsonSerializer.Serialize($"Message: {errorMessage} - Code: {errorCode}");
    }
}
