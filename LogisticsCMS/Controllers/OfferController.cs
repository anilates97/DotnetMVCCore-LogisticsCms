namespace LogisticsCMS.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using LogisticsCMS.Dtos.OfferDtos;
    using LogisticsCMS.Services.OfferService;

    public class OfferController : Controller
    {
        private readonly IOfferService _OfferService;

        public OfferController(IOfferService OfferService)
        {
            _OfferService = OfferService;
        }

        public async Task<IActionResult> OfferList()
        {
            var Offers = await _OfferService.GetAllOffersAsync();
            return View(Offers);
        }

        [HttpGet]
        public IActionResult CreateOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDto createOfferDto)
        {
            if (ModelState.IsValid)
            {
                await _OfferService.CreateOfferAsync(createOfferDto);
                return RedirectToAction(nameof(OfferList));
            }
            return View(createOfferDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOffer(string id)
        {
            var Offer = await _OfferService.GetOfferByIdAsync(id);
            if (Offer == null)
            {
                return NotFound();
            }
            var newOffer = new GetOfferByIdDto
            {
                OfferId = Offer.OfferId,
                Title = Offer.Title,
                Description = Offer.Description,
                ImageUrl = Offer.ImageUrl,
                IsStatus = Offer.IsStatus,
            };
            return View(newOffer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            if (ModelState.IsValid)
            {
                await _OfferService.UpdateOfferAsync(updateOfferDto);
                return RedirectToAction(nameof(OfferList));
            }
            return View(updateOfferDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOffer(string id)
        {
            await _OfferService.DeleteOfferAsync(id);
            return RedirectToAction(nameof(OfferList));
        }
    }
}

