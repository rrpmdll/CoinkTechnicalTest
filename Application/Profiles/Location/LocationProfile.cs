using AutoMapper;
using Coink.Microservice.Domain.DTOs.Location;
using Coink.Microservice.Domain.Entities.Location;

namespace Coink.Microservice.Application.Profiles.Location
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            // Country mapping
            CreateMap<CountryEntity, CountryDto>();

            // Department mapping
            CreateMap<DepartmentEntity, DepartmentDto>();

            // Municipality mapping
            CreateMap<MunicipalityEntity, MunicipalityDto>();
        }
    }
}
