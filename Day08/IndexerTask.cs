// Create a student with public properties of Rno, Name, Private field of address, indexers for books he have

using System;
using System.Collections.Generic;

class Student
{
    // Public auto-properties
    public int RollNo { get; set; }
    public string Name { get; set; }

    // Private field (encapsulation)
    private string address;

    // Private collection for books
    private List<string> books = new List<string>();

    // Constructor
    public Student(int rollNo, string name, string address)
    {
        RollNo = rollNo;
        Name = name;
        this.address = address;
    }

    // Indexer with validation
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= books.Count)
                return "Invalid book index";

            return books[index];
        }
        set
        {
            if (index < 0)
                throw new IndexOutOfRangeException("Index cannot be negative");

            if (index < books.Count)
                books[index] = value;
            else
                books.Add(value);
        }
    }

    // Read-only access to book count
    public int BookCount => books.Count;

    // Display method
    public void DisplayInfo()
    {
        Console.WriteLine($"Roll No: {RollNo}, Name: {Name}, Address: {address}");
    }

    // Display all books
    public void DisplayBooks()
    {
        Console.WriteLine("Books Collection:");
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"Book {i + 1}: {books[i]}");
        }
    }
}

class IndexerTask
{
    public static void Run()
    {
        Student s1 = new Student(1, "Ayush", "Varanasi");

        s1[0] = "History";
        s1[1] = "Math";
        s1[2] = "English";
        s1[3] = "Physics";
        s1[4] = "Architecture";

        s1.DisplayInfo();
        s1.DisplayBooks();

        Console.WriteLine($"Total Books: {s1.BookCount}");
    }
}
