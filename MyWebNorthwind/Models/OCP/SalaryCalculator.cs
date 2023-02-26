namespace MyWebNorthwind.Models.OCP
{
    /// OCP Code Example
    // before
    public class EmployeeReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int WorkingHours { get; set; }
        public double HourlyRate { get; set; }
    }
    // 計算薪資
    public class SalaryCalculator
    {
        private readonly IEnumerable<EmployeeReport> _employeeReports;
        public SalaryCalculator(List<EmployeeReport> employeeReports)
        {
            _employeeReports= employeeReports;
        }
        // 時薪*工時
        public double CalculateTotalSalaries() 
        {
            double totalSalaries = 0D; // 0
            foreach (EmployeeReport devReport in _employeeReports)
            {
                //check level and apply bonus if demands came
                totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
            }
            return totalSalaries;
        }
    }
}
