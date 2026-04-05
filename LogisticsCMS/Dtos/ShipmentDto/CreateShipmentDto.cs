namespace LogisticsCMS.Dtos.ShipmentDto
{
    public class CreateShipmentDto
    {
        public string TrackingNumber { get; set; } = null!;
        public string SenderName { get; set; } = null!;
        public string ReceiverName { get; set; } = null!;

        public string OriginCity { get; set; } = null!;

        public string OriginDistrict { get; set; } = null!;

        public string DestinationDistrict { get; set; } = null!;
        public string DestinationCity { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string Address { get; set; } = null!;

        public string CurrentStatus { get; set; } = null!;
    }
}

