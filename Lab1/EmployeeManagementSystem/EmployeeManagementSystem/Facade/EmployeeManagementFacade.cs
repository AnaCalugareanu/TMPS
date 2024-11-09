using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Decorators;
using System;
using System.Linq;

namespace EmployeeManagementSystem.Facade
{
    public class EmployeeManagementFacade
    {
        private readonly HRManager _hrManager = HRManager.Instance;

        // Adds a new department
        public void AddDepartment(string departmentName)
        {
            _hrManager.AddDepartment(departmentName);
            Console.WriteLine($"Department '{departmentName}' added.");
        }

        // Adds a new employee with specified type, name, department, and salary or hourly rate
        public void AddEmployee(string type, string name, string department, double salaryOrRate)
        {
            Employee employee = EmployeeFactory.CreateEmployee(type);
            employee.Name = name;
            employee.Department = department;

            if (employee is FullTimeEmployee fullTimeEmp)
                fullTimeEmp.Salary = salaryOrRate;
            else if (employee is Contractor contractorEmp)
                contractorEmp.HourlyRate = salaryOrRate;

            _hrManager.AddEmployee(employee);
            Console.WriteLine($"Employee '{name}' added with ID: {employee.ID}");
        }

        // Clones an employee based on their GUID
        public void CloneEmployee(Guid id)
        {
            var original = _hrManager.Employees.Find(e => e.ID == id);
            if (original != null)
            {
                var clone = original.Clone();
                _hrManager.AddEmployee(clone);
                Console.WriteLine($"Employee cloned successfully! New employee ID: {clone.ID}");
            }
            else
            {
                Console.WriteLine("Employee not found with that ID.");
            }
        }

        // Displays all employees with their details
        public void DisplayAllEmployees()
        {
            Console.WriteLine("Employees:");
            foreach (var employee in _hrManager.Employees)
            {
                Console.WriteLine($"Name: {employee.Name}, ID: {employee.ID}, Type: {employee.EmployeeType}, Department: {employee.Department}");
            }
        }

        // Displays the count of employees in each department
        public void DisplayDepartmentCounts()
        {
            _hrManager.DisplayDepartmentCounts();
        }

        // Retrieves an employee by ID
        public Employee GetEmployeeById(Guid id)
        {
            return _hrManager.Employees.FirstOrDefault(e => e.ID == id);
        }

        // Adds a review to an employee by ID
        public void AddReview(Guid employeeId, string review)
        {
            var employee = GetEmployeeById(employeeId);
            if (employee != null)
            {
                var decoratedEmployee = new ReviewDecorator(employee);
                decoratedEmployee.AddReview(review);
                Console.WriteLine("Review added successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found with that ID.");
            }
        }

        // Calculates and displays the annual salary for a full-time employee by ID
        public void DisplayAnnualSalary(Guid employeeId)
        {
            var employee = _hrManager.Employees
                .OfType<FullTimeEmployee>()
                .FirstOrDefault(e => e.ID == employeeId);

            if (employee != null)
            {
                Console.WriteLine($"Annual Salary for {employee.Name}: {employee.CalculateAnnualSalary()}");
            }
            else
            {
                Console.WriteLine("Full-time employee not found with that ID.");
            }
        }

        // Searches for employees by a specific field and term
        public void SearchEmployees(string searchBy, string searchTerm)
        {
            var results = _hrManager.Employees.Where(e =>
                (searchBy.Equals("Name", StringComparison.OrdinalIgnoreCase) && e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                (searchBy.Equals("Department", StringComparison.OrdinalIgnoreCase) && e.Department.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                (searchBy.Equals("Type", StringComparison.OrdinalIgnoreCase) && e.EmployeeType.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
            );

            Console.WriteLine("Search Results:");
            foreach (var empl in results)
            {
                Console.WriteLine($"Name: {empl.Name}, ID: {empl.ID}, Department: {empl.Department}, Type: {empl.EmployeeType}");
            }
        }

        // Generates a summary report for each employee
        public void GenerateEmployeeSummaryReport()
        {
            Console.WriteLine("Employee Summary Report:");
            foreach (var employee in _hrManager.Employees)
            {
                Console.WriteLine($"Name: {employee.Name}");
                Console.WriteLine($"ID: {employee.ID}");
                Console.WriteLine($"Type: {employee.EmployeeType}");
                Console.WriteLine($"Department: {employee.Department}");
                Console.WriteLine($"Review Count: {employee.Reviews.Count}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}