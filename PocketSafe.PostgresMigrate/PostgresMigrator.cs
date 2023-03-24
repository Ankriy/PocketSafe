using DbUp;
using System;
using System.IO;

namespace PocketSafe.PostgresMigrate
{
    public class PostgresMigrator
    {
        public static void Migrate(string connectionString) {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var upgrader = DeployChanges.To
                    .PostgresqlDatabase(connectionString)
                    .JournalToPostgresqlTable("protection", "__SchemaVersions")
                    .WithScriptsFromFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts"))
                    .WithVariable("BODY", "$BODY$")
                    .WithExecutionTimeout(TimeSpan.FromSeconds(60 * 5)) // 5 минут
                    .Build();

            //var scriptsToExecute = upgrader.GetScriptsToExecute();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
                throw new Exception("Migrate error: ", result.Error);
        }
    }
}
