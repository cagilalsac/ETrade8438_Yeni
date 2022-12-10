using AppCore.Business.Services.Bases;
using AppCore.Results.Bases;
using Business.Models;
using DataAccess.Repositories;

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
            _categoryRepo.Dispose();
        }

        public IQueryable<CategoryModel> Query()
        {
            return _categoryRepo.Query().OrderBy(c => c.Name).Select(c => new CategoryModel()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Guid = c.Guid,

                // CategoryNameDescriptionDisplay = c.Name + " (" + c.Description + ")"
            });
        }

        public Result Update(CategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
