using Microsoft.AspNetCore.Mvc;

namespace CreatorsPlatform.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
