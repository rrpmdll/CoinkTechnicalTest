using System.Diagnostics.CodeAnalysis;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace Coink.Microservice.Api.Base.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCoinkCors(this IApplicationBuilder application)
        {
            return application.UseCors("AllowAll");
        }

        public static IApplicationBuilder UseCoinkHeaders(this IApplicationBuilder application)
        {
            application.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "master-only");
                context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Add("Cache-Control", "no-cache,no-store,must-revalidate");
                context.Response.Headers.Add("Pragma", "no-cache");
                context.Response.Headers.Remove("X-Powered-By");
                context.Response.Headers.Remove("Server");
                await next();
            });

            return application;
        }

        public static IApplicationBuilder UseCoinkHealthChecks(this IApplicationBuilder application, IConfiguration configuration)
        {
            application.UseHealthChecks($"{configuration["HealthCheck:RoutePrefix"]}/healthz", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            return application;
        }

        public static IApplicationBuilder UseCoinkSwagger(this IApplicationBuilder application, IConfiguration configuration)
        {
            var swaggerRoutePrefix = string.IsNullOrWhiteSpace(configuration["PathBase"])
                ? "swagger"
                : $"{configuration["PathBase"]!.TrimStart('/')}-swagger";

            application.UseSwagger(c =>
            {
                c.RouteTemplate = $"{swaggerRoutePrefix}/{{documentName}}/swagger.json";
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    var scheme = httpReq.Scheme;
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{scheme}://{httpReq.Host.Value}{configuration["PathBase"]}" } };
                });
            });

            application.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint($"/{swaggerRoutePrefix}/v1/swagger.json", "Coink.Microservice.Api.V1");
                setupAction.RoutePrefix = $"{swaggerRoutePrefix}";
            });

            return application;
        }
    }
}
