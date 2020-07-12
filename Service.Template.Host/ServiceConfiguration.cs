using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Service.Template.Host.Services.Extensions;
using Service.Template.Repository;

namespace Service.Template.Host
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(IServiceCollection services, Settings settings)
        {
            services.AddControllers();
            services.AddApiVersioning(versionConfig =>
            {
                var versionApi = settings.Get<string>("VersionApi").Split('.');
                versionConfig.DefaultApiVersion = new ApiVersion(
                    int.Parse(versionApi.First()),
                    int.Parse(versionApi.Last())
                );
                versionConfig.AssumeDefaultVersionWhenUnspecified = true;
                versionConfig.ReportApiVersions = true;
            });

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = settings.SwaggerName, Version = "v1"}); });

            services
                .AddTestService()
                .AddRepositories(settings.ConnectionString.ProviderName, settings.ConnectionString.ConnectionString);
        }
    }
}