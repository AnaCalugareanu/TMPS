public class EBook : Book
{
    public string FileFormat { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"E-Book: {Title} by {Author}, Format: {FileFormat}");
    }
}