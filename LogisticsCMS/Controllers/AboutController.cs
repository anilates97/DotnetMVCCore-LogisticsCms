using AutoMapper;
using LogisticsCMS.Dtos.About;
using LogisticsCMS.Services.About;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class AboutController : CrudControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutService.GetAllAboutsAsync();
            return View(abouts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            return await SaveAndRedirectAsync(
                createAboutDto,
                dto => _aboutService.CreateAboutAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _aboutService.GetAboutByIdAsync(id),
                about => _mapper.Map<UpdateAboutDto>(about)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAboutDto updateAboutDto)
        {
            return await SaveAndRedirectAsync(
                updateAboutDto,
                dto => _aboutService.UpdateAboutAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(() => _aboutService.DeleteAboutAsync(id));
        }
    }
}
