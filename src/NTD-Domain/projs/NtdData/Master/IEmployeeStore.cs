using System;
using System.Collections.Generic;
using System.Text;

namespace NtdData.Master
{
    public interface IEmployeeStore<TEmployee> : IEntityStore<TEmployee>
        where TEmployee : class
    {
    }

    public interface IQueryableEmployeeStore<TEmployee> : IEmployeeStore<TEmployee>, IQueryableEntityStore<TEmployee>
        where TEmployee : class
    {
    }
}
