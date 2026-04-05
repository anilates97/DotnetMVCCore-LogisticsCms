using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

