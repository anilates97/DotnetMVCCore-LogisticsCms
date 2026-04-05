using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.ViewComponents.AdminComponents
{
    public class AdminLayoutHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

