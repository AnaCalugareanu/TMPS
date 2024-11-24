using EmployeeManagementSystem.Facade;
using System;

namespace EmployeeManagementSystem.Commands
{
    public class AddReviewCommand : ICommand
    {
        private readonly EmployeeManagementFacade _facade;

        public AddReviewCommand(EmployeeManagementFacade facade)
        {
            _facade = facade;
        }

        public void Execute()
        {
            Console.Write("Enter GUID of employee to add review: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid reviewId))
            {
                Console.Write("Enter review text: ");
                string review = Console.ReadLine();
                _facade.AddReview(reviewId, review);
            }
            else
            {
                Console.WriteLine("Invalid GUID format.");
            }
        }
    }
}