using Coink.Microservice.Domain.Entities.Base;

namespace Coink.Microservice.Domain.Ports
{
    public interface IUnitOfWork
    {
        Task BeginAsync<T>(IRepository<T> repository) where T : DomainEntity;
        Task UseAsync<T>(IRepository<T> repository) where T : DomainEntity;
        Task CreateSavepointAsync(string name);
        Task RollbackAsync();
        Task RollbackToSavepointAsync(string name);
        Task CommitAsync();
    }
}
