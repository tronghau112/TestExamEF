using Data.Base.Entities;
using Data.Base.UnitOfWork;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Base.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TestContext _context;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = _unitOfWork.Context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _ = await _context.SaveChangesAsync();
            return await Task.FromResult(entity);
        }

        public async Task<TEntity> Get(int id, List<string> includeProperty = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(x => x.Id == id);
            if (includeProperty != null && includeProperty.Count > 0)
            {
                foreach (var prop in includeProperty)
                {
                    query = query.Include(prop);
                }
            }

            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, List<string> includeProperty = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (expression != null) query = query.Where(expression);
            if (includeProperty != null) query = includeProperty.Aggregate(query, (current, prop) => current.Include(prop));
            return query;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}