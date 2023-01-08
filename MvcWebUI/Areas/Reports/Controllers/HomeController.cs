using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcWebUI.Areas.Reports.Models;

namespace MvcWebUI.Areas.Reports.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Reports")] // Reports
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        private readonly ICategoryService _categoryService;

        public HomeController(IReportService reportService, ICategoryService categoryService)
        {
            _reportService = reportService;
            _categoryService = categoryService;
        }

        public IActionResult Index(HomeIndexViewModel viewModel)
        {
            viewModel.Report = _reportService.GetListInnerJoin(viewModel.Filter);
            viewModel.Categories = new SelectList(_categoryService.Query().ToList(), "Id", "Name");
            return View(viewModel);
        }
    }
}
