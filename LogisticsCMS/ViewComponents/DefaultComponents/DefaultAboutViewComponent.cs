using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Services.About;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultAboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public DefaultAboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = await _aboutService.GetAllAboutsAsync();
            return View(abouts);
        }
    }
}

