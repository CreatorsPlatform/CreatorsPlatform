using CreatorsPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Reflection;

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
        public ActionResult Signup(string Email, string Password)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            return RedirectToRoute("default");
        }
        [HttpPut]
        public void 更新暱稱(int UserId, string UserName)
        {
            return;
        }
        [HttpPut]
        public void 輸入密碼確認身分(int UserId, string Password)
        {
            return;
        }
        [HttpPut]
        public void 更新密碼(int UserId, string Password)
        {

        }
        [HttpPut]
        public void 更新電子信箱(int UserId, string Email)
        {

        }
        [HttpPost]
        public void 信箱驗證(int UserId)
        {

        }
        [HttpPut]
        public void 批量會員資訊更新(int UserId)
        {

        }
    }
}
