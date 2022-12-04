#nullable disable

using AppCore.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    // MVC Fluent Validation
    public class ProductModel : RecordBase
    {
        #region Entity Özellikleri
        [Required]
        [StringLength(200)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [DisplayName("Unit Price")]
        public double UnitPrice { get; set; }

        [DisplayName("Stock Amount")]
        public int StockAmount { get; set; }

        [DisplayName("Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [Required]
        [DisplayName("Category")]
        public int? CategoryId { get; set; }
        #endregion

        #region Sayfanın İhtiyacı Olan Özellikler
        [DisplayName("Unit Price")]
        public string UnitPriceDisplay { get; set; }

        [DisplayName("Expiration Date")]
        public string ExpirationDateDisplay { get; set; }

        [DisplayName("Category")]
        public string CategoryDisplay { get; set; }
        #endregion
    }
}
