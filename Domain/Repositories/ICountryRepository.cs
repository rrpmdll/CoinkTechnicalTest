using Coink.Microservice.Domain.Entities.Location;

namespace Coink.Microservice.Domain.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryEntity>> GetAllAsync();
        Task<CountryEntity?> GetByIdAsync(Guid id);
    }
}
