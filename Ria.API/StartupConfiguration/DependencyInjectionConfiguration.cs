﻿using MediatR;
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

            //services.AddScoped<ApplicationDbContext>();

            //#region Application Services
            //services.AddTransient<IPregCheckApplicationService, PregCheckApplicationService>();
            //#endregion

            #region Services

            #endregion

            #region Application Services
            //services.AddTransient<ISleepService, SleepService>();
            #endregion


            #region Queries
            //services.AddTransient<IMediaProcessQueries, MediaProcessQueries>();
            #endregion

            //#endregion

            //#region UOW
            //services.AddScoped<IDbSession, DbSession>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //#endregion


            //#region MediatorHandler
            //services.AddScoped<IMediatorHandler, MediatorHandler>();
            //#endregion

            //#region MediatR Pipeline
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //#endregion

            #region Middleware
            services.AddTransient<ExceptionHandlingMiddleware>();
            #endregion

            #region Commands
            services.AddScoped<IRequestHandler<CreateCustomersCommand, bool>, CreateCustomersCommandHandler>();

            #endregion

            #region Repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            #endregion


            #region Events
            //services.AddScoped<INotificationHandler<SleepCreatedEvent>, SleepCreatedEventHandler>();
            #endregion

        }
    }
}
