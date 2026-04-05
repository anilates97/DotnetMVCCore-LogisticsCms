using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Services.GetInTouchSectionService;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultGetInTouchViewComponent : ViewComponent
    {
        private readonly IGetInTouchSectionService _getInTouchSectionService;

        public DefaultGetInTouchViewComponent(IGetInTouchSectionService getInTouchSectionService)
        {
            _getInTouchSectionService = getInTouchSectionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _getInTouchSectionService.GetAllGetInTouchSectionsAsync();
            var value = values.FirstOrDefault(x => x.Status) ?? values.FirstOrDefault();
            return View(value);
        }
    }
}

