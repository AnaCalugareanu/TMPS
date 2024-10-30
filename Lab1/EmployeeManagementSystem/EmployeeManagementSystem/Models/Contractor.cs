namespace EmployeeManagementSystem.Models
{
    public class Contractor : Employee
    {
        public double HourlyRate { get; set; }
        public override string EmployeeType => "Contractor";

        public override Employee Clone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }
}