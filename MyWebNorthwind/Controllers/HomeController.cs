﻿
using MyWebNorthwind.Repositories;

namespace MyWebNorthwind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomersRepository<Customers> _customersRepository;
        private readonly NorDBContext _dbContext;

        public HomeController(ILogger<HomeController> logger, CustomersRepository<Customers> customersRepository, NorDBContext dbContext)
        {
            _logger = logger;
            _customersRepository = customersRepository;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Info");
            //   var customers=_customersRepository.FetchAll();
            // var dfs=_dbContext.Customers.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Info");
            return View();
        }

        public IActionResult StringQuery()
        {
            _logger.LogInformation("Info");
            return Content("連接成功");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogInformation("Info");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}