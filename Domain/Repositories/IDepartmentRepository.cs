using Coink.Microservice.Domain.Entities.Location;

namespace Coink.Microservice.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentEntity>> GetAllAsync();
        Task<IEnumerable<DepartmentEntity>> GetByCountryIdAsync(Guid countryId);
        Task<DepartmentEntity?> GetByIdAsync(Guid id);
    }
}
