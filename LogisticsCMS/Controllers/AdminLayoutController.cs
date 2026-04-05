using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

