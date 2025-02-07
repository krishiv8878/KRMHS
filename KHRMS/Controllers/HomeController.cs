using Microsoft.AspNetCore.Mvc;

namespace KHRMS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
