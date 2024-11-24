using EmployeeManagementSystem.Facade;
using System;

namespace EmployeeManagementSystem.Commands
{
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
}