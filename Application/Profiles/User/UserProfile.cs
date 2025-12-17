using AutoMapper;
using Coink.Microservice.Domain.DTOs.User;
using Coink.Microservice.Domain.Entities.User;

namespace Coink.Microservice.Application.Profiles.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>();
        }
    }
}
