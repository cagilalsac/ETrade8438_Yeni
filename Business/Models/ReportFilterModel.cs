#nullable disable

using System.ComponentModel;

namespace Business.Models
{
    public class ReportFilterModel
    {
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
    }
}
