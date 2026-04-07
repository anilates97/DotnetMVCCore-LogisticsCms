using AutoMapper;
using LogisticsCMS.Dtos.Offer;
using LogisticsCMS.Services.Offer;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class OfferController : CrudControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OfferController(IOfferService offerService, IMapper mapper)
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetAllOffersAsync();
            return View(offers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfferDto createOfferDto)
        {
            return await SaveAndRedirectAsync(
                createOfferDto,
                dto => _offerService.CreateOfferAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _offerService.GetOfferByIdAsync(id),
                offer => _mapper.Map<UpdateOfferDto>(offer)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateOfferDto updateOfferDto)
        {
            return await SaveAndRedirectAsync(
                updateOfferDto,
                dto => _offerService.UpdateOfferAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(() => _offerService.DeleteOfferAsync(id));
        }
    }
}
