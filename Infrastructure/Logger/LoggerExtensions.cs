using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Exceptions;

namespace Coink.Microservice.Infrastructure.Logger
{
    public static class LoggerExtensions
    {
        public static ILoggingBuilder AddCoinkLogger(this ILoggingBuilder logging, IConfiguration configuration)
        {
            logging.ClearProviders();

            ConfigureLogger(configuration);

            logging.AddSerilog(Log.Logger);

            return logging;
        }

        private static void ConfigureLogger(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithMachineName()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.ApplicationInsights(configuration["ApplicationInsights:ConnectionString"], TelemetryConverter.Traces)
                .CreateLogger();
        }
    }
}
