namespace MyWebNorthwind.Models.OCP
{
    /// OCP Code Example
    // After
    public abstract class BaseSalaryCalculator
    {
        protected EmployeeReport EmployeeReport { get; private set; }
        public BaseSalaryCalculator(EmployeeReport employeeReport)
        {
            EmployeeReport = employeeReport;
        }
        public abstract double CalculateSalary();
    }

    public class SeniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public SeniorDevSalaryCalculator(EmployeeReport employeeReport) : base(employeeReport)
        {
        }

        public override double CalculateSalary()
        {
            return new double();
        }
    }

    public class JuniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public JuniorDevSalaryCalculator(EmployeeReport DevReport) : base(DevReport)
        {
        }   
               
        public override double CalculateSalary()
        {
            return new double();
        }
    }
}
