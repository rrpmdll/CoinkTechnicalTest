using AutoMapper;
using Coink.Microservice.Domain.DTOs.User;
using Coink.Microservice.Domain.Service.User;
using MediatR;

namespace Coink.Microservice.Application.Feature.User.Commands
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, UserDto>
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserCreateCommandHandler(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UserCreateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _userService.CreateAsync(
                command.Name,
                command.Phone,
                command.Address,
                command.MunicipalityId);

            return _mapper.Map<UserDto>(entity);
        }
    }
}
