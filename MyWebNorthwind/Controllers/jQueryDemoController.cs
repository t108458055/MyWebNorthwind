using Microsoft.AspNetCore.Mvc;
//using System.Net.Mail;

namespace MyWebNorthwind.Controllers
{
    public class jQueryDemoController : Controller
    {
        private readonly ILogger<jQueryDemoController> _logger;
        public jQueryDemoController(ILogger<jQueryDemoController> logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        { // Key-Value
            _logger.LogInformation("Info");
            HttpContext.Session.SetString("Person", "哈哈世界和平"); //設置 Key 鍵 Person 的值
            return View();
        }
        [HttpPost] //使用post
        public IActionResult AjaxMethod(string sessionName)
        {
            _logger.LogInformation("Info");
            return Json(HttpContext.Session.GetString(sessionName)); //response
        }
    }
}
