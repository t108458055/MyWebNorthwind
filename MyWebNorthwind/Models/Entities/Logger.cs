using System.ComponentModel.DataAnnotations;

namespace MyWebNorthwind.Models.Entities
{
    public class Logger:AbstractBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
