using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NtdData.Master
{
    public interface IEntityStore<TEntity> : IDisposable
        where TEntity : class
    {
        Task<TEntity> FindByIdAsync(string id, CancellationToken cancellationToken);
        Task<TEntity> FindByNameAsync(string name, CancellationToken cancellationToken);

        Task<string> GetIdStringAsync(TEntity entity, CancellationToken cancellationToken);

        Task<EntityResult> CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<EntityResult> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<EntityResult> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }

    public interface IQueryableEntityStore<TEntity> : IEntityStore<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query { get; }
    }
}
