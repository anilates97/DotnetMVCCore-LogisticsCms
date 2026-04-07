using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LogisticsCMS.Models
{
    public class Shipment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ShipmentId { get; set; } = null!;
        public string TrackingNumber { get; set; } = null!;
        public string SenderName { get; set; } = null!;
        public string ReceiverName { get; set; } = null!;

        public string OriginCity { get; set; } = null!;
        public string DestinationCity { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string CurrentStatus { get; set; } = null!;

        public string OriginDistrict { get; set; } = null!;
        public string DestinationDistrict { get; set; } = null!;
        public string Address { get; set; } = null!;

        public List<ShipmentTracking> Trackings { get; set; } = new List<ShipmentTracking>();
    }
}
