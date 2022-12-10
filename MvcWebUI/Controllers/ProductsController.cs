using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // controller/action/id?
        public IActionResult Index() // ~/Products/Index
        {
            var model = _productService.Query().ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Action method selector
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel model)
        {
            return View();
        }
    }
}
