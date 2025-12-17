using System.Data;
using Coink.Microservice.Domain.IResources;
using Coink.Microservice.Domain.Ports;
using Coink.Microservice.Domain.Service.User;
using Coink.Microservice.Infrastructure.Addapters;
using Coink.Microservice.Infrastructure.Attributes;
using Coink.Microservice.Infrastructure.EntityFramework;
using Coink.Microservice.Infrastructure.EntityFramework.Adapters;
using Coink.Microservice.Infrastructure.Resources;
using Coink.Microservice.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Serilog;

namespace Coink.Microservice.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue("Database:UseInMemory", false))
            {
                AddInMemoryDatabase(services, configuration);
            }
            else
            {
                AddPostgreSQL(services, configuration);
            }

            services.AddSingleton(Log.Logger);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<UserService>();

            services.AddSingleton<IResource, Resource>();
            services.AddSingleton<IMessagesProvider, MessagesProvider>();
            services.AddSingleton<IConfigProvider, ConfigProvider>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IQueryWrapper), typeof(DapperWrapper));
            services.AddTransient<IDbConnection>(_ => new NpgsqlConnection(configuration.GetConnectionString("Base")));

            AddRepositories(services);

            return services;
        }

        private static void AddRepositories(IServiceCollection repositories)
        {
            var _repositories = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly =>
                {
                    return assembly.FullName is null || assembly.FullName.Contains("Infrastructure", StringComparison.OrdinalIgnoreCase);
                })
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(RepositoryAttribute)));

            foreach (var repository in _repositories)
            {
                var typeInterface = repository.GetInterfaces().Single(x => x.FullName is null || x.FullName.Contains(repository.Name, StringComparison.OrdinalIgnoreCase));
                repositories.AddTransient(typeInterface, repository);
            }
        }

        private static void AddInMemoryDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersistenceContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDatabase");
                options.ConfigureWarnings(warnings =>
                {
                    warnings.Default(WarningBehavior.Log);
                });
            });
        }

        private static void AddPostgreSQL(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersistenceContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Base"),
                    npgsqlOptionsAction =>
                    {
                        npgsqlOptionsAction.MigrationsHistoryTable("_MicroMigrationHistory", configuration.GetConnectionString("BaseSchema"));
                    });

                options.ConfigureWarnings(warnings =>
                {
                    warnings.Default(WarningBehavior.Log);
                });
            });
        }
    }
}
