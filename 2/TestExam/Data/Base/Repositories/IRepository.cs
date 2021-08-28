using Data.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Base.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<List<TEntity>> GetAll();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, List<string> includeProperty = null);

        Task<TEntity> Get(int id, List<string> includeProperty = null);

        Task<TEntity> Add(TEntity entity);
    }
}