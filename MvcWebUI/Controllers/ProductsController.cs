using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // controller/action/id?
        public IActionResult Index() // ~/Products/Index
        {
            var model = _productService.Query().ToList();

            return View(model);
        }
    }
}
