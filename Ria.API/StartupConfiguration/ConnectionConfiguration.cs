namespace Ria.API.StartupConfiguration
{
    public static class ConnectionConfiguration
    {
        public static void AddConnectionConfiguration(this IServiceCollection services, IWebHostEnvironment environment, ConfigurationManager configuration)
        {
            //if (environment.IsProduction())
            //{
            //    var environmentVariable = Environment.GetEnvironmentVariable("BabySleep");
            //    services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(environmentVariable));
            //}
            //else
            //{
            //    //var connectionString = configuration["ConnectionString:Development"];
            //    //services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            //    //services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //    services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            //        x => x.MigrationsAssembly("BabySleep.Infrastructure")));
            //}
        }
    }
}
