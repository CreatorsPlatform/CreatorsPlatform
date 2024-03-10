using Microsoft.AspNetCore.Mvc;

namespace CreatorsPlatform.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EventContent()
        {
            return View();
        }

        public IActionResult CreateEvent()
        {
            return View();
        }
    }
}
