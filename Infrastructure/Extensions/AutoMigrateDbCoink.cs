using Coink.Microservice.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Coink.Microservice.Infrastructure.Extensions
{
    public class AutoMigrateDbCoink : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public AutoMigrateDbCoink(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PersistenceContext>();

                if (!AllMigrationsApplied(context))
                {
                    context.Database.Migrate();
                }

                EnsureSeeded(context);
            }

            return Task.CompletedTask;
        }

        private bool AllMigrationsApplied(PersistenceContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        private void EnsureSeeded(PersistenceContext context)
        {
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
