public abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public abstract void DisplayInfo();
}