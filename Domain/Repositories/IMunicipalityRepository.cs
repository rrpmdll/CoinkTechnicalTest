using Coink.Microservice.Domain.Entities.Location;

namespace Coink.Microservice.Domain.Repositories
{
    public interface IMunicipalityRepository
    {
        Task<IEnumerable<MunicipalityEntity>> GetAllAsync();
        Task<IEnumerable<MunicipalityEntity>> GetByDepartmentIdAsync(Guid departmentId);
        Task<MunicipalityEntity?> GetByIdAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
