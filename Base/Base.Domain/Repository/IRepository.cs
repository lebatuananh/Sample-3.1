using System;
using System.Collections.Generic;
using System.Text;
using Base.Domain.Entities;

namespace Base.Domain.Repository
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
    }
}
