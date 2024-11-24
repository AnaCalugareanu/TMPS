using EmployeeManagementSystem.Facade;

namespace EmployeeManagementSystem.Commands
{
    public class GenerateEmployeeSummaryReportCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public GenerateEmployeeSummaryReportCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            _facade.GenerateEmployeeSummaryReport();
            Console.WriteLine("Employee summary report generated successfully.");
        }
    }
}