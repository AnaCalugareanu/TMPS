using EmployeeManagementSystem.Facade;
using EmployeeManagementSystem.Decorators;
using System;

namespace EmployeeManagementSystem.Commands
{
    public class ShowEmployeeReviewSummaryCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public ShowEmployeeReviewSummaryCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            Console.Write("Enter GUID of employee to view review summary: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid summaryId))
            {
                var employee = _facade.GetEmployeeById(summaryId);
                if (employee != null)
                {
                    var decoratedEmployee = new ReviewDecorator(employee);
                    Console.WriteLine($"Review Summary: {decoratedEmployee.GetReviewSummary()}");
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
        }
    }
}