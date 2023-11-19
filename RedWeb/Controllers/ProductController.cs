using Microsoft.AspNetCore.Mvc;

namespace RedWeb.Controllers
{
    // 練習檔案 上傳
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        //private readonly TFMDbContext _db;
        public ProductController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
         //撈取資料庫資料
        //public object GetAllProduct()
        //{
        //    return _db.Products.Select(x => new
        //    {
        //        Id = x.Id,
        //        Title = x.Title,
        //        Price = x.Price,
        //        Desc = x.Description,
        //        path = "./productpicture/" + x.PicPath
        //    });
        //}
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public bool UploadFile(UploadFileViewModel model)
        {
            //  var path = _environment.WebRootPath + "/ProductPicture";

            //var pic = model.Pic.FirstOrDefault();
            //if (pic != null)
            //{
            //    var fileName = DateTime.Now.Ticks.ToString() + pic.FileName;

            //    using (var fs = System.IO.File.Create($"{path}/{fileName}"))
            //    {
            //        pic.CopyTo(fs); //複製圖片
            //    }
            //  加入資料路徑到SQL Server
            //    _db.Products.Add(new Product()
            //    {
            //        Title = model.Title,
            //        Price = model.Price,
            //        Description = model.Description,
            //        PicPath = fileName
            //    });
            //    _db.SaveChanges();

            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;

        }
        /// <summary>
        /// 前端上傳
        /// </summary>
        public class UploadFileViewModel
        {
            public string Title { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public List<IFormFile> Pic { get; set; }
        }

    }
}
