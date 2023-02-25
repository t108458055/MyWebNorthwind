using Microsoft.AspNetCore.Mvc;

namespace MyWebNorthwind.Controllers
{
    //   摘要 自定義 過濾器  
    public class FilterDemoController : Controller
    {
        [Attributes.LogInSecurity]
        public IActionResult Index()
        {
            return Content("恭喜!世界和平!");
        }
    }
}
