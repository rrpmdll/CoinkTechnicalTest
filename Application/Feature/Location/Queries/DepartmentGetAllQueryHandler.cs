using AutoMapper;
using Coink.Microservice.Domain.DTOs.Location;
using Coink.Microservice.Domain.Repositories;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public class DepartmentGetAllQueryHandler : IRequestHandler<DepartmentGetAllQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentGetAllQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(DepartmentGetAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _departmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(entities);
        }
    }
}
