using AutoMapper;
using LogisticsCMS.Dtos.ProjectSection;
using LogisticsCMS.Services.ProjectSection;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class ProjectSectionController : CrudControllerBase
    {
        private readonly IProjectSectionService _projectSectionService;
        private readonly IMapper _mapper;

        public ProjectSectionController(IProjectSectionService projectSectionService, IMapper mapper)
        {
            _projectSectionService = projectSectionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _projectSectionService.GetAllProjectSectionsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectSectionDto createDto)
        {
            return await SaveAndRedirectAsync(
                createDto,
                dto => _projectSectionService.CreateProjectSectionAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _projectSectionService.GetProjectSectionByIdAsync(id),
                value => _mapper.Map<UpdateProjectSectionDto>(value)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProjectSectionDto updateDto)
        {
            return await SaveAndRedirectAsync(
                updateDto,
                dto => _projectSectionService.UpdateProjectSectionAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(
                () => _projectSectionService.DeleteProjectSectionAsync(id)
            );
        }
    }
}
