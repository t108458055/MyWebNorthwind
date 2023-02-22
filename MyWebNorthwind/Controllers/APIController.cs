using Microsoft.AspNetCore.Mvc;

namespace MyWebNorthwind.Controllers
{
    public class APIController : ControllerBase
    {
        public IActionResult Hella()
        {
            return Content("Hello!World!");
        }
    }
}
