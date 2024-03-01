using Microsoft.AspNetCore.Mvc;

namespace CreatorsPlatform.Controllers
{
    public class CreatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
