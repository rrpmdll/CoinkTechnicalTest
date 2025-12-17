using Coink.Microservice.Domain.DTOs.Location;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public record MunicipalityGetAllQuery() : IRequest<IEnumerable<MunicipalityDto>>;
}
