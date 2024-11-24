using EmployeeManagementSystem.Commands;
using EmployeeManagementSystem.Facade;

internal class Program
{
    private static void Main(string[] args)
    {
        var facade = new EmployeeManagementFacade();

        var commands = new Dictionary<string, ICommand>
        {
            { "1", new AddDepartmentCommand(facade) },
            { "2", new AddEmployeeCommand(facade) },
            { "3", new CloneEmployeeCommand(facade) },
            { "4", new ShowAllEmployeesCommand(facade) },
            { "5", new AddReviewCommand(facade) },
            { "6", new DisplayDepartmentCountsCommand(facade) },
            { "7", new DisplayAnnualSalaryCommand(facade) },
            { "8", new SearchEmployeesCommand(facade) },
            { "9", new ShowEmployeeReviewSummaryCommand(facade) },
            { "10", new ExportEmployeeDataCommand(facade) },
            { "11", new GenerateEmployeeSummaryReportCommand(facade) }
        };

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

            if (choice == "0")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                break;
            }
            else if (commands.ContainsKey(choice))
            {
                commands[choice].Execute();
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose again.");
            }
        }
    }
}