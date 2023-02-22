namespace MyWebNorthwind.Models.Entities
{
    public class EmployeeTerritory
    {
        [Key]
        public int EmployeeID { get; set; }
        public string TerritoryID { get; set; }

        public Employee Employee { get; set; }
        public Territory Territory { get; set; }
    }
}
