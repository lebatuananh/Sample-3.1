using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain.Entities
{
    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events { get;}

    }
}
