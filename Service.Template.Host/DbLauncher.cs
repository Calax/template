using System;
using Npgsql;
using Serilog;
using Service.Template.Repository.Migrations;

namespace Service.Template.Host
{
    public static class DbLauncher
    {
        public static void UpdateDb(ILogger logger, string connectionString)
        {
            logger.Information("Updating database...");
            try
            {
                MigrationRunner.MigrateToLatest(connectionString);
                logger.Information("Database updated");
            }
            catch (Exception ex)
            {
                logger.Error("Failed to update database", ex);
                throw;
            }
        }

        public static void CreateDb(string connectionString, string databaseName)
        {
            var builder = new NpgsqlConnectionStringBuilder(connectionString);
            builder.Database = "postgres";
            var serverConnectionString = builder.ToString();

            var createDbQuery = @$"
CREATE EXTENSION IF NOT EXISTS dblink;

DO
$createDb$
BEGIN
	IF NOT EXISTS (SELECT FROM pg_database WHERE datname='{databaseName}') THEN
    	PERFORM dblink_exec('dbname=' || current_database(), 'CREATE DATABASE ' || quote_ident('{databaseName}'));
	END IF;
END
$createDb$
";

            using var conn = new NpgsqlConnection(serverConnectionString);
            conn.Open();
            using var dbCommand = new NpgsqlCommand(createDbQuery, conn);
            dbCommand.ExecuteNonQuery();
        }
    }
}