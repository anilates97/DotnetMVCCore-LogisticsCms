using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Dtos.Offer
{
    public abstract class OfferDtoBase
    {
        [Required(ErrorMessage = "Başlık zorunludur.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 150 karakter arasında olmalıdır.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Açıklama 10 ile 1000 karakter arasında olmalıdır.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Görsel adresi zorunludur.")]
        [RegularExpression(@"^(https?://.+|/.+)$", ErrorMessage = "Geçerli bir görsel adresi giriniz.")]
        [StringLength(500, ErrorMessage = "Görsel adresi 500 karakterden uzun olamaz.")]
        public string ImageUrl { get; set; } = null!;

        public bool IsStatus { get; set; }
    }

    public abstract class OfferWithIdDtoBase : OfferDtoBase
    {
        public string OfferId { get; set; } = null!;
    }
}
