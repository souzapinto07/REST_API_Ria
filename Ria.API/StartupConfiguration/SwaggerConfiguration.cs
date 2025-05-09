﻿using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Ria.API.StartupConfiguration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ria API",
                    Version = "v1",
                    Description = "Ria API Server",
                    Contact = new OpenApiContact
                    {
                        Name = "www.ria.com",
                        Email = string.Empty,
                        Url = new Uri("https://www.ria.com"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

    }
}
