using CreatorsPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreatorsPlatform.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public ActionResult 送出帳號(){
            return View("已登入");
        }
        public bool 檢查有沒有登入(){
            return false;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}