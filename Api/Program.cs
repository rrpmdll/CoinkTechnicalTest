using Coink.Microservice.Api.Base.Authentication;
using Coink.Microservice.Api.Base.Extensions;
using Coink.Microservice.Api.Base.Filters;
using Coink.Microservice.Api.Base.HealthChecks;
using Coink.Microservice.Api.Base.Middlewares;
using Coink.Microservice.Infrastructure.Extensions;
using Coink.Microservice.Infrastructure.Logger;
using Microsoft.ApplicationInsights.Extensibility;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Logging.AddCoinkLogger(configuration);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(AppExceptionFilterAttribute));
});
builder.Services.AddApplicationInsightsTelemetry(configuration);
builder.Services.AddTransient<AddRequestBodyToTelemetryMiddleware>();
builder.Services.AddSingleton<ITelemetryInitializer, FilterHealthchecksTelemetryInitializer>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCoinkSwagger();
builder.Services.AddCoinkHealthChecks(configuration);
builder.Services.AddCoinkCors(configuration);

builder.Services.AddApplication(configuration);
builder.Services.AddInfrastructure(configuration);

builder.Services.AddApiKeyAuthentication(builder.Configuration);

//builder.Services.AddHostedService<AutoMigrateDbCoink>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (configuration.GetValue<bool>("ApplicationInsights:IncludeRequestBody"))
{
    app.UseMiddleware<AddRequestBodyToTelemetryMiddleware>();
}

app.UsePathBase(configuration.GetValue("PathBase", string.Empty));

app.UseCoinkCors();
app.UseCoinkHeaders();
app.UseCoinkSwagger(configuration);
app.UseCoinkHealthChecks(configuration);

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
