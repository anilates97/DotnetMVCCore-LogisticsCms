using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Dtos.ShipmentDto;
using LogisticsCMS.Services.ShipmentService;

namespace LogisticsCMS.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public async Task<IActionResult> ShipmentList()
        {
            var shipments = await _shipmentService.GetAllShipmentsAsync();
            return View(shipments);
        }

        [HttpGet]
        public IActionResult CreateShipment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShipment(CreateShipmentDto createShipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createShipmentDto);
            }
            await _shipmentService.CreateShipmentAsync(createShipmentDto);
            return RedirectToAction("ShipmentList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateShipment(string id)
        {
            var shipment = await _shipmentService.GetShipmentByIdAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }
            var newShipment = new UpdateShipmentDto
            {
                ShipmentId = shipment.ShipmentId,
                TrackingNumber = shipment.TrackingNumber,
                SenderName = shipment.SenderName,
                ReceiverName = shipment.ReceiverName,
                OriginCity = shipment.OriginCity,
                DestinationCity = shipment.DestinationCity,
                CreatedDate = shipment.CreatedDate,
                CurrentStatus = shipment.CurrentStatus,
            };
            return View(newShipment);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShipment(UpdateShipmentDto updateShipmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateShipmentDto);
            }
            await _shipmentService.UpdateShipmentAsync(updateShipmentDto);
            return RedirectToAction("ShipmentList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShipment(string id)
        {
            await _shipmentService.DeleteShipmentAsync(id);
            return RedirectToAction("ShipmentList");
        }
    }
}

