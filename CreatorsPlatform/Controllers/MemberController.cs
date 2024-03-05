using CreatorsPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreatorsPlatform.Controllers
{
    public class MemberController : Controller
    {
        private static string 使用者哀低 = "UserId";
        private static string 使用者信箱 = "UserEmail";
        private static string 使用者密碼 = "Password";
        private string 用來檢查重複的使用者的SQL指令 = $"SELECT {使用者信箱} FROM User WHERE UserEmail = @UserEmail;";
        private string 用來檢查輸入的電子信箱與密碼是否符合存在資料庫的電子信箱與密碼的SQL指令 = $"SELECT {使用者信箱}, {使用者密碼} FROM User WHERE {使用者信箱} = @A AND {使用者密碼} =@B;";
        public MemberController()
        {
            
        }
        public IActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine(用來檢查輸入的電子信箱與密碼是否符合存在資料庫的電子信箱與密碼的SQL指令);
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