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
        [Required(ErrorMessage = "{0} is required!")]
        //[StringLength(200, ErrorMessage = "{0} must be maximum {1} characters!")]
        [MinLength(3, ErrorMessage = "{0} must be minimum {1} characters!")]
        [MaxLength(200, ErrorMessage = "{0} must be maximum {1} characters!")]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [DisplayName("Unit Price")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} must be betwwen {1} and {2}!")]
        [Required(ErrorMessage = "{0} is required!")]
        public double? UnitPrice { get; set; }

        [DisplayName("Stock Amount")]
        [Range(0, 1000, ErrorMessage = "{0} must be betwwen {1} and {2}!")]
        [Required(ErrorMessage = "{0} is required!")]
        public int? StockAmount { get; set; }

        [DisplayName("Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [Required]
        [DisplayName("Category")]
        public int? CategoryId { get; set; } // DropDownList
        #endregion

        #region Sayfanın İhtiyacı Olan Özellikler
        [DisplayName("Unit Price")]
        public string UnitPriceDisplay { get; set; }

        [DisplayName("Expiration Date")]
        public string ExpirationDateDisplay { get; set; }

        [DisplayName("Category")]
        public string CategoryDisplay { get; set; }

        [DisplayName("Stores")]
        public string StoresDisplay { get; set; }

        [DisplayName("Stores")]
        public List<int> StoreIds { get; set; } // ListBox
        #endregion
    }
}
