using MediatR;
using Ria.API.Middlewares;
using Ria.Application.Customers.Commands;
using Ria.Application.Customers.CommandsHandlers;
using Ria.Domain.Customers.Repositories;
using Ria.Infrastructure.Repositories;

namespace Ria.API.StartupConfiguration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {

            #region Middleware
            services.AddTransient<ExceptionHandlingMiddleware>();
            #endregion

            #region Commands
            services.AddScoped<IRequestHandler<CreateCustomersCommand, bool>, CreateCustomersCommandHandler>();
            services.AddScoped<IRequestHandler<ClearCustomersCommand, bool>, ClearCustomersCommandHandler>();
            #endregion

            #region Repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            #endregion

        }
    }
}
