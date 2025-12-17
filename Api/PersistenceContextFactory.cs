using System.Diagnostics.CodeAnalysis;
using Coink.Microservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Coink.Microservice.Api
{
    [ExcludeFromCodeCoverage]
    public class PersistenceContextFactory : IDesignTimeDbContextFactory<PersistenceContext>
    {
        public PersistenceContext CreateDbContext(string[] args)
        {
            var Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PersistenceContext>();
            optionsBuilder.UseNpgsql(Config.GetConnectionString("Base")!, npgsqlopts =>
            {
                npgsqlopts.MigrationsHistoryTable("_MicroMigrationHistory", Config.GetValue<string>("ConnectionStrings:BaseSchema"));
            });

            return new PersistenceContext(optionsBuilder.Options, Config);
        }
    }
}
