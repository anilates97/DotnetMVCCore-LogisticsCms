using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.ViewComponents.AdminComponents
{
    public class AdminLayoutTopBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

