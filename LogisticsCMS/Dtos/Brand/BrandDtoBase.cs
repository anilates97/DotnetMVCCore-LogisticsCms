using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Dtos.Brand
{
    public abstract class BrandDtoBase
    {
        [Required(ErrorMessage = "Marka adı zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Marka adı 2 ile 100 karakter arasında olmalıdır.")]
        public string BrandName { get; set; } = null!;

        [Required(ErrorMessage = "Logo adresi zorunludur.")]
        [RegularExpression(@"^(https?://.+|/.+)$", ErrorMessage = "Geçerli bir logo adresi giriniz.")]
        [StringLength(500, ErrorMessage = "Logo adresi 500 karakterden uzun olamaz.")]
        public string ImageUrl { get; set; } = null!;

        public bool IsStatus { get; set; }
    }

    public abstract class BrandWithIdDtoBase : BrandDtoBase
    {
        public string BrandId { get; set; } = null!;
    }
}
