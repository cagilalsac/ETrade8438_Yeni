#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business.Models;

namespace MvcWebUI.Controllers
{
    public class ProductsController : Controller
    {
        // Add service injections here
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IStoreService _storeService;

		public ProductsController(IProductService productService, ICategoryService categoryService, IStoreService storeService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_storeService = storeService;
		}

		// GET: Products
		public IActionResult Index()
        {
            List<ProductModel> productList = _productService.Query().ToList(); // TODO: Add get list service logic here
            return View(productList);
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            ProductModel product = _productService.Query().SingleOrDefault(p => p.Id == id); // TODO: Add get item service logic here
            if (product == null)
            {
                //return NotFound();
                return View("_Error", "Product not found!");
            }
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(_categoryService.Query().ToList(), "Id", "Name");
            ViewBag.Stores = new MultiSelectList(_storeService.Query().ToList(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                var result = _productService.Add(product);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(_categoryService.Query().ToList(), "Id", "Name", product.CategoryId);
			ViewBag.Stores = new MultiSelectList(_storeService.Query().ToList(), "Id", "Name", product.StoreIds);
			return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            ProductModel product = _productService.Query().SingleOrDefault(p => p.Id == id); // TODO: Add get item service logic here
            if (product == null)
            {
                //return NotFound();
                return View("_Error", "Product not found!");
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(_categoryService.Query().ToList(), "Id", "Name", product.CategoryId);
			ViewBag.Stores = new MultiSelectList(_storeService.Query().ToList(), "Id", "Name", product.StoreIds);
			return View(product);
        }

        // POST: Products/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                var result = _productService.Update(product);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["CategoryId"] = new SelectList(_categoryService.Query().ToList(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
            ProductModel product = _productService.Query().SingleOrDefault(p => p.Id == id); // TODO: Add get item service logic here
            if (product == null)
            {
                //return NotFound();
                return View("_Error", "Product not found!");
            }
            return View(product);
        }

        // POST: Products/Delete
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
	}
}
