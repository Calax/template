using Npgsql;

namespace Service.Template.Host
{
    public class PgConnectionStringInfo
    {
        public string ConnectionString { get; set; }
        public string ProviderName => LinqToDB.ProviderName.PostgreSQL95;

        public string DatabaseName
        {
            get
            {
                var builder = new NpgsqlConnectionStringBuilder(ConnectionString);
                return builder.Database;
            }
        }
    }
}