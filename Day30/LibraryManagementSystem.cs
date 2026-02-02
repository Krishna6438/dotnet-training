class Book
{
    public string? Title{get; set;}
    public string? Author{get; set;}
    public string? Genre{get; set;}
    public int PublicationYear{get; set;}
}

class LibraryUtility
{
    private List<Book> books = new List<Book>();
    public void AddBook(string title, string author, string genre, int year)
    {
        Book b = new Book()
        {
            Title = title,
            Author = author,
            Genre = genre,
            PublicationYear = year
        };
        books.Add(b);
    }

    public SortedDictionary<string, List<Book>> GroupBooksByGenre()
    {
        SortedDictionary<string,List<Book>> grouped = new SortedDictionary<string, List<Book>>();

        foreach (var book in books)
        {
            if (!grouped.ContainsKey(book.Genre))
            {
                grouped[book.Genre] = new List<Book>();
            }

            grouped[book.Genre].Add(book);
        }
        return grouped;
    }

    public List<Book> GetBooksByAuthor(string author)
    {
        return books.Where(b=> b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public int GetTotalBooksCount()
    {
        return books.Count();
    }
}

class LibraryManagement
{
    public static void Run()
    {
        LibraryUtility library = new LibraryUtility();

        // Add books
        library.AddBook("The Alchemist", "Paulo Coelho", "Fiction", 1988);
        library.AddBook("Educated", "Tara Westover", "Non-Fiction", 2018);
        library.AddBook("Sherlock Holmes", "Arthur Conan Doyle", "Mystery", 1892);
        library.AddBook("Inferno", "Dan Brown", "Mystery", 2013);

        // Display books grouped by genre
        Console.WriteLine("📚 Books Grouped by Genre:");
        var groupedBooks = library.GroupBooksByGenre();

        foreach (var genre in groupedBooks)
        {
            Console.WriteLine($"\nGenre: {genre.Key}");
            foreach (var book in genre.Value)
            {
                Console.WriteLine($"{book.Title} by {book.Author} ({book.PublicationYear})");
            }
        }

        // Search by author
        Console.WriteLine("\n🔍 Books by Dan Brown:");
        var result = library.GetBooksByAuthor("Dan Brown");
        foreach (var book in result)
        {
            Console.WriteLine(book.Title);
        }

        // Statistics
        Console.WriteLine("\n📊 Statistics:");
        Console.WriteLine($"Total Books: {library.GetTotalBooksCount()}");

        foreach (var genre in groupedBooks)
        {
            Console.WriteLine($"{genre.Key}: {genre.Value.Count} book(s)");
        }
    }
}