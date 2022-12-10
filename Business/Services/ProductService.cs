using AppCore.Business.Services.Bases;
using AppCore.Results;
using AppCore.Results.Bases;
using Business.Models;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Globalization;

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
            //var dbEntity = _productRepo.Query().SingleOrDefault(p => p.Name.ToUpper() == model.Name.ToUpper().Trim());
            //var dbEntity = _productRepo.Query(p => p.Name.ToUpper() == model.Name.ToUpper().Trim()).SingleOrDefault();
            //if (dbEntity is not null)
            //    return new ErrorResult("Product with same name exists!");
            if (_productRepo.Query().Any(p => p.Name.ToUpper() == model.Name.ToUpper().Trim()))
                return new ErrorResult("Product with same name exists!"); // All

            var entity = new Product()
            {
                //CategoryId = model.CategoryId.HasValue ? model.CategoryId.Value : 0,
                //CategoryId = model.CategoryId ?? 0,
                CategoryId = model.CategoryId.Value,
                //Description = (model.Description ?? "").Trim()
                Description = model.Description?.Trim(),
                ExpirationDate = model.ExpirationDate,
                Name = model.Name.Trim(),
                StockAmount = model.StockAmount,
                UnitPrice = model.UnitPrice
            };
            _productRepo.Add(entity);
            return new SuccessResult();
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
            return _productRepo.Query(p => p.Category).Select(p => new ProductModel()
            {
                CategoryId = p.CategoryId,
                Description = p.Description,
                ExpirationDate = p.ExpirationDate,
                Guid = p.Guid,
                Id = p.Id,
                Name = p.Name,
                StockAmount = p.StockAmount,
                UnitPrice = p.UnitPrice,

                UnitPriceDisplay = p.UnitPrice.ToString("C2"),
                ExpirationDateDisplay = p.ExpirationDate.HasValue ? p.ExpirationDate.Value.ToString("yyyy/MM/dd") : "",
                CategoryDisplay = p.Category.Name
            });
        }

        public Result Update(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
