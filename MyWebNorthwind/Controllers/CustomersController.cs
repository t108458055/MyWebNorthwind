using Microsoft.AspNetCore.Mvc;

namespace MyWebNorthwind.Controllers
{
    public class CustomersController : Controller
    {
        private readonly NorDBContext _dbContext; 
        public CustomersController(NorDBContext norDBContext)
        {
            _dbContext= norDBContext;
        }
        public IActionResult Index()
        {
            try
            {
                var dfs=_dbContext.Customers.ToList();
            }
            catch (Exception e)
            {
                var s=e.StackTrace.ToString();
                throw;
            }


            return View();
        }
    }
}
