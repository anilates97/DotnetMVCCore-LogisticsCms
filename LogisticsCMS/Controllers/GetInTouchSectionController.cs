using AutoMapper;
using LogisticsCMS.Dtos.GetInTouchSection;
using LogisticsCMS.Services.GetInTouchSection;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class GetInTouchSectionController : CrudControllerBase
    {
        private readonly IGetInTouchSectionService _getInTouchSectionService;
        private readonly IMapper _mapper;

        public GetInTouchSectionController(IGetInTouchSectionService getInTouchSectionService, IMapper mapper)
        {
            _getInTouchSectionService = getInTouchSectionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getInTouchSectionService.GetAllGetInTouchSectionsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGetInTouchSectionDto createDto)
        {
            return await SaveAndRedirectAsync(
                createDto,
                dto => _getInTouchSectionService.CreateGetInTouchSectionAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _getInTouchSectionService.GetInTouchSectionByIdAsync(id),
                value => _mapper.Map<UpdateGetInTouchSectionDto>(value)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateGetInTouchSectionDto updateDto)
        {
            return await SaveAndRedirectAsync(
                updateDto,
                dto => _getInTouchSectionService.UpdateGetInTouchSectionAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(
                () => _getInTouchSectionService.DeleteGetInTouchSectionAsync(id)
            );
        }
    }
}
