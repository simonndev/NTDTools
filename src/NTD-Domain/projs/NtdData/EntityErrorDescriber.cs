using System;
using System.Collections.Generic;
using System.Text;

namespace NtdData
{
    public class EntityErrorDescriber
    {
        public virtual EntityError DefaultError()
        {
            return new EntityError();
        }
    }
}
