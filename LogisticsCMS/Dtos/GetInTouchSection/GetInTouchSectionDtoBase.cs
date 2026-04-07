using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Dtos.GetInTouchSection
{
    public abstract class GetInTouchSectionDtoBase
    {
        [Required(ErrorMessage = "Ana başlık zorunludur.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Ana başlık 3 ile 150 karakter arasında olmalıdır.")]
        public string MainTitle { get; set; } = null!;

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Açıklama 10 ile 2000 karakter arasında olmalıdır.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Birinci ozellik basligi zorunludur.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Birinci ozellik basligi 2 ile 150 karakter arasında olmalıdır.")]
        public string Feature1Title { get; set; } = null!;

        [Required(ErrorMessage = "Birinci ozellik açıklamasi zorunludur.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Birinci ozellik açıklamasi 5 ile 500 karakter arasında olmalıdır.")]
        public string Feature1Description { get; set; } = null!;

        [Required(ErrorMessage = "Ikinci ozellik basligi zorunludur.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Ikinci ozellik basligi 2 ile 150 karakter arasında olmalıdır.")]
        public string Feature2Title { get; set; } = null!;

        [Required(ErrorMessage = "Ikinci ozellik açıklamasi zorunludur.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Ikinci ozellik açıklamasi 5 ile 500 karakter arasında olmalıdır.")]
        public string Feature2Description { get; set; } = null!;

        [Required(ErrorMessage = "Görsel adresi zorunludur.")]
        [RegularExpression(@"^(https?://.+|/.+)$", ErrorMessage = "Geçerli bir görsel adresi giriniz.")]
        [StringLength(500, ErrorMessage = "Görsel adresi 500 karakterden uzun olamaz.")]
        public string ImageUrl { get; set; } = null!;

        public bool Status { get; set; }
    }

    public abstract class GetInTouchSectionWithIdDtoBase : GetInTouchSectionDtoBase
    {
        public string GetInTouchSectionId { get; set; } = null!;
    }
}
