using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Dtos.Shipment
{
    public abstract class ShipmentDtoBase : IValidatableObject
    {
        [Required(ErrorMessage = "Takip numarası zorunludur.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Takip numarası 4 ile 50 karakter arasında olmalıdır.")]
        public string TrackingNumber { get; set; } = null!;

        [Required(ErrorMessage = "Gönderici adı zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Gönderici adı 2 ile 100 karakter arasında olmalıdır.")]
        public string SenderName { get; set; } = null!;

        [Required(ErrorMessage = "Alıcı adı zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Alıcı adı 2 ile 100 karakter arasında olmalıdır.")]
        public string ReceiverName { get; set; } = null!;

        [Required(ErrorMessage = "Çıkış şehri zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Çıkış şehri 2 ile 100 karakter arasında olmalıdır.")]
        public string OriginCity { get; set; } = null!;

        [Required(ErrorMessage = "Çıkış ilçesi zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Çıkış ilçesi 2 ile 100 karakter arasında olmalıdır.")]
        public string OriginDistrict { get; set; } = null!;

        [Required(ErrorMessage = "Varış ilçesi zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Varış ilçesi 2 ile 100 karakter arasında olmalıdır.")]
        public string DestinationDistrict { get; set; } = null!;

        [Required(ErrorMessage = "Varış şehri zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Varış şehri 2 ile 100 karakter arasında olmalıdır.")]
        public string DestinationCity { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Adres zorunludur.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Adres 10 ile 500 karakter arasında olmalıdır.")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Durum zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Durum 2 ile 100 karakter arasında olmalıdır.")]
        public string CurrentStatus { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (
                !string.IsNullOrWhiteSpace(OriginCity)
                && !string.IsNullOrWhiteSpace(OriginDistrict)
                && !string.IsNullOrWhiteSpace(DestinationCity)
                && !string.IsNullOrWhiteSpace(DestinationDistrict)
                && string.Equals(OriginCity, DestinationCity, StringComparison.OrdinalIgnoreCase)
                && string.Equals(
                    OriginDistrict,
                    DestinationDistrict,
                    StringComparison.OrdinalIgnoreCase
                )
            )
            {
                yield return new ValidationResult(
                    "Çıkış ve varış lokasyonu aynı olamaz.",
                    new[]
                    {
                        nameof(OriginCity),
                        nameof(OriginDistrict),
                        nameof(DestinationCity),
                        nameof(DestinationDistrict),
                    }
                );
            }
        }
    }

    public abstract class ShipmentWithIdDtoBase : ShipmentDtoBase
    {
        public string ShipmentId { get; set; } = null!;
    }
}
