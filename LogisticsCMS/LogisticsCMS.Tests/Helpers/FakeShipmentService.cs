using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Services.Shipment;

namespace LogisticsCMS.Tests.Helpers;

internal sealed class FakeShipmentService : IShipmentService
{
    public List<ResultShipmentDto> Shipments { get; set; } = [];
    public GetShipmentByIdDto? ShipmentById { get; set; }
    public GetShipmentByIdDto? ShipmentByTrackingNumber { get; set; }
    public CreateShipmentDto? CreatedShipment { get; private set; }
    public UpdateShipmentDto? UpdatedShipment { get; private set; }
    public string? DeletedShipmentId { get; private set; }
    public Exception? ExceptionOnCreate { get; set; }
    public Exception? ExceptionOnUpdate { get; set; }
    public Exception? ExceptionOnDelete { get; set; }
    public Exception? ExceptionOnGetById { get; set; }

    public Task CreateAsync(CreateShipmentDto createDto) => throw new NotImplementedException();
    public Task CreateShipmentAsync(CreateShipmentDto createShipmentDto)
    {
        if (ExceptionOnCreate is not null)
        {
            throw ExceptionOnCreate;
        }
        CreatedShipment = createShipmentDto;
        return Task.CompletedTask;
    }
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    public Task DeleteShipmentAsync(string shipmentId)
    {
        if (ExceptionOnDelete is not null)
        {
            throw ExceptionOnDelete;
        }
        DeletedShipmentId = shipmentId;
        return Task.CompletedTask;
    }
    public Task<int> GetDistinctDestinationCityCountAsync() => throw new NotImplementedException();
    public Task<long> GetDeliveredShipmentCountAsync() => throw new NotImplementedException();
    public Task<List<ResultShipmentDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<List<ResultShipmentDto>> GetAllShipmentsAsync() => Task.FromResult(Shipments);
    public Task<GetShipmentByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();
    public Task<long> GetInDistributionShipmentCountAsync() => throw new NotImplementedException();
    public Task<GetShipmentByIdDto?> GetShipmentByIdAsync(string shipmentId)
    {
        if (ExceptionOnGetById is not null)
        {
            throw ExceptionOnGetById;
        }
        return Task.FromResult(ShipmentById);
    }
    public Task<GetShipmentByIdDto?> GetShipmentByTrackingNumberAsync(string trackingNumber) =>
        Task.FromResult(ShipmentByTrackingNumber);

    public Task<long> GetTotalShipmentCountAsync() => throw new NotImplementedException();
    public Task UpdateAsync(UpdateShipmentDto updateDto) => throw new NotImplementedException();
    public Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto)
    {
        if (ExceptionOnUpdate is not null)
        {
            throw ExceptionOnUpdate;
        }
        UpdatedShipment = updateShipmentDto;
        return Task.CompletedTask;
    }
}
