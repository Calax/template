using System;
using JetBrains.Annotations;

namespace Service.Template.Repository
{
    public class DbProvider
    {
        [NotNull]
        public string ProviderName { get; }

        [NotNull]
        public string ConnectionString { get; }

        public DbProvider([NotNull] string providerName, [NotNull] string connectionString)
        {
            if (string.IsNullOrEmpty(providerName))
                throw new ArgumentNullException(nameof(providerName));

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            ProviderName = providerName;
            ConnectionString = connectionString;
        }

        public Db GetDb() => new Db(ProviderName, ConnectionString);
    }
}