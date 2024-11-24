using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem
{
    public static class EmployeeFactory
    {
        public static Employee CreateEmployee(string type)
        {
            return type switch
            {
                "FullTime" => new FullTimeEmployee(),
                "Contractor" => new Contractor(),
                _ => throw new ArgumentException("Invalid employee type")
            };
        }
    }
}