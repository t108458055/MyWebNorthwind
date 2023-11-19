using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedWeb.Models;
using System.Diagnostics;

namespace RedWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "employee,admin")]
        public IActionResult Privacy()
        {
            var data = HttpContext.User.Claims.Where(x => x.Type == "Hello").FirstOrDefault();
            if (data != null)
            {
                ViewBag.Salary = data.Value;
            }
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}