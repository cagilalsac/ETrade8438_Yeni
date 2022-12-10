using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var categories = _categoryService.Query().ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost] // Action method selector
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.Add(model);

            }
            return View();
        }
    }
}
