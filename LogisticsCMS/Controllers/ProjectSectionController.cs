using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Dtos.ProjectSectionDtos;
using LogisticsCMS.Services.ProjectSectionService;

namespace LogisticsCMS.Controllers
{
    public class ProjectSectionController : Controller
    {
        private readonly IProjectSectionService _projectSectionService;

        public ProjectSectionController(IProjectSectionService projectSectionService)
        {
            _projectSectionService = projectSectionService;
        }

        public async Task<IActionResult> ProjectSectionList()
        {
            var values = await _projectSectionService.GetAllProjectSectionsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProjectSection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectSection(CreateProjectSectionDto createProjectSectionDto)
        {
            if (ModelState.IsValid)
            {
                await _projectSectionService.CreateProjectSectionAsync(createProjectSectionDto);
                return RedirectToAction(nameof(ProjectSectionList));
            }

            return View(createProjectSectionDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProjectSection(string id)
        {
            var value = await _projectSectionService.GetProjectSectionByIdAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateProjectSectionDto
            {
                ProjectSectionId = value.ProjectSectionId,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Status = value.Status
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProjectSection(UpdateProjectSectionDto updateProjectSectionDto)
        {
            if (ModelState.IsValid)
            {
                await _projectSectionService.UpdateProjectSectionAsync(updateProjectSectionDto);
                return RedirectToAction(nameof(ProjectSectionList));
            }

            return View(updateProjectSectionDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProjectSection(string id)
        {
            await _projectSectionService.DeleteProjectSectionAsync(id);
            return RedirectToAction(nameof(ProjectSectionList));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProject(string id)
        {
            await _projectSectionService.DeleteProjectSectionAsync(id);
            return RedirectToAction(nameof(ProjectSectionList));
        }
    }
}

