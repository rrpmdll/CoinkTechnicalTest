using Coink.Microservice.Domain.Entities.User;

namespace Coink.Microservice.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity?> CreateAsync(string name, string phone, string address, Guid municipalityId);
        Task<UserEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity?> UpdateAsync(Guid id, string name, string phone, string address, Guid municipalityId);
        Task<bool> DeleteAsync(Guid id);
    }
}
