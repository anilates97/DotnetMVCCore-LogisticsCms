using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.ViewComponents.AdminComponents
{
    public class AdminLayoutSideBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

