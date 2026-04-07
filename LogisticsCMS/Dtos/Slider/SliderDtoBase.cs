using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Dtos.Slider
{
    public abstract class SliderDtoBase
    {
        [Required(ErrorMessage = "Başlık zorunludur.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 150 karakter arasında olmalıdır.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Alt başlık zorunludur.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Alt başlık 3 ile 200 karakter arasında olmalıdır.")]
        public string SubTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Açıklama 10 ile 1000 karakter arasında olmalıdır.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Görsel adresi zorunludur.")]
        [RegularExpression(@"^(https?://.+|/.+)$", ErrorMessage = "Geçerli bir görsel adresi giriniz.")]
        [StringLength(500, ErrorMessage = "Görsel adresi 500 karakterden uzun olamaz.")]
        public string ImageUrl { get; set; } = string.Empty;
    }

    public abstract class SliderWithIdDtoBase : SliderDtoBase
    {
        public string SliderId { get; set; } = string.Empty;
    }
}
