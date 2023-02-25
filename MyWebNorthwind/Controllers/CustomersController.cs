using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;

namespace MyWebNorthwind.Controllers
{    
    public class CustomersController : Controller
    {
        //Data Field
        private readonly NorDBContext _dbContext;
        private readonly DbServiceUtility _dbServiceUtility;
        // 自訂建構子 注入(DI)  物件 (singleton模式 單例物件 獨一性質)
        public CustomersController(NorDBContext norDBContext, DbServiceUtility dbServiceUtility)
        {
            Console.WriteLine("CustomersController控制物件產生");
            this._dbContext= norDBContext;
            Console.WriteLine($"Customers控制物件產生：{_dbContext}...");
            this._dbServiceUtility= dbServiceUtility;
            Console.WriteLine($"服務物件產生：{_dbServiceUtility}");

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

        // 調用查詢的表單 跟進行查詢輸出 寫在同一個入口 END POINT
        public IActionResult customersQryById(String customerID)    // 客戶查詢作業
        {           
            if (!String.IsNullOrEmpty(customerID))
            {   
                Console.WriteLine($"查詢內容：{customerID}");  // 進行相對客戶資料查詢               
                SqlConnection connection = _dbServiceUtility.GetConnection();  // 透過注入進來的Singletion的DbUility物件(連接工廠)生產要使用的個體連接物件                
                connection.Open(); //開啟連接              
                SqlCommand command = connection.CreateCommand();   // 透過連接物件,產生一個命令物件                
                String sql = "SELECT CustomerID, CompanyName, Address, Phone, Country   FROM Customers WHERE CustomerID=@CustomerID"; // 設定命令物件查詢敘述，進行查詢
                command.CommandType = System.Data.CommandType.Text; // 命令類型
                command.CommandText = sql; // 命令敘述               
                command.Parameters.AddWithValue("CustomerID", customerID);  // 建構命令參數物件，讓參數結合物件進行參考                
                SqlDataReader sqlDataReader = command.ExecuteReader(); // 查詢方式,只有一筆,採用線上架構,線上讀取結果紀錄  逐筆讀取
                String message = null;     // 訊息狀態                
                ViewModels.Mycustomers mycustomers = null; // 建置Models
                if (!sqlDataReader.HasRows) // 沒有值
                {                  
                    // 訊息結果
                    message = $"客戶編號:{customerID}找不到!!";   //查詢不到相對應客戶
                }
                else
                {
                    message = $"{customerID}客戶資料如下";
                    //讀取下來
                    sqlDataReader.Read(); // 停在相對應紀錄上,擷取欄位之內容
                    // 將查詢結果讀取下來紀錄封裝成Entity物件                
                    mycustomers = new ViewModels.Mycustomers() // 將Entity派送到指定的View進行呈現  
                    {
                        customerID = sqlDataReader["CustomerID"].ToString(),
                        companyName = sqlDataReader["CompanyName"].ToString(),
                        address = sqlDataReader["Address"].ToString(),
                        phone = sqlDataReader["Phone"].ToString(),
                        country = sqlDataReader["Country"].ToString(),
                    };  //物件初始化                                   
                }
                connection.Close();
                // 防呆畫面(事前設計呈現訊息狀態--第一次請求,尚未查詢) 帶到View
                dynamic bag = this.ViewBag; // 沒有型別的動態類型                                           
                bag.message = message;  // 產生一個執行階段的動態
                //...
                // 如何持續找到資料(Entitiy)當作一個Model傳遞到View去
                if (mycustomers != null)
                {
                    return View(mycustomers); // 指向同一個頁面 進行查詢結果輸出
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();  // 第一次進來直接調用查詢畫面
            }
        }
        //採用國家別查詢相關客戶資料
        public IActionResult customersQueryByCountry(String country)
        {
            // 判斷是否為第一次請求
            if (string.IsNullOrEmpty(country))
            {
                //第一次請求(主要找出國家別清單資料)
                // 1.透過連接工廠要一條連接物件
                SqlConnection sqlConnection = _dbServiceUtility.GetConnection();
                //開啟連接
                sqlConnection.Open();
                //  2.透過連接物件要一個命令物件
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //3.設定命令敘述指派給Command物件
                sqlCommand.CommandText = "Select * from vwCountry"; //要在Sql Create View vwCountry
                sqlCommand.CommandType = System.Data.CommandType.Text;
                // 4.執行 線上查詢結果
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                // 5.調用查詢(保持線上-連接不能關閉)               
                List<SelectListItem> selectListItems = new List<SelectListItem>();  // 建構一個集合物件 (具有順序性)
                //相對紀錄下載與處理
                while (dataReader.Read())
                {                                    
                    selectListItems.Add(new SelectListItem()  // 建構一個SelectListItem物件封裝讀取欄位內容
                    {
                        Text = dataReader["Country"].ToString(),
                        Value = dataReader["Country"].ToString()
                    }); // <option value="">text </option> for HTML
                }
                //配合一個瀏覽器透過Session持續selectListItem(data) (List集合物件的狀態)
                //HttpRequest request = this.Request;
                //List 物件如何序列化成JSON String ...(要不要有格式 XML Or JSON)
                String jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(selectListItems);
                Console.WriteLine(jsonString); //監控台              
                HttpContext.Session.SetString("data", jsonString);   // Persistence 持續性狀態 使用文字串
                //拿一個袋子(dynamic)來裝 帶到View
                this.ViewBag.Data = selectListItems; // 產生selectListItems(DATA) 物件保持持續狀態                
                return View(); // 調用畫面(將國家別清單資料???)

            }
            else
            {                
                String jsonString = HttpContext.Session.GetString("data"); // 取出Session管理狀態
                List<SelectListItem> selectListItems =  Newtonsoft.Json.JsonConvert.DeserializeObject<List<SelectListItem>>(jsonString);   //反序列化List<SelectListItem>集合物件
                ViewBag.Data = selectListItems; // 裝在袋子
                //TODO 查詢\相對國家別客戶資料
                //Linq 整合查詢語言,延遲查詢(lazy query)
                var result = from customers in _dbContext.Customers
                             where customers.Country == country
                             select customers;
                List<Models.Entities.Customers> resultData = result.ToList<Models.Entities.Customers>();
                //調用畫面(查詢)
                return View(resultData); //查詢結果,採用Model傳遞到Page 去

            }

        }
        //客戶資料新增作業
        public IActionResult customersForm()
        {
            return View();// 調用 Razor Page
        }

    }
}
