using CreatorsPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreatorsPlatform.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            if (2 == 1)
            {
                return View("Login");
            }
            return View("UserInfo");
        }
        public IActionResult Signup()
        {
            return View("Signup");
        }

        public IActionResult Login(string UserName)
        {
            return View("Login");
        }
    }
}