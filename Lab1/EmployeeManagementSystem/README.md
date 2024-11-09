# Structural Design Patterns

## Author: Ana Calugareanu

----

## Objectives:

* Get familiar with the Structural Design Patterns;
* Choose a specific domain;
* Implement at least 3 Structural Design Patterns for the specific domain.

----

## Used Design Patterns:

* **Facade Pattern** - Simplifies interactions with the complex subsystems of the employee management system by providing a single interface.
* **Decorator Pattern** - Allows dynamic addition of new behaviors to employees, specifically for managing reviews.
* **Adapter Pattern** - Facilitates the export of employee data to JSON format, allowing integration with external systems.

----

## Implementation

The Employee Management System demonstrates the use of three structural design patterns. The **Facade Pattern** provides a simplified interface for employee management operations, the **Decorator Pattern** enhances employees with review management functionality, and the **Adapter Pattern** enables employee data export in JSON format. Together, these patterns make the system more modular, maintainable, and extendable.

### Key Code Snippets

* **Facade Pattern**: `EmployeeManagementFacade` simplifies interactions with complex operations like adding employees, managing departments, and generating reports.

```csharp
public class EmployeeManagementFacade
{
    private readonly HRManager _hrManager;

    public EmployeeManagementFacade()
    {
        _hrManager = HRManager.Instance;
    }

    public void AddEmployee(string type, string name, string department, double salaryOrRate)
    {
        _hrManager.CreateAndAddEmployee(type, name, department, salaryOrRate);
    }

    public void GenerateEmployeeSummaryReport() => _hrManager.GenerateSummaryReport();
}
```

* **Decorator Pattern**: `ReviewDecorator` dynamically adds review functionalities to employees.

```csharp
public class ReviewDecorator : EmployeeDecorator
{
    public ReviewDecorator(Employee employee) : base(employee) {}

    public void AddReview(string review) => _employee.Reviews.Add(review);

    public string GetReviewSummary() => string.Join("; ", _employee.Reviews);
}
```

* **Adapter Pattern**: `EmployeeAdapter` exports employee data to JSON format for external integrations.

```csharp
public class EmployeeAdapter : IExternalEmployee
{
    private readonly Employee _employee;

    public EmployeeAdapter(Employee employee) { _employee = employee; }

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
```

* **Main Client Code**: The `Program` class is the single client entry point for the application, leveraging the `EmployeeManagementFacade`.

```csharp
class Program
{
    static void Main(string[] args)
    {
        var facade = new EmployeeManagementFacade();
        facade.AddEmployee("FullTime", "Alice", "HR", 50000);
        facade.GenerateEmployeeSummaryReport();
    }
}
```


## Conclusions / Results

The Employee Management System demonstrates the power of structural design patterns to create modular and extendable software. Using the Facade, Decorator, and Adapter patterns, the system is organized with clear separation of concerns, ensuring easier maintenance and scalability. Each pattern contributes to a flexible, efficient architecture that can adapt to future requirements.

## License
This project is licensed under the MIT License.


