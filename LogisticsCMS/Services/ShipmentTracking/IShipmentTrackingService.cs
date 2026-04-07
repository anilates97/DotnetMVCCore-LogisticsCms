using LogisticsCMS.Dtos.ShipmentTracking;

namespace LogisticsCMS.Services.ShipmentTracking
{
    public interface IShipmentTrackingService
    {
        Task<List<ResultShipmentTrackingDto>> GetAllTrackingsAsync(string trackingNumber);

        Task CreateTrackingAsync(CreateShipmentTrackingDto createShipmentTrackingDto);

        Task UpdateTrackingAsync(UpdateShipmentTrackingDto updateShipmentTrackingDto);

        Task DeleteTrackingAsync(string trackingNumber, int index);

        Task<ResultShipmentTrackingDto> GetTrackingByIndexAsync(string trackingNumber, int index);
    }
}



