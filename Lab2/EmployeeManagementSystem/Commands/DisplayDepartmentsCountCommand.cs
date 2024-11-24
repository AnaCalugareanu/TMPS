using EmployeeManagementSystem.Facade;

namespace EmployeeManagementSystem.Commands
{
    public class DisplayDepartmentCountsCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public DisplayDepartmentCountsCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            _facade.DisplayDepartmentCounts();
        }
    }
}