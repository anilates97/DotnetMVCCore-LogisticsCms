using AutoMapper;
using LogisticsCMS.Dtos.Slider;
using LogisticsCMS.Services.Slider;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class SliderController : CrudControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.GetAllSlidersAsync();
            return View(sliders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderDto createSliderDto)
        {
            return await SaveAndRedirectAsync(
                createSliderDto,
                dto => _sliderService.CreateSliderAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _sliderService.GetSliderByIdAsync(id),
                slider => _mapper.Map<UpdateSliderDto>(slider)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSliderDto updateSliderDto)
        {
            return await SaveAndRedirectAsync(
                updateSliderDto,
                dto => _sliderService.UpdateSliderAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(() => _sliderService.DeleteSliderAsync(id));
        }
    }
}
