using LogisticsCMS.Controllers;
using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Models;
using LogisticsCMS.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Tests.Controllers;

public class TrackingControllerTests
{
    [Fact]
    public async Task Index_Should_Return_Empty_View_When_Tracking_Number_Is_Missing()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(
            new TrackingController(new FakeShipmentService())
        );

        var result = await controller.Index(null);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Null(viewResult.Model);
    }

    [Fact]
    public async Task Index_Should_Set_NotFound_When_Shipment_Does_Not_Exist()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(
            new TrackingController(new FakeShipmentService())
        );

        var result = await controller.Index("TRK404");

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Null(viewResult.Model);
        Assert.True((bool)controller.ViewBag.NotFound);
        Assert.Equal("TRK404", (string)controller.ViewBag.SearchedNumber);
    }

    [Fact]
    public async Task Index_Should_Map_And_Sort_Tracking_Events()
    {
        var shipmentService = new FakeShipmentService
        {
            ShipmentByTrackingNumber = new GetShipmentByIdDto
            {
                ShipmentId = "1",
                TrackingNumber = "TRK1",
                SenderName = "Ali",
                ReceiverName = "Ayse",
                OriginCity = "Istanbul",
                OriginDistrict = "Kadikoy",
                DestinationCity = "Ankara",
                DestinationDistrict = "Cankaya",
                Address = "Test adresi 12345",
                CurrentStatus = "Yolda",
                Trackings =
                [
                    new ShipmentTracking
                    {
                        EventDate = new DateTime(2026, 4, 1),
                        Location = "Ankara",
                        Description = "Eski olay",
                        TrackingStatus = "Transfer Merkezinde",
                    },
                    new ShipmentTracking
                    {
                        EventDate = new DateTime(2026, 4, 2),
                        Location = "Eskisehir",
                        Description = "Yeni olay",
                        TrackingStatus = "Yolda",
                    },
                ],
            },
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new TrackingController(shipmentService)
        );

        var result = await controller.Index("trk1");

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<TrackingResultViewModel>(viewResult.Model);
        Assert.Equal("TRK1", model.TrackingNumber);
        Assert.Equal(2, model.Events.Count);
        Assert.Equal("Eskisehir", model.Events[0].Location);
        Assert.Equal("Ankara", model.Events[1].Location);
    }
}
