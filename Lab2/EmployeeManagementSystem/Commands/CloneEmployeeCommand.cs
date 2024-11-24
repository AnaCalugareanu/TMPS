using EmployeeManagementSystem.Facade;
using System;

namespace EmployeeManagementSystem.Commands
{
    public class CloneEmployeeCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public CloneEmployeeCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            Console.Write("Enter GUID of employee to clone: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                _facade.CloneEmployee(id);
                Console.WriteLine("Employee cloned successfully.");
            }
            else
            {
                Console.WriteLine("Invalid GUID format.");
            }
        }
    }
}