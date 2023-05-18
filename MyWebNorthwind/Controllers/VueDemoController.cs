using Microsoft.AspNetCore.Mvc;

namespace MyWebNorthwind.Controllers
{
    public class VueDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
