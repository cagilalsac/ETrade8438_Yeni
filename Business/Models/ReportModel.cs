#nullable disable

using System.ComponentModel;

namespace Business.Models
{
    public class ReportModel
    {
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Unit Price")]
        public string UnitPrice { get; set; }

        [DisplayName("Stock Amount")]
        public string StockAmount { get; set; }

        [DisplayName("Expiration Date")]
        public string ExpirationDate { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [DisplayName("Store")]
        public string StoreName { get; set; }

        [DisplayName("Virtual")]
        public string Virtual { get; set; }
    }
}
