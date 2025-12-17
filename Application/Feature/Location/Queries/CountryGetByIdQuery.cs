using System.ComponentModel.DataAnnotations;
using Coink.Microservice.Domain.DTOs.Location;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public record CountryGetByIdQuery(
        [Required] Guid Id
    ) : IRequest<CountryDto>;
}
