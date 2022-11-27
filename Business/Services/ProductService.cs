using AppCore.Business.Services.Bases;
using AppCore.Results.Bases;
using Business.Models;

namespace Business.Services
{
    public interface IProductService : IService<ProductModel>
    {
    }

    public class ProductService : IProductService
    {
        public Result Add(ProductModel model)
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

        public IQueryable<ProductModel> Query()
        {
            throw new NotImplementedException();
        }

        public Result Update(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
