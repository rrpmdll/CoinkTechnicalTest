using AutoMapper;
using Coink.Microservice.Domain.DTOs.Location;
using Coink.Microservice.Domain.Exceptions;
using Coink.Microservice.Domain.IResources;
using Coink.Microservice.Domain.Repositories;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public class CountryGetByIdQueryHandler : IRequestHandler<CountryGetByIdQuery, CountryDto>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IMessagesProvider _messages;

        public CountryGetByIdQueryHandler(
            ICountryRepository countryRepository, 
            IMapper mapper,
            IMessagesProvider messages)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _messages = messages;
        }

        public async Task<CountryDto> Handle(CountryGetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _countryRepository.GetByIdAsync(request.Id);
            
            if (entity == null)
                throw new NotFoundException(string.Format(_messages.CountryNotFound, request.Id));

            return _mapper.Map<CountryDto>(entity);
        }
    }
}
