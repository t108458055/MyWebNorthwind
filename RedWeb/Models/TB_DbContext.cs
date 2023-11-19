using Microsoft.EntityFrameworkCore;

namespace RedWeb.Models
{
    public class TB_DbContext:DbContext
    {
        public TB_DbContext(DbContextOptions<TB_DbContext> options) : base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
    }
}
