
namespace MyWebNorthwind.Models
{
    //規劃一個Persistence持久層框架(mapping 實體資料庫) 繼承 DbContext
    public class NorDBContext : DbContext
    {
        public NorDBContext()
        {
            //Console.WriteLine("DbContext物件所產生了..!!");   //是否有進來,做確認
        }
        //自定義建構子 注入DBContext Option(選項)
        public NorDBContext(DbContextOptions<NorDBContext> _dbContextOptions):base(_dbContextOptions)
        {
        }
        //定義自動屬性Property
        public DbSet<Category> Category { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritory { get; set; }      
       public DbSet<Logger> Logger { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Territory> Territory { get; set; }

        // https://github.com/jasontaylordev/NorthwindTraders/tree/master/Src/Domain/Entities
    }
}
