using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

