using Microsoft.AspNetCore.Mvc;

namespace MyWebNorthwind.Controllers
{
    public class NavController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("api/getLinks")]        
        public List<string> GetLinks()
        {
            List<string> links = new List<string>();
            links.Add("/Home/Index");
            // 在這裡實現從資料庫中讀取超連結的邏輯
            // 並將它們存儲在 links 列表中

            return links;
        }
    }
}
