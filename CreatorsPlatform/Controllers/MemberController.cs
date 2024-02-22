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

        // TODO: Verification & Routing Logic / 認證與路由邏輯
        public ViewResult Index()
        {
            //var name = _session.GetString("username");
            //if (name == "admin")
            //{
            //    return View("UserInfo");
            //}
            return View("Login");
        }

        public IActionResult Login()
        {
            
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        public ActionResult SendLoginInfo()
        {
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