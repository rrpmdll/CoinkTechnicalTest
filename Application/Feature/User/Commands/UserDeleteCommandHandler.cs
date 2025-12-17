using Coink.Microservice.Domain.Service.User;
using MediatR;

namespace Coink.Microservice.Application.Feature.User.Commands
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, bool>
    {
        private readonly UserService _userService;

        public UserDeleteCommandHandler(UserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(UserDeleteCommand command, CancellationToken cancellationToken)
        {
            return await _userService.DeleteAsync(command.Id);
        }
    }
}
