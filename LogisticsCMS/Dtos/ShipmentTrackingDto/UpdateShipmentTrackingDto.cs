public class UpdateShipmentTrackingDto
{
    public string TrackingNumber { get; set; } = null!;

    public int TrackingIndex { get; set; }
    public DateTime EventDate { get; set; } = DateTime.UtcNow;
    public string Location { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string TrackingStatus { get; set; } = null!;
}
