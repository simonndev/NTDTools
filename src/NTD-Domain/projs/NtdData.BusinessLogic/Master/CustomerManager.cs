using Microsoft.Extensions.Logging;
using NtdData.Master;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace NtdData.BusinessLogic.Master
{
    public class CustomerManager<TCustomer>
        : EntityManagerBase<TCustomer>
        where TCustomer : class
    {
        public CustomerManager(ICustomerStore<TCustomer> store
            , EntityErrorDescriber errorDescriber
            , ILogger<EntityManagerBase<TCustomer>> logger)
            : base(errorDescriber, logger)
        {
            Store = store;
        }

        /// <summary>
        /// Gets or sets the persistence store the manager operates over.
        /// </summary>
        /// <value>The persistence store the manager operates over.</value>
        protected internal ICustomerStore<TCustomer> Store { get; set; }

        /// <summary>
        /// Creates the specified <paramref name="customer"/> in the backing store with no password,
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="customer">The customer to create.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation, containing the <see cref="EntityResult"/>
        /// of the operation.
        /// </returns>
        public virtual async Task<EntityResult> CreateAsync(TCustomer customer)
        {
            ThrowIfDisposed();
            //await UpdateSecurityStampInternal(customer).ConfigureAwait(false);
            //var result = await ValidateUserAsync(customer).ConfigureAwait(false);
            //if (!result.Succeeded)
            //{
            //    return result;
            //}
            //if (Options.Lockout.AllowedForNewUsers && SupportsUserLockout)
            //{
            //    await GetUserLockoutStore().SetLockoutEnabledAsync(customer, true, CancellationToken).ConfigureAwait(false);
            //}
            //await UpdateNormalizedUserNameAsync(customer).ConfigureAwait(false);
            //await UpdateNormalizedEmailAsync(customer).ConfigureAwait(false);

            return await Store.CreateAsync(customer, MainCancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Finds and returns a customer, if any, who has the specified <paramref name="customerId"/>.
        /// </summary>
        /// <param name="customerId">The customer ID to search for.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation, containing the customer matching the specified <paramref name="customerId"/> if it exists.
        /// </returns>
        public virtual async Task<TCustomer> FindByIdAsync(string customerId)
        {
            ThrowIfDisposed();
            return await Store.FindByIdAsync(customerId, MainCancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the customer identifier for the specified <paramref name="customer"/>.
        /// </summary>
        /// <param name="customer">The customer whose identifier should be retrieved.</param>
        /// <returns>The <see cref="Task"/> that represents the asynchronous operation, containing the identifier for the specified <paramref name="customer"/>.</returns>
        public virtual async Task<string> GetCustomerIdAsync(TCustomer customer)
        {
            ThrowIfDisposed();
            return await Store.GetCustomerIdStringAsync(customer, MainCancellationToken).ConfigureAwait(false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
