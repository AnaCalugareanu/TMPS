namespace EmployeeManagementSystem.Models
{
    public class FullTimeEmployee : Employee
    {
        public double Salary { get; set; }
        public override string EmployeeType => "Full-Time";

        public double CalculateAnnualSalary() => Salary * 12;

        public override Employee Clone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }
}