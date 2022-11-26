﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace AppCore.DataAccess.EntityFramework.Bases
{
    public abstract class RepoBase<TEntity> : IDisposable where TEntity : class, new() // Repository Pattern
    {
        protected readonly DbContext _dbContext;

        protected RepoBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object?>>[] entitiesToInclude)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            foreach (var entityToInclude in entitiesToInclude)
            {
                query = query.Include(entityToInclude);
            }
            return query;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object?>>[] entitiesToInclude)
        {
            var query = Query(entitiesToInclude);
            query = query.Where(predicate);
            return query;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
