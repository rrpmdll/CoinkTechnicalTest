using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Coink.Microservice.Api.Base.HealthChecks
{
    [ExcludeFromCodeCoverage]
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddCoinkHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy(), tags: new List<string> { "ms" })
                .AddCheck("db-check", new DatabaseHealthCheck("ConnectionStrings:Base", configuration), tags: new List<string> { "db" });

            return services;
        }
    }
}
