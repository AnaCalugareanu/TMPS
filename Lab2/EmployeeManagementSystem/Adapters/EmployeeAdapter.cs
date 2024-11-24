using EmployeeManagementSystem.Models;
using System.Text.Json;

namespace EmployeeManagementSystem.Adapters
{
    public interface IExternalEmployee
    {
        string GetEmployeeData();
    }

    public class EmployeeAdapter : IExternalEmployee
    {
        private readonly Employee _employee;

        public EmployeeAdapter(Employee employee)
        {
            _employee = employee;
        }

        public string GetEmployeeData()
        {
            return $"ID: {_employee.ID}, Name: {_employee.Name}, Type: {_employee.EmployeeType}, Department: {_employee.Department}";
        }

        public string ExportToJson()
        {
            var employeeData = new
            {
                ID = _employee.ID,
                Name = _employee.Name,
                Type = _employee.EmployeeType,
                Department = _employee.Department,
                Reviews = _employee.Reviews
            };

            return JsonSerializer.Serialize(employeeData);
        }
    }
}