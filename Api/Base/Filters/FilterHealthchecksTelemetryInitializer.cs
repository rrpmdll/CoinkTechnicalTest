using System.Diagnostics.CodeAnalysis;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace Coink.Microservice.Api.Base.Filters
{
    [ExcludeFromCodeCoverage]
    public class FilterHealthchecksTelemetryInitializer : ITelemetryInitializer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FilterHealthchecksTelemetryInitializer(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public void Initialize(ITelemetry telemetry)
        {
            if ((_httpContextAccessor.HttpContext?.Request.Path.Value?.Contains("healthz", StringComparison.InvariantCultureIgnoreCase)).GetValueOrDefault())
            {
                if (telemetry is ISupportAdvancedSampling advancedSampling)
                {
                    advancedSampling.ProactiveSamplingDecision = SamplingDecision.SampledOut;
                }

                if (string.IsNullOrWhiteSpace(telemetry.Context.Operation.SyntheticSource))
                {
                    telemetry.Context.Operation.SyntheticSource = "HealthCheck";
                }
            }
        }
    }
}
