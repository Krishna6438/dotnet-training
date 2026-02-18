using System; // Console
using System.Collections.Generic; // List, Dictionary, HashSet

namespace ItTechGenie.M1.OOP.Q4
{
    public class LibraryManager
    {
        public static void Run()
        {
            Console.WriteLine("Paste input lines, end with EMPTY line:");
            var lines = ConsoleInput.ReadLines();                               // read input

            var library = new Library();                                        // create library
            var member = new Member("Sana @ Chennai");                          // create member

            foreach (var raw in lines)                                          // process commands
            {
                var cmd = Command.Parse(raw);                                   // parse

                if (cmd.Name == "LIB_ADD")                                      // add book
                {
                    library.AddBook(new Book(
                        Isbn: cmd.Get("isbn"),
                        Title: cmd.Get("title"),
                        Author: cmd.Get("author"),
                        Tag: cmd.Get("tag")
                    ));
                }
                else if (cmd.Name == "BORROW")                                  // borrow
                {
                    member.Borrow(library, cmd.Get("isbn"), cmd.Get("note"));   // ✅ TODO
                }
                else if (cmd.Name == "RETURN")                                  // return
                {
                    member.Return(library, cmd.Get("isbn"));                    // ✅ TODO
                }
            }
        }
    }

    public static class ConsoleInput
    {
        public static string[] ReadLines()
        {
            var list = new List<string>();                                      // store lines
            while (true)
            {
                var line = Console.ReadLine();                                  // read
                if (string.IsNullOrWhiteSpace(line)) break;                     // stop
                list.Add(line);                                                 // add
            }
            return list.ToArray();                                              // return
        }
    }

    public record Book(string Isbn, string Title, string Author, string Tag);   // data model

    public class Library
    {
        private readonly Dictionary<string, Book> _books = new();               // isbn -> book
        private readonly HashSet<string> _borrowed = new();                     // borrowed isbns

        // ✅ TODO: Student must implement only this method
        public void AddBook(Book book)
        {
            // TODO:
            // - validate isbn/title/author not empty
            // - ensure isbn unique
            // - store in _books
            if(string.IsNullOrWhiteSpace(book.Isbn) || string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            {
                throw new ArgumentException("Fields can't be null or empty..");
            }
            if (_books.ContainsKey(book.Isbn))
            {
                throw new ArgumentException("Isbn should be unique");
            }
            _books[book.Isbn] = book;
        }

        public bool Exists(string isbn) => _books.ContainsKey(isbn);            // check exists
        public Book Get(string isbn) => _books[isbn];                           // get book

        public bool IsBorrowed(string isbn) => _borrowed.Contains(isbn);        // borrowed?
        public void MarkBorrowed(string isbn) => _borrowed.Add(isbn);           // mark
        public void MarkReturned(string isbn) => _borrowed.Remove(isbn);        // unmark
    }

    public class Member
    {
        public string Name { get; }                                             // member name
        private readonly HashSet<string> _myBooks = new();                      // borrowed by this member

        public Member(string name) => Name = name;                              // assign

        // ✅ TODO: Student must implement only this method
        public void Borrow(Library library, string isbn, string note)
        {
            // TODO:
            // - validate library has book
            // - validate not already borrowed in library
            // - validate member hasn't already borrowed
            // - mark borrowed + add to member list
            // - print confirmation using note (note may include !, @, spaces)

            if (!library.Exists(isbn))
            {
                throw new ArgumentException("Book is not available..");
            }
            if (library.IsBorrowed(isbn))
            {
                throw new ArgumentException("Book is already borrowed.");
            }
            if (_myBooks.Contains(isbn))
            {
                throw new ArgumentException("Book is already borrowed..");
            }
            library.MarkBorrowed(isbn);
            _myBooks.Add(isbn);
            Console.WriteLine($"BORROW OK | {isbn} | {Name} | note={note}");
        }

        // ✅ TODO: Student must implement only this method
        public void Return(Library library, string isbn)
        {
            // TODO:
            // - validate member has this book
            // - mark returned in library + remove from member list
            // - print confirmation
            if (!_myBooks.Contains(isbn))
            {
                throw new ArgumentException("Book is not borrowed by member..");
            }
            library.MarkReturned(isbn);
            _myBooks.Remove(isbn);
            Console.WriteLine($"RETURN OK | {isbn} | {Name}");
            
        }
    }

    public class Command
    {
        public string Name { get; }
        private readonly Dictionary<string, string> _kv;

        private Command(string name, Dictionary<string, string> kv)
        {
            Name = name; _kv = kv;
        }

        public string Get(string key) => _kv.TryGetValue(key, out var v) ? v : "";

        public static Command Parse(string line)
        {
            var parts = line.Split('|');                                        // split
            var name = parts[0].Trim();                                         // name
            var kv = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            for (int i = 1; i < parts.Length; i++)
            {
                var p = parts[i];
                var idx = p.IndexOf('=');
                if (idx <= 0) continue;
                var key = p.Substring(0, idx).Trim();
                var val = p.Substring(idx + 1).Trim().Trim('"');
                kv[key] = val;
            }
            return new Command(name, kv);
        }
    }
}