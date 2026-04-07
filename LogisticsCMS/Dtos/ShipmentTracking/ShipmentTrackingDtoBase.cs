using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Dtos.ShipmentTracking
{
    public abstract class ShipmentTrackingDtoBase
    {
        public DateTime EventDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Konum zorunludur.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Konum 2 ile 150 karakter arasında olmalıdır.")]
        public string Location { get; set; } = null!;

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Açıklama 5 ile 1000 karakter arasında olmalıdır.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Durum zorunludur.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Durum 2 ile 100 karakter arasında olmalıdır.")]
        public string TrackingStatus { get; set; } = null!;
    }

    public abstract class ShipmentTrackingWithNumberDtoBase : ShipmentTrackingDtoBase
    {
        [Required(ErrorMessage = "Takip numarası zorunludur.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Takip numarası 4 ile 50 karakter arasında olmalıdır.")]
        public string TrackingNumber { get; set; } = null!;
    }
}
