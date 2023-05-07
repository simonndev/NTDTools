using NtdData.Master;
using NtdEntities.Master;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NtdData.Stores.Master
{
    public abstract class CustomerStoreBase<TCustomer, TKey>
        : EntityStoreBase<TCustomer, TKey>
        , ICustomerStore<TCustomer>
        , IQueryableCustomerStore<TCustomer>
        , ICustomerOrganizationStore<TCustomer>
        where TCustomer : Customer<TKey>
        where TKey : IEquatable<TKey>
    {
        protected CustomerStoreBase(EntityErrorDescriber errorDescriber)
            : base(errorDescriber)
        {
        }
        public abstract Task<string> GetCustomerIdStringAsync(TCustomer customer, CancellationToken cancellationToken = default);

        public abstract Task<IList<TCustomer>> GetBranchOfficesAsync(TCustomer customer, CancellationToken cancellationToken = default);
        
        public abstract Task<TCustomer> GetMasterOfficeAsync(TCustomer customer, CancellationToken cancellationToken = default);
    }
}
