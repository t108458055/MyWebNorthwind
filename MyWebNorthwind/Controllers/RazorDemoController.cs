using Microsoft.AspNetCore.Mvc;

namespace MyWebNorthwind.Controllers
{
    public class RazorDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
