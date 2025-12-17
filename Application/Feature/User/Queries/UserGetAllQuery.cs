using Coink.Microservice.Domain.DTOs.User;
using MediatR;

namespace Coink.Microservice.Application.Feature.User.Queries
{
    public record UserGetAllQuery() : IRequest<IEnumerable<UserDto>>;
}
