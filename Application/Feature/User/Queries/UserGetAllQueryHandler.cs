using AutoMapper;
using Coink.Microservice.Domain.DTOs.User;
using Coink.Microservice.Domain.Service.User;
using MediatR;

namespace Coink.Microservice.Application.Feature.User.Queries
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, IEnumerable<UserDto>>
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserGetAllQueryHandler(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _userService.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(entities);
        }
    }
}
