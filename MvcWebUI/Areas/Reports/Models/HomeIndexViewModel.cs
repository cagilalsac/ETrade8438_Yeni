#nullable disable

using Business.Models;

namespace MvcWebUI.Areas.Reports.Models
{
    public class HomeIndexViewModel
    {
        public List<ReportModel> Report { get; set; }
        public ReportFilterModel Filter { get; set; }
    }
}
