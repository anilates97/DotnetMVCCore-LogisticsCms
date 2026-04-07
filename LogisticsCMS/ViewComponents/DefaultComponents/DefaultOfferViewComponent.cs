using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Services.Offer;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultOfferViewComponent : ViewComponent
    {
        private readonly IOfferService _offerService;

        public DefaultOfferViewComponent(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var offers = await _offerService.GetAllOffersAsync();
            return View(offers);
        }
    }
}

