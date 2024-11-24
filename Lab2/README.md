# Behavioral Design Patterns

## Author: Ana Calugareanu

----

## Objectives:

* Get familiar with the Behavioral Design Patterns;
* Choose a specific domain;
* Implement at least 1 Behavioral Design Pattern for the specific domain;
* Ensure there is a single client interacting with the system.

----

## Used Design Pattern:

* **Command Pattern** - Encapsulates requests such as adding employees, cloning employees, and generating reports into standalone command objects. This ensures clean separation of concerns and allows easy extension of the system.

----

## Implementation

The Employee Management System demonstrates the use of the **Command Pattern**, a behavioral design pattern that encapsulates tasks as command objects. This pattern centralizes the execution of operations, simplifies the `Program` class, and provides a scalable framework for adding new functionality.

### Full Implementation Code

```csharp
// ICommand Interface
public interface ICommand
{
    void Execute();
}
```
**Example**: `AddEmployeeCommand`: Encapsulates the logic for adding a new employee.
```csharp
public class AddEmployeeCommand : ICommand
{
    private readonly EmployeeManagementFacade _facade;

    public AddEmployeeCommand(EmployeeManagementFacade facade)
    {
        _facade = facade;
    }

    public void Execute()
    {
        Console.Write("Enter employee type (FullTime/Contractor): ");
        string type = Console.ReadLine();
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();
        Console.Write("Enter department: ");
        string department = Console.ReadLine();
        Console.Write("Enter salary (for FullTime) or hourly rate (for Contractor): ");
        if (double.TryParse(Console.ReadLine(), out double salaryOrRate))
        {
            _facade.AddEmployee(type, name, department, salaryOrRate);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}
```

**Command Integration in Program**: `The Program` class uses a command dictionary to map user inputs to the corresponding command.
```csharp
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
```
## Conclusions / Results
The Employee Management System effectively demonstrates the use of the Command Pattern to encapsulate tasks into command objects. This pattern ensures a clean and scalable architecture, decoupling the Program class from the system's operational logic. By integrating this behavioral design pattern, the system is modular, maintainable, and easily extensible.

## License
This project is licensed under the MIT License.
