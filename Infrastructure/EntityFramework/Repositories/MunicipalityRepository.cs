using Coink.Microservice.Domain.Entities.Location;
using Coink.Microservice.Domain.Repositories;
using Coink.Microservice.Infrastructure.Attributes;
using Coink.Microservice.Ports;

namespace Coink.Microservice.Infrastructure.EntityFramework.Repositories
{
    [Repository]
    public class MunicipalityRepository : IMunicipalityRepository
    {
        private readonly IQueryWrapper _queryWrapper;

        public MunicipalityRepository(IQueryWrapper queryWrapper)
        {
            _queryWrapper = queryWrapper;
        }

        public async Task<IEnumerable<MunicipalityEntity>> GetAllAsync()
        {
            var result = await _queryWrapper.QueryAsync<MunicipalityEntity>("MunicipalityGetAll");
            return result;
        }

        public async Task<IEnumerable<MunicipalityEntity>> GetByDepartmentIdAsync(Guid departmentId)
        {
            var result = await _queryWrapper.QueryAsync<MunicipalityEntity>("MunicipalityGetByDepartmentId", new { p_department_id = departmentId });
            return result;
        }

        public async Task<MunicipalityEntity?> GetByIdAsync(Guid id)
        {
            var result = await _queryWrapper.QueryFirstOrDefaultAsync<MunicipalityEntity>("MunicipalityGetById", new { p_id = id });
            return result;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var result = await _queryWrapper.QuerySingleAsync<bool>("MunicipalityExists", new { p_id = id });
            return result;
        }
    }
}
