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
        private readonly MemberDatabase _memberDatabase;
        private static string 使用者哀低 = "UserId";
        private static string 使用者暱稱 = "UserName";
        private static string 使用者信箱 = "UserEmail";
        private static string 使用者密碼 = "Password";
        private string 用來檢查重複的使用者的SQL指令 = $"SELECT {使用者信箱} FROM User WHERE UserEmail = @UserEmail;";
        private string 用來檢查輸入的電子信箱與密碼是否符合存在資料庫的電子信箱與密碼的SQL指令 = $"SELECT {使用者信箱}, {使用者密碼} FROM User WHERE {使用者信箱} = @A AND {使用者密碼} =@B;";
        private string 新增User的SQL指令 = $"INSERT INTO User ({使用者信箱} {使用者密碼}) VALUES (@UserEmail. @Password)";
        public string 會員資訊SQL指令 = $"SELECT [ID],[UserName],[EMail],[UserPassword],[RegisterDate],[LastLoginDate],[UserAvatar],[BirthdayDate],[PaymentMethod],[UserPoint],[EmailCertification],[CreatorID],[CategoryID] FROM [Users] WHERE [ID] = @ID";
        public MemberController(MemberDatabase memberDatabase)
        {
            _memberDatabase = memberDatabase;
        }
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
        [HttpPost]
        public ActionResult Signup(string Email, string Password)
        {
            var command = new SqlCommand
            {
                CommandText = this.用來檢查重複的使用者的SQL指令,
            };
            command.Parameters.AddWithValue("@UserEmail", Email);
            if (_memberDatabase.HasRows(command))
            {
                return RedirectToAction("Signup");
            }
            var createUser = new SqlCommand
            {
                CommandText = this.新增User的SQL指令,
            };
            createUser.Parameters.AddWithValue("@UserEmail", Email);
            createUser.Parameters.AddWithValue("@Password", Password);
            if (_memberDatabase.Exec(createUser))
            {
                HttpContext.Session.SetString("Id", Email);
                return RedirectToRoute("default");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            var command = new SqlCommand
            {
                CommandText = this.用來檢查輸入的電子信箱與密碼是否符合存在資料庫的電子信箱與密碼的SQL指令,
            };
            command.Parameters.AddWithValue("@A", Email);
            command.Parameters.AddWithValue("@B", Password);
            if (_memberDatabase.HasRows(command))
            {
                HttpContext.Session.SetString("Id", Email);
                return RedirectToRoute("default");
            }
            return RedirectToAction("Index");
        }
    }
    public class MemberDatabase
    {
        public bool HasRows(SqlCommand command)
        {
            command.Connection.Open();
            if (command.ExecuteReader().HasRows)
            {
                command.Connection.Close();
                return true;
            }
            return false;
        }
        public DataTable GetRows(SqlCommand command)
        {
            command.Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }
        public bool Exec(SqlCommand command)
        {
            command.Connection.Open();
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}