using Microsoft.AspNetCore.Mvc;
//using System.Net.Mail;

namespace MyWebNorthwind.Controllers
{
    public class jQueryDemoController : Controller
    {
        public IActionResult Index()
        { // Key-Value
            HttpContext.Session.SetString("Person", "哈哈世界和平"); //設置 Key 鍵 Person 的值

            return View();
        }
        [HttpPost] //使用post
        public IActionResult AjaxMethod(string sessionName)
        {           
                return Json(HttpContext.Session.GetString(sessionName)); //response
        }
    }
}
