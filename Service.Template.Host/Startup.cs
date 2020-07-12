using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Service.Template.Host
{
    public sealed class Startup
    {
        private readonly ILogger             logger;
        private readonly IWebHostEnvironment environment;
        private readonly Settings            settings;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Log.Logger = logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Service", "Service.Template")
                .CreateLogger();

            logger.Information("Service is launching. Listing configuration: {@configuration}", configuration);

            this.environment = environment;
            settings = new Settings(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ServiceConfiguration.RegisterServices(services, settings);

            if (!environment.IsProduction())
                DbLauncher.CreateDb(settings.ConnectionString.ConnectionString, settings.ConnectionString.DatabaseName);

            DbLauncher.UpdateDb(logger, settings.ConnectionString.ConnectionString);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", settings.SwaggerName); });
            app.UseSwagger();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}