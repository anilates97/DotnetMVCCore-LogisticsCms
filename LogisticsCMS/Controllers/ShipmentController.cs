using AutoMapper;
using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Services.Shipment;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class ShipmentController : CrudControllerBase
    {
        private readonly IShipmentService _shipmentService;
        private readonly IMapper _mapper;

        public ShipmentController(IShipmentService shipmentService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var shipments = await _shipmentService.GetAllShipmentsAsync();
            return View(shipments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShipmentDto createShipmentDto)
        {
            return await SaveAndRedirectAsync(
                createShipmentDto,
                dto => _shipmentService.CreateShipmentAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _shipmentService.GetShipmentByIdAsync(id),
                shipment => _mapper.Map<UpdateShipmentDto>(shipment)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateShipmentDto updateShipmentDto)
        {
            return await SaveAndRedirectAsync(
                updateShipmentDto,
                dto => _shipmentService.UpdateShipmentAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(() => _shipmentService.DeleteShipmentAsync(id));
        }
    }
}
