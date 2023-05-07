using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NtdData.BusinessLogic
{
    public abstract class EntityManagerBase<TEntity> : IDisposable where TEntity : class
    {
        public EntityManagerBase(EntityErrorDescriber errorDescriber, ILogger<EntityManagerBase<TEntity>> logger)
        {
            ErrorDescriber = errorDescriber;
            Logger = logger;
        }

        /// <summary>
        /// The <see cref="EntityErrorDescriber"/> used to generate error messages.
        /// </summary>
        public EntityErrorDescriber ErrorDescriber { get; set; }

        /// <summary>
        /// The <see cref="ILogger"/> used to log messages from the manager.
        /// </summary>
        public virtual ILogger Logger { get; set; }

        /// <summary>
        /// The cancellation token used to cancel operations.
        /// </summary>
        protected virtual CancellationToken MainCancellationToken => CancellationToken.None;

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
        // ~EntityManagerBase()
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

        public void ThrowIfDisposed()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().FullName);
        }
    }
}
