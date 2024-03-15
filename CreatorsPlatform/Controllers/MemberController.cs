using CreatorsPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace CreatorsPlatform.Controllers
{
    public class MemberController : Controller
    {
        public MemberController()
        {
        }
        public IActionResult Individual()
        {
            return View();
        }
        public IActionResult Index()
        {
            if (2 == 1)
            {
                return View("Login");
            }
            return View("UserInfo");
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View("Signup");
        }

        [HttpGet]
        public IActionResult Login(string UserName)
        {
            return View("頁面正在跳轉");
            return View("Login");
        }
        [HttpGet]
        public IActionResult Login2(string UserName)
        {
            return View("Login");
        }

        [HttpPost]
        public JsonResult Signup([FromBody] JsonElement json)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public JsonResult Login([FromBody] JsonElement json)
        {
            throw new NotImplementedException();
        }
    }
}
