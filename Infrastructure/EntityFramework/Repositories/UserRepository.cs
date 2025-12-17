using Coink.Microservice.Domain.Entities.User;
using Coink.Microservice.Domain.Repositories;
using Coink.Microservice.Infrastructure.Attributes;
using Coink.Microservice.Ports;

namespace Coink.Microservice.Infrastructure.EntityFramework.Repositories
{
    [Repository]
    public class UserRepository : IUserRepository
    {
        private readonly IQueryWrapper _queryWrapper;

        public UserRepository(IQueryWrapper queryWrapper)
        {
            _queryWrapper = queryWrapper;
        }

        public async Task<UserEntity?> CreateAsync(string name, string phone, string address, Guid municipalityId)
        {
            var parameters = new
            {
                p_name = name,
                p_phone = phone,
                p_address = address,
                p_municipality_id = municipalityId
            };

            var result = await _queryWrapper.QueryFirstOrDefaultAsync<UserEntity>("UserCreate", parameters);
            return result;
        }

        public async Task<UserEntity?> GetByIdAsync(Guid id)
        {
            var result = await _queryWrapper.QueryFirstOrDefaultAsync<UserEntity>("UserGetById", new { p_id = id });
            return result;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            var result = await _queryWrapper.QueryAsync<UserEntity>("UserGetAll");
            return result;
        }

        public async Task<UserEntity?> UpdateAsync(Guid id, string name, string phone, string address, Guid municipalityId)
        {
            var parameters = new
            {
                p_id = id,
                p_name = name,
                p_phone = phone,
                p_address = address,
                p_municipality_id = municipalityId
            };

            var result = await _queryWrapper.QueryFirstOrDefaultAsync<UserEntity>("UserUpdate", parameters);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _queryWrapper.QuerySingleAsync<bool>("UserDelete", new { p_id = id });
            return result;
        }
    }
}
