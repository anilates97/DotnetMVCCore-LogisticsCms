using LogisticsCMS.Models;
using LogisticsCMS.Services.Shipment;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class TrackingController : Controller
    {
        private readonly IShipmentService _shipmentService;

        public TrackingController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        // GET: /Tracking
        // GET: /Tracking?trackingNumber=TRK-1001ABC
        public async Task<IActionResult> Index(string? trackingNumber)
        {
            if (string.IsNullOrWhiteSpace(trackingNumber))
                return View(null as TrackingResultViewModel);

            var shipment = await _shipmentService.GetShipmentByTrackingNumberAsync(
                trackingNumber.Trim().ToUpper()
            );

            if (shipment is null)
            {
                ViewBag.NotFound = true;
                ViewBag.SearchedNumber = trackingNumber;
                return View(null as TrackingResultViewModel);
            }

            // En yeni event üstte görünsün
            var events = (shipment.Trackings ?? new List<ShipmentTracking>())
                .OrderByDescending(t => t.EventDate)
                .Select(t => new TrackingEventViewModel
                {
                    EventDate = t.EventDate,
                    Location = t.Location,
                    Description = t.Description,
                    TrackingStatus = t.TrackingStatus,
                })
                .ToList();

            var trackingResult = new TrackingResultViewModel
            {
                TrackingNumber = shipment.TrackingNumber,
                SenderName = shipment.SenderName,
                ReceiverName = shipment.ReceiverName,
                OriginCity = shipment.OriginCity,
                OriginDistrict = shipment.OriginDistrict,
                DestinationCity = shipment.DestinationCity,
                DestinationDistrict = shipment.DestinationDistrict,
                Address = shipment.Address,
                CreatedDate = shipment.CreatedDate,
                CurrentStatus = shipment.CurrentStatus,
                Events = events,
            };

            return View(trackingResult);
        }
    }
}
