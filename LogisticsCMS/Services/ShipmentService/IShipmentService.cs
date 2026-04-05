namespace LogisticsCMS.Services.ShipmentService
{
    using LogisticsCMS.Dtos.ShipmentDto;

    public interface IShipmentService
    {
        Task<List<ResultShipmentDto>> GetAllShipmentsAsync();
        Task<GetShipmentByIdDto> GetShipmentByIdAsync(string ShipmentId);
        Task CreateShipmentAsync(CreateShipmentDto createShipmentDto);
        Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto);
        Task DeleteShipmentAsync(string ShipmentId);

        Task<GetShipmentByIdDto> GetShipmentByTrackingNumberAsync(string trackingNumber);
    }
}

