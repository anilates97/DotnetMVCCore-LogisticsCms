namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    using Microsoft.AspNetCore.Mvc;

    public class DefaultBoxBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

