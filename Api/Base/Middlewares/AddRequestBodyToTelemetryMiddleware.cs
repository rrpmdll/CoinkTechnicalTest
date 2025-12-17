using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.ApplicationInsights.DataContracts;

namespace Coink.Microservice.Api.Base.Middlewares
{
    [ExcludeFromCodeCoverage]
    public class AddRequestBodyToTelemetryMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var method = context.Request.Method;

            context.Request.EnableBuffering();

            if (context.Request.Body.CanRead && (method == HttpMethods.Post || method == HttpMethods.Put))
            {
                string requestBody;

                using (var reader = new StreamReader(
                    context.Request.Body,
                    Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: false,
                    bufferSize: 512, leaveOpen: true))
                {
                    requestBody = await reader.ReadToEndAsync();
                }

                context.Request.Body.Position = 0;

                var requestTelemetry = context.Features.Get<RequestTelemetry>();
                requestTelemetry?.Properties.Add("RequestBody", requestBody);
            }

            await next(context);
        }
    }
}
