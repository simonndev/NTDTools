using Microsoft.EntityFrameworkCore;
using NtdEntities.Migrations.SqlServer;

namespace NtdMigrationTool
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                })
                .ConfigureServices((host, services) =>
                {
                    var configuration = host.Configuration;

                    services.AddDbContextFactory<NtdDbContext>(options =>
                    {
                        options.UseSqlServer(
                            configuration.GetConnectionString("Dev"),
                            builder =>
                            {
                                builder.MigrationsAssembly("NtdEntities.Migrations.SqlServer");
                                builder.MigrationsHistoryTable("__ef_migration_history", "master");
                            });
                    }, ServiceLifetime.Transient);
                })
                .Build();

            await host.RunAsync();
        }
    }
}