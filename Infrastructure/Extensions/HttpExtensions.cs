using Coink.Microservice.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Coink.Microservice.Infrastructure.Extensions
{
    public static class HttpExtensions
    {
        private const string PARKING_ID = "ParkingId";
        public static Guid GetParkingId(this HttpContext httpContext)
        {
            Guid parkingIdHttpContext = Guid.Parse(httpContext.User.Claims.FirstOrDefault(claim => claim.Type.Equals(PARKING_ID))?.Value
                ?? throw new UnauthorizedException("No se encontró el ParkingId en la sesión"));

            if (parkingIdHttpContext == Guid.Empty)
                throw new UnauthorizedException();

            return parkingIdHttpContext;
        }
    }
}
