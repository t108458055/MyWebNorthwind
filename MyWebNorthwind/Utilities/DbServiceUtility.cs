using Microsoft.Data.SqlClient;

namespace MyWebNorthwind.Utilities
{    
    public class DbServiceUtility // 設定有關於與資料庫使用相關物件工程架構建置
    {
        // Data Field
        private static string _connectionString; // 連線字串
        // DI
        public DbServiceUtility(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("northwind"); // 取得連線字串 共用只產生一次
        }
        //產生連線物件的方法
        public SqlConnection GetConnection() 
        {
            return new SqlConnection(_connectionString);
        }
    }
}
