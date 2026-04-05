using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultGetQuoteViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

