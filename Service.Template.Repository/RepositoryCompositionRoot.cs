using Microsoft.Extensions.DependencyInjection;
using Service.Template.Repository.Bo.Sample;

namespace Service.Template.Repository
{
    public static class RepositoryCompositionRoot
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, string providerName, string connectionString)
        {
            services.AddSingleton<DbProvider>(fact => new DbProvider(providerName, connectionString));
            services.AddSingleton<ISessionManager, SessionManager>();
            services.AddSingleton<ISampleTableRepository, SampleTableRepository>();
            
            return services;
        }
    }
}