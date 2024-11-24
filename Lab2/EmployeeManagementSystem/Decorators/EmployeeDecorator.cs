using EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.Decorators
{
    public abstract class EmployeeDecorator : Employee
    {
        protected Employee _employee;

        protected EmployeeDecorator(Employee employee)
        {
            _employee = employee;
        }

        public override string EmployeeType => _employee.EmployeeType;

        public override Employee Clone() => _employee.Clone();
    }

    public class ReviewDecorator : EmployeeDecorator
    {
        public ReviewDecorator(Employee employee) : base(employee)
        {
        }

        public void AddReview(string review)
        {
            _employee.Reviews.Add(review);
        }

        public List<string> GetReviews()
        {
            return _employee.Reviews;
        }

        public string GetReviewSummary()
        {
            return string.Join("; ", _employee.Reviews);
        }

        public double? GetAverageRating()
        {
            var ratings = _employee.Reviews
                .Where(r => double.TryParse(r, out _))
                .Select(double.Parse)
                .ToList();

            return ratings.Any() ? (double?)ratings.Average() : null;
        }
    }
}