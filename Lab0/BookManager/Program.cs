using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        LibraryManager libraryManager = new LibraryManager();
        LoanProcessor loanProcessor = new LoanProcessor();

        while (true)
        {
            Console.WriteLine("1. Add E-Book");
            Console.WriteLine("2. Add Audiobook");
            Console.WriteLine("3. Loan a Book");
            Console.WriteLine("4. Return a Book");
            Console.WriteLine("5. Display All Books");
            Console.WriteLine("6. Exit");

            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddEBook(libraryManager);
                    break;

                case 2:
                    AddAudioBook(libraryManager);
                    break;

                case 3:
                    LoanABook(libraryManager, loanProcessor);
                    break;

                case 4:
                    ReturnABook(libraryManager, loanProcessor);
                    break;

                case 5:
                    libraryManager.DisplayBooks();
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private static void AddEBook(LibraryManager libraryManager)
    {
        Console.Write("Enter the title of the e-book: ");
        string title = Console.ReadLine();

        Console.Write("Enter the author of the e-book: ");
        string author = Console.ReadLine();

        Console.Write("Enter the file format (e.g., PDF, EPUB): ");
        string format = Console.ReadLine();

        EBook ebook = new EBook
        {
            Title = title,
            Author = author,
            FileFormat = format
        };

        libraryManager.AddBook(ebook);
        Console.WriteLine("E-book added successfully.");
    }

    private static void AddAudioBook(LibraryManager libraryManager)
    {
        Console.Write("Enter the title of the audiobook: ");
        string title = Console.ReadLine();

        Console.Write("Enter the author of the audiobook: ");
        string author = Console.ReadLine();

        Console.Write("Enter the duration (in minutes): ");
        int duration = int.Parse(Console.ReadLine());

        AudioBook audioBook = new AudioBook
        {
            Title = title,
            Author = author,
            Duration = duration
        };

        libraryManager.AddBook(audioBook);
        Console.WriteLine("Audiobook added successfully.");
    }

    private static void LoanABook(LibraryManager libraryManager, LoanProcessor loanProcessor)
    {
        Console.Write("Enter the title of the book to loan: ");
        string title = Console.ReadLine();

        Console.Write("Enter the user's name: ");
        string user = Console.ReadLine();

        Book bookToLoan = FindBookByTitle(libraryManager, title);
        if (bookToLoan != null)
        {
            loanProcessor.LoanBook(bookToLoan, user);
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    private static void ReturnABook(LibraryManager libraryManager, LoanProcessor loanProcessor)
    {
        Console.Write("Enter the title of the book to return: ");
        string title = Console.ReadLine();

        Book bookToReturn = FindBookByTitle(libraryManager, title);
        if (bookToReturn != null)
        {
            loanProcessor.ReturnBook(bookToReturn);
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    private static Book FindBookByTitle(LibraryManager libraryManager, string title)
    {
        foreach (var book in libraryManager.GetBooks())
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return book;
            }
        }
        return null;
    }
}