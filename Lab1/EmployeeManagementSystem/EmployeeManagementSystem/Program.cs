using EmployeeManagementSystem.Facade;
using EmployeeManagementSystem.Decorators;
using EmployeeManagementSystem.Adapters;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var facade = new EmployeeManagementFacade();

        while (true)
        {
            Console.WriteLine("1. Add Department");
            Console.WriteLine("2. Add Employee");
            Console.WriteLine("3. Clone Employee");
            Console.WriteLine("4. Show All Employees");
            Console.WriteLine("5. Add Review");
            Console.WriteLine("6. Display Department Counts");
            Console.WriteLine("7. Display Annual Salary for Full-Time Employee");
            Console.WriteLine("8. Search Employees");
            Console.WriteLine("9. Show Employee Review Summary");
            Console.WriteLine("10. Export Employee Data to JSON");
            Console.WriteLine("11. Generate Employee Summary Report");
            Console.WriteLine("0. Exit");
            Console.Write("Enter the operation you want to perform: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter department name: ");
                    facade.AddDepartment(Console.ReadLine());
                    break;

                case "2":
                    Console.Write("Enter employee type (FullTime/Contractor): ");
                    string type = Console.ReadLine();
                    Console.Write("Enter employee name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter department: ");
                    string department = Console.ReadLine();
                    Console.Write("Enter salary (for FullTime) or hourly rate (for Contractor): ");
                    if (double.TryParse(Console.ReadLine(), out double salaryOrRate))
                    {
                        facade.AddEmployee(type, name, department, salaryOrRate);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    break;

                case "3":
                    Console.Write("Enter GUID of employee to clone: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid id))
                    {
                        facade.CloneEmployee(id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid GUID format.");
                    }
                    break;

                case "4":
                    facade.DisplayAllEmployees();
                    break;

                case "5":
                    Console.Write("Enter GUID of employee to add review: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid reviewId))
                    {
                        Console.Write("Enter review text: ");
                        string review = Console.ReadLine();
                        facade.AddReview(reviewId, review);
                    }
                    else
                    {
                        Console.WriteLine("Invalid GUID format.");
                    }
                    break;

                case "6":
                    facade.DisplayDepartmentCounts();
                    break;

                case "7":
                    Console.Write("Enter GUID of full-time employee to view salary: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid salaryId))
                    {
                        facade.DisplayAnnualSalary(salaryId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid GUID format.");
                    }
                    break;

                case "8":
                    Console.Write("Search by (Name/Department/Type): ");
                    string searchBy = Console.ReadLine();
                    Console.Write("Enter search term: ");
                    string searchTerm = Console.ReadLine();
                    facade.SearchEmployees(searchBy, searchTerm);
                    break;

                case "9":
                    Console.Write("Enter GUID of employee to view review summary: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid summaryId))
                    {
                        var employee = facade.GetEmployeeById(summaryId);
                        if (employee != null)
                        {
                            var decoratedEmployee = new ReviewDecorator(employee);
                            Console.WriteLine($"Review Summary: {decoratedEmployee.GetReviewSummary()}");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found with that ID.");
                        }
                    }
                    break;

                case "10":
                    Console.Write("Enter GUID of employee to export data: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid exportId))
                    {
                        var employee = facade.GetEmployeeById(exportId);
                        if (employee != null)
                        {
                            var adapter = new EmployeeAdapter(employee);
                            Console.WriteLine($"Employee Data in JSON: {adapter.ExportToJson()}");
                        }
                        else
                        {
                            Console.WriteLine("Employee not found with that ID.");
                        }
                    }
                    break;

                case "11":
                    facade.GenerateEmployeeSummaryReport();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }
}