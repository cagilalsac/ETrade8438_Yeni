using AppCore.DataAccess.EntityFramework.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public abstract class CategoryRepoBase : RepoBase<Category>
    {
        protected CategoryRepoBase(ETradeContext dbContext) : base(dbContext)
        {
        }
    }
}
