using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Services.ProjectSection;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultWhatWeHaveDoneViewComponent : ViewComponent
    {
        private readonly IProjectSectionService _projectSectionService;

        public DefaultWhatWeHaveDoneViewComponent(IProjectSectionService projectSectionService)
        {
            _projectSectionService = projectSectionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _projectSectionService.GetAllProjectSectionsAsync();
            var activeValues = values.Where(x => x.Status).ToList();
            return View(activeValues.Any() ? activeValues : values);
        }
    }
}

