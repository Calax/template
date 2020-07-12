using Microsoft.Extensions.Configuration;

namespace Service.Template.Host
{
    public class Settings
    {
        private readonly IConfiguration configuration;

        public Settings(IConfiguration configuration)
        {
            this.configuration = configuration;
            
            ConnectionString = new PgConnectionStringInfo
            {
                ConnectionString = configuration.GetConnectionString("db.connectionString")
            };
        }

        public PgConnectionStringInfo ConnectionString { get; set; }

        public string SwaggerName => configuration.GetValue<string>("SwaggerName");

        public T Get<T>(string key)
        {
            return configuration.GetValue<T>(key);
        }
    }
}