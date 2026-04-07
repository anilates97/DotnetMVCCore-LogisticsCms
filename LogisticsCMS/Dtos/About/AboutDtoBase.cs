using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Dtos.About
{
    public abstract class AboutDtoBase
    {
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 150 karakter arasında olmalıdır.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Açıklama 10 ile 2000 karakter arasında olmalıdır.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Görsel adresi zorunludur.")]
        [RegularExpression(@"^(https?://.+|/.+)$", ErrorMessage = "Geçerli bir görsel adresi giriniz.")]
        [StringLength(500, ErrorMessage = "Görsel adresi 500 karakterden uzun olamaz.")]
        public string ImageUrl { get; set; } = null!;
    }

    public abstract class AboutWithIdDtoBase : AboutDtoBase
    {
        public string AboutId { get; set; } = null!;
    }
}
