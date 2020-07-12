using Microsoft.Extensions.DependencyInjection;
using Service.Template.Host.Services.Components;

namespace Service.Template.Host.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddTestService(this IServiceCollection services)
        {
            services.AddTransient(service => new TestService());
            return services;
        }
    }
}