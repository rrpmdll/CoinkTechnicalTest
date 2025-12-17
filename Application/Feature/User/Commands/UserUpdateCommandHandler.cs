using AutoMapper;
using Coink.Microservice.Domain.DTOs.User;
using Coink.Microservice.Domain.Service.User;
using MediatR;

namespace Coink.Microservice.Application.Feature.User.Commands
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, UserDto>
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserUpdateCommandHandler(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UserUpdateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _userService.UpdateAsync(
                command.Id,
                command.Name,
                command.Phone,
                command.Address,
                command.MunicipalityId);

            return _mapper.Map<UserDto>(entity);
        }
    }
}
