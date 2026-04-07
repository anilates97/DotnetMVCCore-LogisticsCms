using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Dtos.ShipmentTracking;
using LogisticsCMS.Services.Shipment;
using LogisticsCMS.Services.ShipmentTracking;

namespace LogisticsCMS.Tests.Integration;

public class ShipmentServicesIntegrationTests : IClassFixture<MongoIntegrationFixture>
{
    private readonly MongoIntegrationFixture _fixture;

    public ShipmentServicesIntegrationTests(MongoIntegrationFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ShipmentService_Should_Create_And_Read_Shipment()
    {
        var (settings, context, mapper) = _fixture.CreateScope();
        var service = new ShipmentService(settings, mapper, context);

        await service.CreateShipmentAsync(CreateShipmentDto("TRK-INT-001", "Yolda", "Ankara"));

        var shipments = await service.GetAllShipmentsAsync();
        var created = Assert.Single(shipments);
        var byId = await service.GetShipmentByIdAsync(created.ShipmentId);
        var byTracking = await service.GetShipmentByTrackingNumberAsync("TRK-INT-001");

        Assert.NotNull(byId);
        Assert.NotNull(byTracking);
        Assert.Equal("TRK-INT-001", byId!.TrackingNumber);
        Assert.Equal("Ankara", byTracking!.DestinationCity);
    }

    [Fact]
    public async Task ShipmentService_Should_Update_And_Delete_Shipment()
    {
        var (settings, context, mapper) = _fixture.CreateScope();
        var service = new ShipmentService(settings, mapper, context);

        await service.CreateShipmentAsync(CreateShipmentDto("TRK-INT-002", "Yolda", "Izmir"));
        var created = Assert.Single(await service.GetAllShipmentsAsync());

        await service.UpdateShipmentAsync(
            new UpdateShipmentDto
            {
                ShipmentId = created.ShipmentId,
                TrackingNumber = "TRK-INT-002",
                SenderName = "Ali Veli",
                ReceiverName = "Ayse Yilmaz",
                OriginCity = "Istanbul",
                OriginDistrict = "Kadikoy",
                DestinationCity = "Bursa",
                DestinationDistrict = "Nilufer",
                Address = "Guncel adres 12345",
                CurrentStatus = "Teslim Edildi",
                CreatedDate = created.CreatedDate,
            }
        );

        var updated = await service.GetShipmentByIdAsync(created.ShipmentId);
        Assert.NotNull(updated);
        Assert.Equal("Bursa", updated!.DestinationCity);
        Assert.Equal("Teslim Edildi", updated.CurrentStatus);

        await service.DeleteShipmentAsync(created.ShipmentId);
        var shipments = await service.GetAllShipmentsAsync();
        Assert.Empty(shipments);
    }

    [Fact]
    public async Task ShipmentService_Should_Return_Correct_Counts()
    {
        var (settings, context, mapper) = _fixture.CreateScope();
        var service = new ShipmentService(settings, mapper, context);

        await service.CreateShipmentAsync(CreateShipmentDto("TRK-INT-003", "Teslim Edildi", "Ankara"));
        await service.CreateShipmentAsync(
            CreateShipmentDto("TRK-INT-004", "Da\u011f\u0131t\u0131mda", "Izmir")
        );
        await service.CreateShipmentAsync(CreateShipmentDto("TRK-INT-005", "Yolda", "Izmir"));

        Assert.Equal(3, await service.GetTotalShipmentCountAsync());
        Assert.Equal(1, await service.GetDeliveredShipmentCountAsync());
        Assert.Equal(1, await service.GetInDistributionShipmentCountAsync());
        Assert.Equal(2, await service.GetDistinctDestinationCityCountAsync());
    }

    [Fact]
    public async Task ShipmentTrackingService_Should_Add_Tracking_And_Update_Current_Status()
    {
        var (settings, context, mapper) = _fixture.CreateScope();
        var shipmentService = new ShipmentService(settings, mapper, context);
        var trackingService = new ShipmentTrackingService(settings, mapper, context);

        await shipmentService.CreateShipmentAsync(CreateShipmentDto("TRK-INT-006", "Yolda", "Ankara"));

        await trackingService.CreateTrackingAsync(
            new CreateShipmentTrackingDto
            {
                TrackingNumber = "TRK-INT-006",
                EventDate = new DateTime(2026, 4, 6, 10, 0, 0),
                Location = "Ankara Transfer Merkezi",
                Description = "Kargo transfer merkezine ulaşti.",
                TrackingStatus = "Transfer Merkezinde",
            }
        );

        var shipment = await shipmentService.GetShipmentByTrackingNumberAsync("TRK-INT-006");
        var trackings = await trackingService.GetAllTrackingsAsync("TRK-INT-006");

        Assert.NotNull(shipment);
        Assert.Equal("Transfer Merkezinde", shipment!.CurrentStatus);
        Assert.Single(trackings);
        Assert.Equal("Ankara Transfer Merkezi", trackings[0].Location);
    }

    [Fact]
    public async Task ShipmentTrackingService_Should_Update_Existing_Tracking()
    {
        var (settings, context, mapper) = _fixture.CreateScope();
        var shipmentService = new ShipmentService(settings, mapper, context);
        var trackingService = new ShipmentTrackingService(settings, mapper, context);

        await shipmentService.CreateShipmentAsync(CreateShipmentDto("TRK-INT-007", "Yolda", "Ankara"));
        await trackingService.CreateTrackingAsync(
            new CreateShipmentTrackingDto
            {
                TrackingNumber = "TRK-INT-007",
                EventDate = new DateTime(2026, 4, 6, 10, 0, 0),
                Location = "Eskisehir",
                Description = "Ilk durum kaydi.",
                TrackingStatus = "Yolda",
            }
        );

        await trackingService.UpdateTrackingAsync(
            new UpdateShipmentTrackingDto
            {
                TrackingNumber = "TRK-INT-007",
                TrackingIndex = 0,
                EventDate = new DateTime(2026, 4, 6, 14, 30, 0),
                Location = "Ankara",
                Description = "Kargo dagitim subesine sevk edildi.",
                TrackingStatus = "Da\u011f\u0131t\u0131mda",
            }
        );

        var updated = await trackingService.GetTrackingByIndexAsync("TRK-INT-007", 0);
        var shipment = await shipmentService.GetShipmentByTrackingNumberAsync("TRK-INT-007");

        Assert.Equal("Ankara", updated.Location);
        Assert.Equal("Da\u011f\u0131t\u0131mda", updated.TrackingStatus);
        Assert.Equal("Da\u011f\u0131t\u0131mda", shipment!.CurrentStatus);
    }

    [Fact]
    public async Task ShipmentTrackingService_Should_Delete_Tracking()
    {
        var (settings, context, mapper) = _fixture.CreateScope();
        var shipmentService = new ShipmentService(settings, mapper, context);
        var trackingService = new ShipmentTrackingService(settings, mapper, context);

        await shipmentService.CreateShipmentAsync(CreateShipmentDto("TRK-INT-008", "Yolda", "Ankara"));
        await trackingService.CreateTrackingAsync(
            new CreateShipmentTrackingDto
            {
                TrackingNumber = "TRK-INT-008",
                EventDate = new DateTime(2026, 4, 6, 10, 0, 0),
                Location = "Istanbul",
                Description = "Kargo yola çıktı.",
                TrackingStatus = "Yolda",
            }
        );

        await trackingService.DeleteTrackingAsync("TRK-INT-008", 0);

        var trackings = await trackingService.GetAllTrackingsAsync("TRK-INT-008");
        Assert.Empty(trackings);
    }

    private static CreateShipmentDto CreateShipmentDto(
        string trackingNumber,
        string currentStatus,
        string destinationCity
    ) =>
        new()
        {
            TrackingNumber = trackingNumber,
            SenderName = "Ali Veli",
            ReceiverName = "Ayse Yilmaz",
            OriginCity = "Istanbul",
            OriginDistrict = "Kadikoy",
            DestinationCity = destinationCity,
            DestinationDistrict = "Merkez",
            Address = "Ornek Mahallesi Test Sokak No 10 Daire 5",
            CurrentStatus = currentStatus,
            CreatedDate = new DateTime(2026, 4, 6),
        };
}
