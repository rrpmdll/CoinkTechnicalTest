using System.ComponentModel.DataAnnotations;
using Coink.Microservice.Domain.DTOs.Location;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public record MunicipalityGetByDepartmentIdQuery(
        [Required] Guid DepartmentId
    ) : IRequest<IEnumerable<MunicipalityDto>>;
}
