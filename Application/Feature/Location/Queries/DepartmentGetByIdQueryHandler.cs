using AutoMapper;
using Coink.Microservice.Domain.DTOs.Location;
using Coink.Microservice.Domain.Exceptions;
using Coink.Microservice.Domain.IResources;
using Coink.Microservice.Domain.Repositories;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public class DepartmentGetByIdQueryHandler : IRequestHandler<DepartmentGetByIdQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly IMessagesProvider _messages;

        public DepartmentGetByIdQueryHandler(
            IDepartmentRepository departmentRepository, 
            IMapper mapper,
            IMessagesProvider messages)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _messages = messages;
        }

        public async Task<DepartmentDto> Handle(DepartmentGetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _departmentRepository.GetByIdAsync(request.Id);
            
            if (entity == null)
                throw new NotFoundException(string.Format(_messages.DepartmentNotFound, request.Id));

            return _mapper.Map<DepartmentDto>(entity);
        }
    }
}
