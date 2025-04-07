using FluentValidation;
using Microsoft.AspNetCore.Http.Json;
using Ria.API.Endpoints;
using Ria.API.Middlewares;
using Ria.API.StartupConfiguration;
using System.Net.NetworkInformation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));

builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddHttpContextAccessor();

builder.Services.AddValidatorsFromAssembly(Assembly.Load("Ria.Application"));


builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGroup("Customer")
    .MapCustomerEndpoint()
    .WithTags("Customer");

app.Run();


