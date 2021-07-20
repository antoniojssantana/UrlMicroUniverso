using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using url.business.Models;

namespace url.business.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);

        Task<Entity> GetId(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

        Task ChangeState(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicado);

        Task<int> SaveChanges();
    }
}