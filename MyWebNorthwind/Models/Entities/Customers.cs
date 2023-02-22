using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebNorthwind.Models.Entities
{
    [TableAttribute(name: "Customers")]
    public class Customers
    {
        public Customers()
        {
             Orders = new HashSet<Order>();
        }
        [KeyAttribute()]
        [RequiredAttribute()]
        public string CustomerID { get; set; }
        [RequiredAttribute()]
        public string CompanyName { get; set; }
        [RequiredAttribute()]
        public string ContactName { get; set; }
        [RequiredAttribute()]
        public string ContactTitle { get; set; }
        [RequiredAttribute()]
        public string Address { get; set; }
        [RequiredAttribute()]
        public string City { get; set; }
        public string Country { get; set; }
        //public string Region { get; set; }
      //  public string PostalCode { get; set; }
        public string Phone { get; set; }
        //public string Fax { get; set; } // this

           public ICollection<Order> Orders { get; private set; }
    }
}
