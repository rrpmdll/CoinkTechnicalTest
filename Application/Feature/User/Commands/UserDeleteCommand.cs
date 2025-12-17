using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Coink.Microservice.Application.Feature.User.Commands
{
    public record UserDeleteCommand(
        [Required] Guid Id
    ) : IRequest<bool>;
}
