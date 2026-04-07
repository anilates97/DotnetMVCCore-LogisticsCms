using ShipmentTrackingModel = LogisticsCMS.Models.ShipmentTracking;

namespace LogisticsCMS.Dtos.Shipment
{
    public class GetShipmentByIdDto : ShipmentWithIdDtoBase
    {
        public List<ShipmentTrackingModel>? Trackings { get; set; }
    }
}
