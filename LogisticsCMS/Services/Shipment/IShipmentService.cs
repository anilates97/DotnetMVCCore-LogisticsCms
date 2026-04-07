using LogisticsCMS.Dtos.Shipment;

namespace LogisticsCMS.Services.Shipment
{
    public interface IShipmentService
        : ICrudService<CreateShipmentDto, UpdateShipmentDto, ResultShipmentDto, GetShipmentByIdDto>
    {
        Task<List<ResultShipmentDto>> GetAllShipmentsAsync();
        Task<GetShipmentByIdDto?> GetShipmentByIdAsync(string shipmentId);
        Task CreateShipmentAsync(CreateShipmentDto createShipmentDto);
        Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto);
        Task DeleteShipmentAsync(string shipmentId);

        Task<GetShipmentByIdDto?> GetShipmentByTrackingNumberAsync(string trackingNumber);
        Task<long> GetTotalShipmentCountAsync();
        Task<long> GetDeliveredShipmentCountAsync();
        Task<int> GetDistinctDestinationCityCountAsync();
        Task<long> GetInDistributionShipmentCountAsync();
    }
}
