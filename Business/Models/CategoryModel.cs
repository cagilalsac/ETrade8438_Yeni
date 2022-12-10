#nullable disable

using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class CategoryModel : RecordBase
    {
        #region Entity Özellikleri
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }
        #endregion
    }
}
