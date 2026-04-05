namespace LogisticsCMS.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using LogisticsCMS.Dtos.SliderDtos;
    using LogisticsCMS.Services.SliderService;

    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> SliderList()
        {
            var sliders = await _sliderService.GetAllSlidersAsync();
            return View(sliders);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {
            if (ModelState.IsValid)
            {
                await _sliderService.CreateSliderAsync(createSliderDto);
                return RedirectToAction(nameof(SliderList));
            }
            return View(createSliderDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(string id)
        {
            var slider = await _sliderService.GetSliderByIdAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            var newSlider = new GetSliderByIdDto
            {
                SliderId = slider.SliderId,
                Title = slider.Title,
                Description = slider.Description,
                ImageUrl = slider.ImageUrl,
                SubTitle = slider.SubTitle,
            };
            return View(newSlider);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            if (ModelState.IsValid)
            {
                await _sliderService.UpdateSliderAsync(updateSliderDto);
                return RedirectToAction(nameof(SliderList));
            }
            return View(updateSliderDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return RedirectToAction(nameof(SliderList));
        }
    }
}

