using EmployeeManagementSystem.Facade;
using EmployeeManagementSystem.Adapters;
using System;

namespace EmployeeManagementSystem.Commands
{
    public class ExportEmployeeDataCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public ExportEmployeeDataCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            Console.Write("Enter GUID of employee to export data: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid exportId))
            {
                var employee = _facade.GetEmployeeById(exportId);
                if (employee != null)
                {
                    var adapter = new EmployeeAdapter(employee);
                    Console.WriteLine($"Employee Data in JSON: {adapter.ExportToJson()}");
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