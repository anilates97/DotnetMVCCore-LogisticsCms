using AutoMapper;
using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Dtos.ShipmentTracking;
using LogisticsCMS.Services.Shipment;
using LogisticsCMS.Services.ShipmentTracking;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class ShipmentTrackingController : CrudControllerBase
    {
        private readonly IShipmentTrackingService _trackingService;
        private readonly IShipmentService _shipmentService;
        private readonly IMapper _mapper;

        public ShipmentTrackingController(
            IShipmentTrackingService trackingService,
            IShipmentService shipmentService,
            IMapper mapper
        )
        {
            _trackingService = trackingService;
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string trackingNumber)
        {
            var values = await _trackingService.GetAllTrackingsAsync(trackingNumber);
            ViewBag.TrackingNumber = trackingNumber;
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddTracking(string trackingNumber)
        {
            var shipment = await LoadShipmentSummaryAsync(trackingNumber);

            if (shipment == null)
            {
                return NotFound();
            }

            var dto = new CreateShipmentTrackingDto
            {
                TrackingNumber = trackingNumber,
                EventDate = DateTime.Now,
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddTracking(CreateShipmentTrackingDto createDto)
        {
            if (!ModelState.IsValid)
            {
                await LoadShipmentSummaryAsync(createDto.TrackingNumber);
                return View(createDto);
            }

            await _trackingService.CreateTrackingAsync(createDto);

            TempData["Success"] = "Kargo hareketi başarıyla eklendi!";

            return RedirectToAction("Index", new { trackingNumber = createDto.TrackingNumber });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTracking(string trackingNumber, int index)
        {
            var tracking = await _trackingService.GetTrackingByIndexAsync(trackingNumber, index);

            if (tracking == null)
            {
                return NotFound();
            }

            await LoadShipmentSummaryAsync(trackingNumber);

            var dto = _mapper.Map<UpdateShipmentTrackingDto>(tracking);
            dto.TrackingNumber = trackingNumber;
            dto.TrackingIndex = index;

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTracking(UpdateShipmentTrackingDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                await LoadShipmentSummaryAsync(updateDto.TrackingNumber);
                return View(updateDto);
            }

            await _trackingService.UpdateTrackingAsync(updateDto);

            TempData["Success"] = "Kargo hareketi başarıyla güncellendi!";

            return RedirectToAction("Index", new { trackingNumber = updateDto.TrackingNumber });
        }

        public async Task<IActionResult> DeleteTracking(string trackingNumber, int index)
        {
            await _trackingService.DeleteTrackingAsync(trackingNumber, index);

            TempData["Success"] = "Kargo hareketi başarıyla silindi!";

            return RedirectToAction("Index", new { trackingNumber });
        }

        private async Task<GetShipmentByIdDto?> LoadShipmentSummaryAsync(string trackingNumber)
        {
            var shipment = await _shipmentService.GetShipmentByTrackingNumberAsync(trackingNumber);

            ViewBag.TrackingNumber = trackingNumber;
            ViewBag.SenderName = shipment?.SenderName;
            ViewBag.ReceiverName = shipment?.ReceiverName;
            ViewBag.OriginCity = shipment?.OriginCity;
            ViewBag.DestinationCity = shipment?.DestinationCity;
            ViewBag.CurrentStatus = shipment?.CurrentStatus;
            ViewBag.ExistingTrackings = shipment?.Trackings?.OrderByDescending(x => x.EventDate).ToList();

            return shipment;
        }
    }
}
