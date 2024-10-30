using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem
{
    public class HRManager
    {
        private static HRManager instance;
        public List<Employee> Employees { get; private set; } = new List<Employee>();
        public List<string> Departments { get; private set; } = new List<string>();

        private HRManager()
        { }

        public static HRManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new HRManager();
                return instance;
            }
        }

        public void AddEmployee(Employee employee) => Employees.Add(employee);

        public void AddDepartment(string department) => Departments.Add(department);

        public void DisplayDepartmentCounts()
        {
            var departmentCounts = Employees
                .GroupBy(e => e.Department)
                .Select(g => new { Department = g.Key, Count = g.Count() });

            Console.WriteLine("Department Employee Counts:");
            foreach (var dept in departmentCounts)
            {
                Console.WriteLine($"{dept.Department}: {dept.Count} employees");
            }
        }
    }
}