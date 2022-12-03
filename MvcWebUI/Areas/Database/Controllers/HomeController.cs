using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MvcWebUI.Areas.Database.Controllers
{
    [Area("Db")]
    public class HomeController : Controller
    {
        private readonly ETradeContext _db;

        public HomeController(ETradeContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            _db.Categories.Add(new Category()
            {
                 Name = "Computer",
                 Description = "Computer Types",
                 Products = new List<Product>()
                 {
                     new Product()
                     {
                         Name = "Laptop",
                         UnitPrice = 3000.5,
                         StockAmount = 10,
                         ExpirationDate = DateTime.Parse("03.12.2022", new CultureInfo("tr-TR"))
                     }

                 }
            });
            _db.SaveChanges();
            return Content("<label style=\"color:red\";><b>Database seed successful.</b></label>");
        }
    }
}
