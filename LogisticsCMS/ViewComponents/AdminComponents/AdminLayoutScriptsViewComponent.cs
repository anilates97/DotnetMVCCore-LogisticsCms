using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.ViewComponents.AdminComponents
{
    public class AdminLayoutScriptsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

