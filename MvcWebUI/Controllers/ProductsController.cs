using AppCore.Results.Bases;
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
                Result result = _productService.Add(model);
                if (result.IsSuccessful) // success result
                {
                    //return RedirectToAction("Index", "Products");
                    return RedirectToAction(nameof(Index));

                    //return Redirect("https://google.com");
                }
                // error result
                //ViewData["Message"] = result.Message;
                ModelState.AddModelError("", result.Message);
            }
            //ViewBag.Categories = new SelectList(_categoryService.Query().ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_categoryService.Query().ToList(), "Id", "Name", model.CategoryId);
            return View(model);
        }
    }
}
