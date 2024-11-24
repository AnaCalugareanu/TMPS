using EmployeeManagementSystem.Facade;
using System;

namespace EmployeeManagementSystem.Commands
{
    public class DisplayAnnualSalaryCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public DisplayAnnualSalaryCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            Console.Write("Enter GUID of full-time employee to view salary: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid salaryId))
            {
                _facade.DisplayAnnualSalary(salaryId);
            }
            else
            {
                Console.WriteLine("Invalid GUID format.");
            }
        }
    }
}