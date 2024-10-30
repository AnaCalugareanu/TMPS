using EmployeeManagementSystem;
using EmployeeManagementSystem.Models;

var manager = HRManager.Instance;

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
    Console.WriteLine("0. Exit");
    Console.Write("Enter the operation you want to perform : ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter department name: ");
            manager.AddDepartment(Console.ReadLine());
            break;

        case "2":
            Console.Write("Enter employee type (FullTime/Contractor): ");
            string type = Console.ReadLine();
            Employee emp = EmployeeFactory.CreateEmployee(type);
            Console.Write("Enter employee name: ");
            emp.Name = Console.ReadLine();
            Console.Write("Enter department: ");
            emp.Department = Console.ReadLine();

            if (emp is FullTimeEmployee fullTimeEmp)
            {
                Console.Write("Enter monthly salary: ");
                if (double.TryParse(Console.ReadLine(), out double salary))
                {
                    fullTimeEmp.Salary = salary;
                }
                else
                {
                    Console.WriteLine("Invalid input for salary. Setting default salary to 0.");
                    fullTimeEmp.Salary = 0;
                }
            }
            else if (emp is Contractor contractorEmp)
            {
                Console.Write("Enter hourly rate: ");
                if (double.TryParse(Console.ReadLine(), out double hourlyRate))
                {
                    contractorEmp.HourlyRate = hourlyRate;
                }
                else
                {
                    Console.WriteLine("Invalid input for hourly rate. Setting default rate to 0.");
                    contractorEmp.HourlyRate = 0;
                }
            }

            manager.AddEmployee(emp);
            Console.WriteLine($"Employee added with ID: {emp.ID}");
            break;

        case "3":
            Console.Write("Enter GUID of employee to clone: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                var original = manager.Employees.Find(e => e.ID == id);
                if (original != null)
                {
                    var clone = original.Clone();
                    manager.AddEmployee(clone);
                    Console.WriteLine($"Employee cloned successfully! New employee ID: {clone.ID}");
                }
                else
                {
                    Console.WriteLine("Employee not found with that ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid GUID format.");
            }
            break;

        case "4":
            Console.WriteLine("Employees:");
            foreach (var e in manager.Employees)
            {
                Console.WriteLine($" Name: {e.Name}, ID: {e.ID}, Type: {e.EmployeeType}, Department: {e.Department}.");
            }
            break;

        case "5": // Add Review
            Console.Write("Enter GUID of employee to add review: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid reviewId))
            {
                var employee = manager.Employees.Find(e => e.ID == reviewId);
                if (employee != null)
                {
                    Console.Write("Enter review text: ");
                    employee.AddReview(Console.ReadLine());
                    Console.WriteLine("Review added successfully!");
                }
                else
                {
                    Console.WriteLine("Employee not found with that ID.");
                }
            }
            break;

        case "6": // Display Department Counts
            manager.DisplayDepartmentCounts();
            break;

        case "7": // Display Annual Salary for Full-Time Employee
            Console.Write("Enter GUID of full-time employee to view salary: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid salaryId))
            {
                var em = manager.Employees
                    .OfType<FullTimeEmployee>()
                    .FirstOrDefault(e => e.ID == salaryId);

                if (em != null)
                {
                    Console.WriteLine($"Annual Salary for {em.Name}: {em.CalculateAnnualSalary()}");
                }
                else
                {
                    Console.WriteLine("Full-time employee not found with that ID.");
                }
            }
            break;

        case "8": // Search Employees
            Console.Write("Search by (Name/Department/Type): ");
            string searchBy = Console.ReadLine();
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();

            var results = manager.Employees.Where(e =>
                (searchBy.Equals("Name", StringComparison.OrdinalIgnoreCase) && e.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                (searchBy.Equals("Department", StringComparison.OrdinalIgnoreCase) && e.Department.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                (searchBy.Equals("Type", StringComparison.OrdinalIgnoreCase) && e.EmployeeType.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
            );

            Console.WriteLine("Search Results:");
            foreach (var empl in results)
            {
                Console.WriteLine($"Name: {empl.Name}, ID: {empl.ID}, Department: {empl.Department}, Type: {empl.EmployeeType}");
            }
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid option. Please choose again.");
            break;
    }
}