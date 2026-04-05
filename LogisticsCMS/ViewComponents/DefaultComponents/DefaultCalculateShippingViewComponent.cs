using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultCalculateShippingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

