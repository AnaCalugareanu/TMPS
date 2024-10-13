public class AudioBook : Book
{
    public int Duration { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Audiobook: {Title} by {Author}, Duration: {Duration} minutes");
    }
}