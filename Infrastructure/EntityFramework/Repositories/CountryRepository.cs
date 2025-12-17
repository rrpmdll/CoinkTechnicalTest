using Coink.Microservice.Domain.Entities.Location;
using Coink.Microservice.Domain.Repositories;
using Coink.Microservice.Infrastructure.Attributes;
using Coink.Microservice.Ports;

namespace Coink.Microservice.Infrastructure.EntityFramework.Repositories
{
    [Repository]
    public class CountryRepository : ICountryRepository
    {
        private readonly IQueryWrapper _queryWrapper;

        public CountryRepository(IQueryWrapper queryWrapper)
        {
            _queryWrapper = queryWrapper;
        }

        public async Task<IEnumerable<CountryEntity>> GetAllAsync()
        {
            var result = await _queryWrapper.QueryAsync<CountryEntity>("CountryGetAll");
            return result;
        }

        public async Task<CountryEntity?> GetByIdAsync(Guid id)
        {
            var result = await _queryWrapper.QueryFirstOrDefaultAsync<CountryEntity>("CountryGetById", new { p_id = id });
            return result;
        }
    }
}
