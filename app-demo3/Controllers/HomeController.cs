using Microsoft.AspNetCore.Mvc;

namespace app_demo3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
