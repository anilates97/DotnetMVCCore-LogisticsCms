using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultMobileMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

