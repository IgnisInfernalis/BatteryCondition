using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BatteryConditionInventory.Core.SharedKernel;

namespace BatteryConditionInventory.Core.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        ICollection<TEntity> GetWithInclude
            (params Expression<Func<TEntity, object>>[] includeProperties);
        ICollection<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
