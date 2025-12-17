using System.Linq.Expressions;
using Coink.Microservice.Domain.Common;
using Coink.Microservice.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Storage;

namespace Coink.Microservice.Domain.Ports
{
    public interface IRepository<E> where E : DomainEntity
    {
        Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null,
            Func<IQueryable<E>, IOrderedQueryable<E>>? orderBy = null, string includeStringProperties = "",
            bool isTracking = false);

        Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>>? filter = null,
            Func<IQueryable<E>, IOrderedQueryable<E>>? orderBy = null,
            bool isTracking = false, params Expression<Func<E, object>>[] includeObjectProperties);

        Task<PagedResult<E>> GetPagedAsync(
            PaginationParameters parameters,
            Expression<Func<E, bool>>? filter = null,
            string includeStringProperties = "",
            bool isTracking = false
        );

        Task<PagedResult<E>> GetPagedAsync(
            PaginationParameters parameters,
            Expression<Func<E, bool>>? filter = null,
            bool isTracking = false,
            params Expression<Func<E, object>>[] includeObjectProperties
        );

        Task<E?> FindAsync(object id);
        Task<E> AddAsync(E entity);
        Task AddRangeAsync(IEnumerable<E> entities);
        Task UpdateAsync(E entity);
        Task RemoveAsync(E entity);
        Task RemoveRangeAsync(IEnumerable<E> entities);
        Task<E> FindByAlternateKeyAsync(Expression<Func<E, bool>> alternateKey, string includeProperties = "");

        IDbContextTransaction BeginTransaction();
    }
}
