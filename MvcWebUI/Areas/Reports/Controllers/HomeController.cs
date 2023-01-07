using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Areas.Reports.Models;

namespace MvcWebUI.Areas.Reports.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Reports")] // Reports
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;

        public HomeController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
                Report = _reportService.GetListInnerJoin()
            };
            return View(viewModel);
        }
    }
}
