using AppCore.DataAccess.EntityFramework.Bases;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public abstract class ProductRepoBase : RepoBase<Product>
    {
        protected ProductRepoBase(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
