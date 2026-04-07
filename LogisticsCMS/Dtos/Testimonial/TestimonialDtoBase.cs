using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Dtos.Testimonial
{
    public abstract class TestimonialDtoBase
    {
        [Required(ErrorMessage = "Ad soyad zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Ad soyad 2 ile 100 karakter arasında olmalıdır.")]
        public string NameSurname { get; set; } = null!;

        [Required(ErrorMessage = "Unvan zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Unvan 2 ile 100 karakter arasında olmalıdır.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Görsel adresi zorunludur.")]
        [RegularExpression(@"^(https?://.+|/.+)$", ErrorMessage = "Geçerli bir görsel adresi giriniz.")]
        [StringLength(500, ErrorMessage = "Görsel adresi 500 karakterden uzun olamaz.")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "Yorum detayi zorunludur.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Yorum detayi 10 ile 2000 karakter arasında olmalıdır.")]
        public string ReviewDetails { get; set; } = null!;

        [Range(1, 5, ErrorMessage = "Puan 1 ile 5 arasında olmalıdır.")]
        public int ReviewScore { get; set; }

        public bool Status { get; set; }
    }

    public abstract class TestimonialWithIdDtoBase : TestimonialDtoBase
    {
        public string TestimonialId { get; set; } = null!;
    }
}
