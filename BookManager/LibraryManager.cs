public class LibraryManager
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public IEnumerable<Book> GetBooks()
    {
        return books;
    }

    public void DisplayBooks()
    {
        foreach (var book in books)
        {
            book.DisplayInfo();
        }
    }
}