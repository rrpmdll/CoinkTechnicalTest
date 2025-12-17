using System.ComponentModel.DataAnnotations;
using Coink.Microservice.Domain.DTOs.User;
using MediatR;

namespace Coink.Microservice.Application.Feature.User.Queries
{
    public record UserGetByIdQuery(
        [Required] Guid Id
    ) : IRequest<UserDto>;
}
