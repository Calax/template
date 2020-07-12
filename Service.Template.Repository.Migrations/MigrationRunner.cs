using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Service.Template.Repository.Migrations
{
    public static class MigrationRunner
    {
        public static void MigrateToLatest(string connectionString)
        {
            var serviceProvider = CreateServiceProvider(connectionString);
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        private static IServiceProvider CreateServiceProvider(string connectionString)
        {
            void RunnerConfig(IMigrationRunnerBuilder rb) =>
                rb.AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(MigrationRunner).Assembly)
                    .For.All();

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(RunnerConfig)
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
    }
}