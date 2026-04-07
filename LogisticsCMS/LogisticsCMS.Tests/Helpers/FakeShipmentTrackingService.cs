using LogisticsCMS.Dtos.ShipmentTracking;
using LogisticsCMS.Services.ShipmentTracking;

namespace LogisticsCMS.Tests.Helpers;

internal sealed class FakeShipmentTrackingService : IShipmentTrackingService
{
    public List<ResultShipmentTrackingDto> Trackings { get; set; } = [];
    public ResultShipmentTrackingDto? TrackingByIndex { get; set; }
    public CreateShipmentTrackingDto? CreatedTracking { get; private set; }
    public UpdateShipmentTrackingDto? UpdatedTracking { get; private set; }
    public (string trackingNumber, int index)? DeletedTracking { get; private set; }

    public Task CreateTrackingAsync(CreateShipmentTrackingDto createShipmentTrackingDto)
    {
        CreatedTracking = createShipmentTrackingDto;
        return Task.CompletedTask;
    }

    public Task DeleteTrackingAsync(string trackingNumber, int index)
    {
        DeletedTracking = (trackingNumber, index);
        return Task.CompletedTask;
    }

    public Task<List<ResultShipmentTrackingDto>> GetAllTrackingsAsync(string trackingNumber) =>
        Task.FromResult(Trackings);

    public Task<ResultShipmentTrackingDto> GetTrackingByIndexAsync(string trackingNumber, int index) =>
        Task.FromResult(TrackingByIndex!);

    public Task UpdateTrackingAsync(UpdateShipmentTrackingDto updateShipmentTrackingDto)
    {
        UpdatedTracking = updateShipmentTrackingDto;
        return Task.CompletedTask;
    }
}
