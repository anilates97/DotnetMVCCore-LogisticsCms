namespace LogisticsCMS.Dtos.ShipmentTrackingDto
{
    public class CreateShipmentTrackingDto
    {
        public string TrackingNumber { get; set; } = null!;
        public DateTime EventDate { get; set; } = DateTime.UtcNow;
        public string Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string TrackingStatus { get; set; } = null!;
    }
}

