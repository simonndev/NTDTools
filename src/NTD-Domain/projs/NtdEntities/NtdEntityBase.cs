using System;

namespace NtdEntities
{
    public abstract class NtdEntityBase<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
