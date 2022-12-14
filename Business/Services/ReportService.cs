using Business.Models;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace Business.Services
{
    public interface IReportService
    {
        List<ReportModel> GetListInnerJoin(ReportFilterModel filter);
    }

    /*
    select p.Name [Product Name],
    p.UnitPrice [Unit Price],
    cast(p.StockAmount as varchar)  + ' adet' [Stock Amount],
    p.expirationdate [Expiration Date],
    c.name [Category Name],
    s.Name [Store Name],
    case when IsVirtual = 1 then 'Virtual' else 'Real' end as Virtual
    from products p inner join categories c
    on p.CategoryId = c.Id
    inner join ProductStores ps
    on ps.ProductId = p.Id
    inner join Stores s
    on ps.StoreId = s.Id
    order by c.Name, p.Name
    */
    public class ReportService : IReportService
    {
        private readonly ProductRepoBase _productRepo;

        public ReportService(ProductRepoBase productRepo)
        {
            _productRepo = productRepo;
        }

        public List<ReportModel> GetListInnerJoin(ReportFilterModel filter)
        {
            var productQuery = _productRepo.Query();
            var categoryQuery = _productRepo.Query<Category>();
            var storeQuery = _productRepo.Query<Store>();
            var productStoreQuery = _productRepo.Query<ProductStore>();
            var query = from product in productQuery
                        join category in categoryQuery
                        on product.CategoryId equals category.Id
                        join productStore in productStoreQuery
                        on product.Id equals productStore.ProductId
                        join store in storeQuery
                        on productStore.StoreId equals store.Id
                        //where product.Name == "HP"
                        //orderby category.Name
                        select new ReportModel()
                        {
                            // Display
                            CategoryName = category.Name,
                            ExpirationDate = product.ExpirationDate.HasValue ? product.ExpirationDate.Value.ToString("MM/dd/yyyy") : "",
                            ProductName = product.Name,
                            StockAmount = product.StockAmount + " units",
                            StoreName = store.Name,
                            UnitPrice = product.UnitPrice.ToString("C2"),
                            Virtual = store.IsVirtual ? "Yes" : "No",

                            // Filter
                            CategoryId = category.Id,
                            UnitPriceValue = product.UnitPrice
                        };
            query = query.OrderBy(q => q.CategoryName).ThenBy(q => q.ProductName);
            if (filter is not null)
            {
                if (!string.IsNullOrWhiteSpace(filter.ProductName))
                {
                    query = query.Where(q => q.ProductName.ToUpper().Contains(filter.ProductName.ToUpper().Trim()));
                }
                if (filter.CategoryId.HasValue)
                {
                    query = query.Where(q => q.CategoryId == filter.CategoryId.Value);
                }
                if (filter.UnitPriceBegin.HasValue)
                {
                    query = query.Where(q => q.UnitPriceValue >= filter.UnitPriceBegin);
                }
                if (filter.UnitPriceEnd.HasValue)
                {
                    query = query.Where(q => q.UnitPriceValue <= filter.UnitPriceEnd);
                }
            }
            return query.ToList();
        }

        //public List<ReportModel> GetListLeftJoin()
        //{

        //}
    }
}
