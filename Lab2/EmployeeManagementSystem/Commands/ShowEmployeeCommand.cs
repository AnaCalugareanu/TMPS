using EmployeeManagementSystem.Facade;

namespace EmployeeManagementSystem.Commands
{
    public class ShowAllEmployeesCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public ShowAllEmployeesCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            _facade.DisplayAllEmployees();
        }
    }
}