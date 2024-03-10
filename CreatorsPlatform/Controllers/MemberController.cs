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
        private static readonly string CS = "Data Source=DESKTOP-BRLAJ7B\\SQLEXPRESS;Initial Catalog=CreaterPlatform;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False";
        private readonly MemberDatabase _memberDatabase;
        private static string 使用者哀低 = "UserId";
        private static string 使用者暱稱 = "UserName";
        private static string 使用者信箱 = "EMail";
        private static string 使用者密碼 = "UserPassword";
        private string 用來檢查重複的使用者的SQL指令 = $"SELECT {使用者信箱} FROM Users WHERE EMail = @UserEmail;";
        private string 用來檢查輸入的電子信箱與密碼是否符合存在資料庫的電子信箱與密碼的SQL指令 = $"SELECT {使用者信箱}, {使用者密碼} FROM Users WHERE {使用者信箱} = @A AND {使用者密碼} =@B;";
        private string 新增User的SQL指令 = $"INSERT INTO Users ({使用者信箱}, {使用者密碼}) VALUES (@UserEmail, @Password)";
        public string 會員資訊SQL指令 = $"SELECT [ID],[UserName],[EMail],[UserPassword],[RegisterDate],[LastLoginDate],[UserAvatar],[BirthdayDate],[PaymentMethod],[UserPoint],[EmailCertification],[CreatorID],[CategoryID] FROM [Users] WHERE [ID] = @ID";
        private SqlConnection sqlConnection = new SqlConnection(CS);

        public MemberController(MemberDatabase memberDatabase)
        {
            _memberDatabase = memberDatabase;
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
            var command = new SqlCommand
            {
                CommandText = this.用來檢查重複的使用者的SQL指令,
                Connection = this.sqlConnection
            };
            command.Parameters.AddWithValue("@UserEmail", Email);
            if (_memberDatabase.HasRows(command))
            {
                return RedirectToAction("Signup");
            }
            var createUser = new SqlCommand
            {
                CommandText = this.新增User的SQL指令,
                Connection = this.sqlConnection
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
                Connection = this.sqlConnection
            };
            command.Parameters.AddWithValue("@A", Email);
            command.Parameters.AddWithValue("@B", Password);
            if (_memberDatabase.HasRows(command))
            {
                HttpContext.Session.SetString("Id", Email);
                return RedirectToRoute("default");
            }
            return RedirectToPage("~/Views/Shared/頁面正在跳轉.cshtml");
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
    public class MemberDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool HasRows(SqlCommand command)
        {
            command.Connection.Open();
            if (command.ExecuteReader().Read())
            {
                command.Connection.Close();
                return true;
            }
            command.Connection.Close();
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable GetRows(SqlCommand command)
        {
            command.Connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt); command.Connection.Close();
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool Exec(SqlCommand command)
        {
            command.Connection.Open();
            try
            {
                command.ExecuteNonQuery(); command.Connection.Close();
                return true;
            }
            catch
            {
                command.Connection.Close();
                return false;
            }
        }
    }
}