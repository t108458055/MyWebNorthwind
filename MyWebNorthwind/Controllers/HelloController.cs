using Microsoft.AspNetCore.Mvc;

namespace MyWebNorthwind.Controllers
{
    public class HelloController : Controller //繼承控制器(Controller) ControllerBase 則是沒有View
    {
        //DATA Field
        private readonly ILogger<HelloController> _logger;
        //DI
        public HelloController(ILogger<HelloController> logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Info");
            return View();
        }
        // url: /Hello/SayHello
        /// <summary>
        /// 說哈囉世界  !  使用 IActionResult 
        /// </summary>
        /// <returns></returns>
        public IActionResult SayHello()   //自訂方法Method (程序 進行控制流程)
        {
            _logger.LogInformation("Info");
            string messageHelloWorld = "Hello World!";  //打招呼             
            IActionResult resultContent = this.Content(messageHelloWorld);  //IActionResult 多型化           
            return resultContent;    //回應值,處理好要去掉用(派送)一個View(畫面方式多種方式)
        }
        // url: /Hello/SayHelloResponse
        /// <summary>
        /// 說哈囉世界  !  使用 ContentResult設定Response Content(MIME Type)
        /// </summary> 
        /// <returns></returns>
        public IActionResult SayHelloResponse()
        {  // Refer: MIME Type: https://developer.mozilla.org/zh-TW/docs/Web/HTTP/Basics_of_HTTP/MIME_types
            _logger.LogInformation("Info");
            string messageHelloWorld = "<font size='36' color='red'>您好 Hello World!吃飽沒</font>";  //打招呼                                  
            ContentResult resultContent = this.Content(messageHelloWorld, "text/html;charset=UTF-8");  // 去問一個ContenetResult類別的個體物件,封裝自訂文字創建到前端去，第二個參數當網頁讀取時，設定Response Content(MIME Type)。
            return resultContent;  //回應值,處理好要去掉用(派送)一個View(畫面方式多種方式)
        }
        /// <summary>
        /// 採用QueryString傳遞一個參數(誰)名字進來 打招呼
        /// </summary>
        /// <param name="who">?who= 參數值</param>
        /// <returns></returns>
        public IActionResult WhoHello([FromQueryAttribute(Name = "w")] string who)  //採用QueryString傳遞一個參數(誰)名字進來 打招呼
        {
            _logger.LogInformation("Info");
            //string resultContentString = String.Format($"{who}你好 世界和平");   //$"" String pattern 處理{expression}動態
            string resultContentString = $"<font size='36' color='red'>{who}您好!世界和平!!</font>"; ////打招呼處理
            /** return this.Content(content,
                    //    new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("text/html")
                  //    )
            ;*/
            return this.Content(resultContentString, "text/html;charset=UTF-8");
        }
        // 了解控制器Get原理,及字串丟入回傳值,並使用語法糖 ?w=para

    }
}
