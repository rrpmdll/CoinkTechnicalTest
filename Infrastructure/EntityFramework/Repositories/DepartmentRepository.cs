using Coink.Microservice.Domain.Entities.Location;
using Coink.Microservice.Domain.Repositories;
using Coink.Microservice.Infrastructure.Attributes;
using Coink.Microservice.Ports;

namespace Coink.Microservice.Infrastructure.EntityFramework.Repositories
{
    [Repository]
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IQueryWrapper _queryWrapper;

        public DepartmentRepository(IQueryWrapper queryWrapper)
        {
            _queryWrapper = queryWrapper;
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAllAsync()
        {
            var result = await _queryWrapper.QueryAsync<DepartmentEntity>("DepartmentGetAll");
            return result;
        }

        public async Task<IEnumerable<DepartmentEntity>> GetByCountryIdAsync(Guid countryId)
        {
            var result = await _queryWrapper.QueryAsync<DepartmentEntity>("DepartmentGetByCountryId", new { p_country_id = countryId });
            return result;
        }

        public async Task<DepartmentEntity?> GetByIdAsync(Guid id)
        {
            var result = await _queryWrapper.QueryFirstOrDefaultAsync<DepartmentEntity>("DepartmentGetById", new { p_id = id });
            return result;
        }
    }
}
