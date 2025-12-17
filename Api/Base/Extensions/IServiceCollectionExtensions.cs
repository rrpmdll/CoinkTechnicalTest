using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;

namespace Coink.Microservice.Api.Base.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCoinkSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Coink API",
                    Description = "Coink Microservice TechnicalTest"
                });

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter your JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                setupAction.CustomSchemaIds(schema => schema.FullName);
            });
        }

        public static IServiceCollection AddCoinkCors(this IServiceCollection services, IConfiguration configuration)
        {
            var allowSpecificOrigins = configuration.GetSection("AllowSpecificOrigins:domains").Get<IEnumerable<string>>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    p => p.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(allowSpecificOrigins!.ToArray())
                    .AllowCredentials()
                    .WithExposedHeaders());
            });

            return services;
        }
    }
}
