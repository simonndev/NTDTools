using NtdData.Master;
using NtdEntities;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NtdData.Stores
{
    public abstract class EntityStoreBase<TEntity, TKey> : IEntityStore<TEntity>
        , IQueryableEntityStore<TEntity>
        where TEntity : NtdEntityBase<TKey>
        where TKey : IEquatable<TKey>
    {
        public EntityStoreBase(EntityErrorDescriber errorDescriber)
        {
            ErrorDescriber = errorDescriber ?? throw new ArgumentNullException(nameof(errorDescriber));
        }

        /// <summary>
        /// Gets or sets the <see cref="EntityErrorDescriber"/> for any error that occurred with the current operation.
        /// </summary>
        public EntityErrorDescriber ErrorDescriber { get; set; }

        public abstract IQueryable<TEntity> Query
        {
            get;
        }

        public Task<string> GetIdStringAsync(TEntity entity, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            if (entity is null) throw new ArgumentNullException(nameof(entity));

            return Task.FromResult(ConvertIdToString(entity.Id));
        }

        public abstract Task<EntityResult> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        public abstract Task<EntityResult> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        public abstract Task<EntityResult> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        public abstract Task<TEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default);
        public abstract Task<TEntity> FindByNameAsync(string name, CancellationToken cancellationToken = default);

        public virtual string ConvertIdToString(TKey id)
        {
            if (Equals(id, default(TKey))) return null;

            return id.ToString();
        }

        public virtual TKey ConvertIfFromString(string id)
        {
            if (string.IsNullOrEmpty(id)) return default;

            return (TKey)TypeDescriptor.GetConverter(typeof(TKey)).ConvertFromInvariantString(id);
        }

        /// <summary>
        /// Throws if this class has been disposed.
        /// </summary>
        protected void ThrowIfDisposed()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
        }

        #region IDisposable implementation
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposed = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~EntityStoreBase()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
