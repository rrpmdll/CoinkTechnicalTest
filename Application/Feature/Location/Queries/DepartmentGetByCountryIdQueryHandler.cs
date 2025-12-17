using AutoMapper;
using Coink.Microservice.Domain.DTOs.Location;
using Coink.Microservice.Domain.Repositories;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public class DepartmentGetByCountryIdQueryHandler : IRequestHandler<DepartmentGetByCountryIdQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentGetByCountryIdQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(DepartmentGetByCountryIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _departmentRepository.GetByCountryIdAsync(request.CountryId);
            return _mapper.Map<IEnumerable<DepartmentDto>>(entities);
        }
    }
}
