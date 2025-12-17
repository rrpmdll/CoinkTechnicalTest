using System.Diagnostics.CodeAnalysis;
using System.Net;
using Coink.Microservice.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Coink.Microservice.Api.Base.Filters;

[AttributeUsage(AttributeTargets.All)]
[ExcludeFromCodeCoverage]
public sealed class AppExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<AppExceptionFilterAttribute> _logger;

    public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        if (context != null)
        {
            context.HttpContext.Response.StatusCode = context.Exception switch
            {
                NotFoundException => ((int)HttpStatusCode.NotFound),
                AppException => ((int)HttpStatusCode.BadRequest),
                ValidationException => ((int)HttpStatusCode.BadRequest),
                UnauthorizedException => ((int)HttpStatusCode.Unauthorized),
                _ => ((int)HttpStatusCode.InternalServerError)
            };

            _logger.LogError(context.Exception, context.Exception.Message, new[] { context.Exception.StackTrace });

            var msg = new
            {
                context.Exception.Message
            };

            context.Result = new ObjectResult(msg);
        }
    }
}
