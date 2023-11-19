using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RedWeb.Controllers
{
    public class AccountController : Controller
    {
        // 建構一格 mock data  DBase
        private readonly List<User> _db;

        public AccountController()
        {
            _db = new List<User>() {
                 new User()
                 {
                     Id = 1, Account = "reds@gmail.com", Name = "Reds", Password = "1234",
                     Roles = new string[]{"admin"},
                     Salary = 100
                 },
                 new User() {
                     Id = 2, Account = "eric@gmail.com", Name = "Eric", Password = "4321",
                     Roles = new string[]{"employee"},
                     Salary = 100000000

                 },
                 new User() {
                     Id = 3, Account = "william@gmail.com", Name = "William", Password = "abcd",
                     Roles = new string[]{ "admin","employee" },
                     Salary = 100
                 }
             };
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginViewModel model)
        {
            //拿著畫面傳來的帳號密碼跟資料庫做比對
            var user = _db.FirstOrDefault(x => x.Account == model.Account && x.Password == model.Password);

            if (user == null)
            {
                return View("Login");
            }
            else
            {
                var r = user.Roles.Select(x => new Claim(ClaimTypes.Role, x.ToString()));

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Account),
                    new Claim("User_Id", user.Id.ToString()),
                    new Claim("Hello",user.Salary.ToString())
                };
                claims.AddRange(r);
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
        }
    }


    // 前端 model
    public class LoginViewModel
        {
            public string Account { get; set; }
            public string Password { get; set; }
        }
        // 控制器 model
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Account { get; set; }
            public string Password { get; set; }
            public string[] Roles { get; set; }
            public int Salary { get; set; }
        }

    
}
