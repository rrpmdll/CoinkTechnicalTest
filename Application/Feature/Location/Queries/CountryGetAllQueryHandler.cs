using AutoMapper;
using Coink.Microservice.Domain.DTOs.Location;
using Coink.Microservice.Domain.Repositories;
using MediatR;

namespace Coink.Microservice.Application.Feature.Location.Queries
{
    public class CountryGetAllQueryHandler : IRequestHandler<CountryGetAllQuery, IEnumerable<CountryDto>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryGetAllQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> Handle(CountryGetAllQuery request, CancellationToken cancellationToken)
        {
            var entities = await _countryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CountryDto>>(entities);
        }
    }
}
