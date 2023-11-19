using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RedWeb.Models
{
    /// <summary>
    /// 產品名稱
    /// </summary>
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string PicPath { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
