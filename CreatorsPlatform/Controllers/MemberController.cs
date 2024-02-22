using CreatorsPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreatorsPlatform.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ISession _session;

        public MemberController(ILogger<MemberController> logger,
            IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _session = contextAccessor.HttpContext.Session;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        public ActionResult SendLoginInfo(){
            _session.SetString("username", "admin");
            return View("UserInfo");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}