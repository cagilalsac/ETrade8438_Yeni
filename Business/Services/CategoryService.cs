using AppCore.Business.Services.Bases;
using AppCore.Results.Bases;
using Business.Models;

namespace Business.Services
{
    public interface ICategoryService : IService<CategoryModel>
    {

    }

    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepoBase _categoryRepo;

        public CategoryService(CategoryRepoBase categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public Result Add(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CategoryModel> Query()
        {
            throw new NotImplementedException();
        }

        public Result Update(CategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
