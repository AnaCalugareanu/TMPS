namespace EmployeeManagementSystem.Models
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public Guid ID { get; private set; } = Guid.NewGuid();
        public string Department { get; set; }

        public abstract string EmployeeType { get; }

        public List<string> Reviews { get; set; } = new List<string>();

        public void AddReview(string review) => Reviews.Add(review);

        public abstract Employee Clone();
    }
}