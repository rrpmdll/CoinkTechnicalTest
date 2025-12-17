using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;

namespace Coink.Microservice.Api.Base.HealthChecks
{
    [ExcludeFromCodeCoverage]
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly string _stringConnectionKey;
        private readonly IConfiguration _configuration;

        public DatabaseHealthCheck(string stringConnectionKey, IConfiguration configuration)
        {
            _stringConnectionKey = stringConnectionKey;
            _configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(_configuration.GetValue<int>("HealthCheck:Database:Timeout")));

                cancellationToken.Register(cts.Cancel);

                await using var connection = new NpgsqlConnection(_configuration[_stringConnectionKey]);

                await connection.OpenAsync(cts.Token);

                return HealthCheckResult.Healthy();

            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}
