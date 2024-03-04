using CreatorsPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreatorsPlatform.Controllers
{
    public class MemberController : Controller
    {
        public ViewResult Index()
        {
            //var name = _session.GetString("username");
            //if (name == "admin")
            //{
            //    return View("UserInfo");
            //}
            return View("Login");
        }

        public IActionResult Signup()
        {
            return View();
        }

        public ActionResult Login(string UserName)
        {
            return View("UserInfo");
        }
    }
}