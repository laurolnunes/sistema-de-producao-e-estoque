using SPE.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SPE.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        void Update(TEntity obj);

        void Remove(int id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();

    }
}