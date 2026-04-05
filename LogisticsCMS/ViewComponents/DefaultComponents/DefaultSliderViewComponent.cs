using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Services.SliderService;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultSliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public DefaultSliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _sliderService.GetAllSlidersAsync();
            return View(sliders);
        }
    }
}

