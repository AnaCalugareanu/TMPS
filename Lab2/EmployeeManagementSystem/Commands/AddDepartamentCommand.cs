using EmployeeManagementSystem.Facade;
using System;

namespace EmployeeManagementSystem.Commands
{
    public class AddDepartmentCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public AddDepartmentCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            Console.Write("Enter department name: ");
            string departmentName = Console.ReadLine();
            _facade.AddDepartment(departmentName);
            Console.WriteLine($"Department '{departmentName}' added successfully.");
        }
    }
}