using Microsoft.AspNetCore.Mvc;

namespace CreatorsPlatform.Controllers
{
    public class CreatorController : Controller
    {
        // 創作者首頁
        public IActionResult Index()
        {
            return View();
        }

        // 創作者建立貼文(修改位置待訂)
        public IActionResult AddPost()
        {

            return View();
        }

        // 創作者建立接受委託表單(修改位置待訂)
        public IActionResult AddCommisionForm()
        {
            return View();
        }

        // 創作者建立訂閱方案(修改位置待訂)
        public IActionResult EditSubcriptionPlans()
        {
            return View();
        }
    }
}
