public class LoanProcessor
{
    private Dictionary<Book, string> loanedBooks = new Dictionary<Book, string>();

    public void LoanBook(Book book, string user)
    {
        loanedBooks.Add(book, user);
        Console.WriteLine($"Book '{book.Title}' has been loaned to {user}");
    }

    public void ReturnBook(Book book)
    {
        if (loanedBooks.ContainsKey(book))
        {
            loanedBooks.Remove(book);
            Console.WriteLine($"Book '{book.Title}' has been returned.");
        }
        else
        {
            Console.WriteLine("This book was not loaned.");
        }
    }
}