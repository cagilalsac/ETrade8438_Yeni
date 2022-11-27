using AppCore.Records.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace AppCore.DataAccess.EntityFramework.Bases
{
    public abstract class RepoBase<TEntity> : IDisposable where TEntity : RecordBase, new() // Repository Pattern
    {
        public DbContext DbContext { get; set; }

        protected RepoBase(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object?>>[] entitiesToInclude)
        {
            var query = DbContext.Set<TEntity>().AsQueryable();
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

        public 

        public void Dispose()
        {
            DbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
