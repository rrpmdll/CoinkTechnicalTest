using AutoMapper;
using Coink.Microservice.Domain.DTOs.Location;
using Coink.Microservice.Domain.Exceptions;
using Coink.Microservice.Domain.IResources;
using Coink.Microservice.Domain.Repositories;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public class MunicipalityGetByIdQueryHandler : IRequestHandler<MunicipalityGetByIdQuery, MunicipalityDto>
    {
        private readonly IMunicipalityRepository _municipalityRepository;
        private readonly IMapper _mapper;
        private readonly IMessagesProvider _messages;

        public MunicipalityGetByIdQueryHandler(
            IMunicipalityRepository municipalityRepository, 
            IMapper mapper,
            IMessagesProvider messages)
        {
            _municipalityRepository = municipalityRepository;
            _mapper = mapper;
            _messages = messages;
        }

        public async Task<MunicipalityDto> Handle(MunicipalityGetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _municipalityRepository.GetByIdAsync(request.Id);
            
            if (entity == null)
                throw new NotFoundException(string.Format(_messages.MunicipalityNotFound, request.Id));

            return _mapper.Map<MunicipalityDto>(entity);
        }
    }
}
