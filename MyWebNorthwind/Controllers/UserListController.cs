using Microsoft.AspNetCore.Mvc;

namespace MyWebNorthwind.Controllers
{
    public class UserListController : Controller
    {
        // 顯示頁面 教學
        public IActionResult Index()
        {
            return View();
        }

        [HttpGetAttribute]
        public List<User> GetAll()
        {
            return new List<User>() {
                new User(){
                    id = 1,
                    birthDay = DateTime.Now,
                    name="王曉明"
                },
                new User(){
                    id = 2,
                    birthDay = new DateTime(1990,2,2),
                    name = "陳曉波"
                },
                new User(){
                    id = 3,
                    birthDay = new DateTime(1992, 5, 5),
                    name ="張無忌"
                },
                new User(){
                    id = 4,
                    birthDay = new DateTime(1996,7, 7),
                    name ="陳重慶"
                }
            };
        }
        //建構子
        public class User
        {
            public string name { set; get; }
            public DateTime birthDay { set; get; }
            public int id { set; get; }
        }

    }
}
