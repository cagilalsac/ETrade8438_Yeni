using AppCore.Business.Services.Bases;
using AppCore.Results.Bases;
using Business.Models;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Business.Services
{
    public interface IProductService : IService<ProductModel>
    {
    }

    public class ProductService : IProductService
    {
        private readonly ProductRepoBase _productRepo;

        public ProductService(ProductRepoBase productRepo)
        {
            _productRepo = productRepo;
        }

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
            _productRepo.Dispose();
        }

        public IQueryable<ProductModel> Query()
        {
            // AutoMapper
            return _productRepo.Query().Select(p => new ProductModel()
            {
                CategoryId = p.CategoryId,
                Description = p.Description,
                ExpirationDate = p.ExpirationDate,
                Guid = p.Guid,
                Id = p.Id,
                Name = p.Name,
                StockAmount = p.StockAmount,
                UnitPrice = p.UnitPrice
            });
        }

        public Result Update(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
