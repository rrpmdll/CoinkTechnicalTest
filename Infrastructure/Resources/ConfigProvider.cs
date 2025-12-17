using Coink.Microservice.Domain.IResources;
using Microsoft.Extensions.Configuration;

namespace Coink.Microservice.Infrastructure.Resources
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region RetryPolicy
        public int GetRetryCount()
        {
            var retryCount = _configuration.GetSection("RetryPolicy:RetryCount").Value;

            if (!int.TryParse(retryCount, out var result))
            {
                throw new InvalidCastException($"El valor de la variable de configuracion RetryCount: {retryCount} no es valido ");
            }

            return result;
        }
        public double GetRetrySeconds()
        {
            var retrySeconds = _configuration.GetSection("RetryPolicy:RetrySeconds").Value;

            if (!double.TryParse(retrySeconds, out var result))
            {
                throw new InvalidCastException($"El valor de la variable de configuracion RetrySeconds: {retrySeconds} no es valido");
            }

            return result;
        }
        #endregion

        #region JwtSettings
        public string SecretKeyJwtSettings => _configuration.GetSection("JwtSettings:SecretKey").Value!;
        public string IssuerJwtSettings => _configuration.GetSection("JwtSettings:Issuer").Value!;
        public string AudienceJwtSettings => _configuration.GetSection("JwtSettings:Audience").Value!;
        public int TokenExpirationInMinutesJwtSettings => _configuration.GetValue<int>("JwtSettings:TokenExpirationInMinutes");
        #endregion
    }
}
