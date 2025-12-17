using AutoMapper;
using Coink.Microservice.Domain.DTOs.Location;
using Coink.Microservice.Domain.Repositories;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public class MunicipalityGetByDepartmentIdQueryHandler : IRequestHandler<MunicipalityGetByDepartmentIdQuery, IEnumerable<MunicipalityDto>>
    {
        private readonly IMunicipalityRepository _municipalityRepository;
        private readonly IMapper _mapper;

        public MunicipalityGetByDepartmentIdQueryHandler(IMunicipalityRepository municipalityRepository, IMapper mapper)
        {
            _municipalityRepository = municipalityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MunicipalityDto>> Handle(MunicipalityGetByDepartmentIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _municipalityRepository.GetByDepartmentIdAsync(request.DepartmentId);
            return _mapper.Map<IEnumerable<MunicipalityDto>>(entities);
        }
    }
}
