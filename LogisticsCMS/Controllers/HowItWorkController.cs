using AutoMapper;
using LogisticsCMS.Dtos.HowItWork;
using LogisticsCMS.Services.HowItWork;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class HowItWorkController : CrudControllerBase
    {
        private readonly IHowItWorkService _howItWorkService;
        private readonly IMapper _mapper;

        public HowItWorkController(IHowItWorkService howItWorkService, IMapper mapper)
        {
            _howItWorkService = howItWorkService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _howItWorkService.GetAllHowItWorksAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHowItWorkDto createDto)
        {
            return await SaveAndRedirectAsync(
                createDto,
                dto => _howItWorkService.CreateHowItWorkAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _howItWorkService.GetHowItWorkByIdAsync(id),
                value => _mapper.Map<UpdateHowItWorkDto>(value)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateHowItWorkDto updateDto)
        {
            return await SaveAndRedirectAsync(
                updateDto,
                dto => _howItWorkService.UpdateHowItWorkAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(() => _howItWorkService.DeleteHowItWorkAsync(id));
        }
    }
}
