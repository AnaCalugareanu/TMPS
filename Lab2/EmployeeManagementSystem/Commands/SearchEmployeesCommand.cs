using EmployeeManagementSystem.Facade;
using System;

namespace EmployeeManagementSystem.Commands
{
    public class SearchEmployeesCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public SearchEmployeesCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            Console.Write("Search by (Name/Department/Type): ");
            string searchBy = Console.ReadLine();
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();

            _facade.SearchEmployees(searchBy, searchTerm);
        }
    }
}