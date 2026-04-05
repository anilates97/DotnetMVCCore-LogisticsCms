using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Services.HowItWorkService;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultHowItWorksViewComponent : ViewComponent
    {
        private readonly IHowItWorkService _howItWorkService;

        public DefaultHowItWorksViewComponent(IHowItWorkService howItWorkService)
        {
            _howItWorkService = howItWorkService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _howItWorkService.GetAllHowItWorksAsync();
            var activeValues = values.Where(x => x.Status).ToList();
            return View(activeValues.Any() ? activeValues : values);
        }
    }
}

