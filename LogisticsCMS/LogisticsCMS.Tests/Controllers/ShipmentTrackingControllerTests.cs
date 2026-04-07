using AutoMapper;
using LogisticsCMS.Controllers;
using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Dtos.ShipmentTracking;
using LogisticsCMS.Mapping;
using LogisticsCMS.Models;
using LogisticsCMS.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace LogisticsCMS.Tests.Controllers;

public class ShipmentTrackingControllerTests
{
    private readonly IMapper _mapper = new MapperConfiguration(
        cfg => cfg.AddProfile<GeneralMapping>(),
        NullLoggerFactory.Instance
    ).CreateMapper();

    [Fact]
    public async Task AddTracking_Get_Should_Return_NotFound_When_Shipment_Is_Missing()
    {
        var controller = CreateController(new FakeShipmentTrackingService(), new FakeShipmentService());

        var result = await controller.AddTracking("TRK404");

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task AddTracking_Get_Should_Return_View_With_Default_Model_When_Shipment_Exists()
    {
        var controller = CreateController(
            new FakeShipmentTrackingService(),
            CreateShipmentServiceWithSummary()
        );

        var result = await controller.AddTracking("TRK100");

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<CreateShipmentTrackingDto>(viewResult.Model);
        Assert.Equal("TRK100", model.TrackingNumber);
    }

    [Fact]
    public async Task AddTracking_Post_Should_Return_View_When_ModelState_Is_Invalid()
    {
        var controller = CreateController(
            new FakeShipmentTrackingService(),
            CreateShipmentServiceWithSummary()
        );
        controller.ModelState.AddModelError("Location", "Required");

        var dto = new CreateShipmentTrackingDto
        {
            TrackingNumber = "TRK100",
            Location = "Ankara",
            Description = "Dağıtımda",
            TrackingStatus = "Yolda",
        };

        var result = await controller.AddTracking(dto);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Same(dto, viewResult.Model);
    }

    [Fact]
    public async Task AddTracking_Post_Should_Create_And_Redirect_When_Model_Is_Valid()
    {
        var trackingService = new FakeShipmentTrackingService();
        var controller = CreateController(trackingService, CreateShipmentServiceWithSummary());
        var dto = new CreateShipmentTrackingDto
        {
            TrackingNumber = "TRK100",
            Location = "Ankara",
            Description = "Dağıtımda",
            TrackingStatus = "Yolda",
        };

        var result = await controller.AddTracking(dto);

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, trackingService.CreatedTracking);
        Assert.Equal("Index", redirectResult.ActionName);
        Assert.Equal("TRK100", redirectResult.RouteValues?["trackingNumber"]);
    }

    [Fact]
    public async Task UpdateTracking_Get_Should_Return_NotFound_When_Tracking_Is_Missing()
    {
        var trackingService = new FakeShipmentTrackingService { TrackingByIndex = null };
        var controller = CreateController(trackingService, CreateShipmentServiceWithSummary());

        var result = await controller.UpdateTracking("TRK100", 0);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateTracking_Get_Should_Map_Result_To_Update_Model()
    {
        var trackingService = new FakeShipmentTrackingService
        {
            TrackingByIndex = new ResultShipmentTrackingDto
            {
                EventDate = new DateTime(2026, 4, 6),
                Location = "Ankara",
                Description = "Teslim edildi",
                TrackingStatus = "Teslim Edildi",
            },
        };
        var controller = CreateController(trackingService, CreateShipmentServiceWithSummary());

        var result = await controller.UpdateTracking("TRK100", 2);

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<UpdateShipmentTrackingDto>(viewResult.Model);
        Assert.Equal("TRK100", model.TrackingNumber);
        Assert.Equal(2, model.TrackingIndex);
        Assert.Equal("Ankara", model.Location);
    }

    [Fact]
    public async Task DeleteTracking_Should_Delete_And_Redirect()
    {
        var trackingService = new FakeShipmentTrackingService();
        var controller = CreateController(trackingService, CreateShipmentServiceWithSummary());

        var result = await controller.DeleteTracking("TRK100", 1);

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal(("TRK100", 1), trackingService.DeletedTracking);
        Assert.Equal("Index", redirectResult.ActionName);
    }

    private ShipmentTrackingController CreateController(
        FakeShipmentTrackingService trackingService,
        FakeShipmentService shipmentService
    ) =>
        TestControllerFactory.CreateWithHttpContext(
            new ShipmentTrackingController(trackingService, shipmentService, _mapper)
        );

    private static FakeShipmentService CreateShipmentServiceWithSummary() =>
        new()
        {
            ShipmentByTrackingNumber = new GetShipmentByIdDto
            {
                ShipmentId = "shipment-1",
                TrackingNumber = "TRK100",
                SenderName = "Ali",
                ReceiverName = "Ayse",
                OriginCity = "Istanbul",
                DestinationCity = "Ankara",
                CurrentStatus = "Yolda",
                Trackings =
                [
                    new ShipmentTracking
                    {
                        EventDate = new DateTime(2026, 4, 5),
                        Location = "Eskisehir",
                        Description = "Yolda",
                        TrackingStatus = "Yolda",
                    },
                ],
            },
        };
}
