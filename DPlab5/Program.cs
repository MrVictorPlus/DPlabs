using System;

class Book
{
    public string Title;
    public int Year;
    public bool IsTaken;

    public Book(string title, int year)
    {
        Title = title;
        Year = year;
        IsTaken = false;
    }
}

class Program
{
    static void Main()
    {


        Book[] books = new Book[]
        {
            new Book("Преступление и наказание", 1866),
            new Book("Маленький принц", 1943),
            new Book("Хоббит", 1937),
            new Book("Десять негритят", 1939),
            new Book("1984", 1949),
            new Book("Гарри Поттер и философский камень", 2001),
        };

        ShowBooks(books);

        BorrowBook(books, "Хоббит");
        BorrowBook(books, "1984");

        ShowBooks(books);

        ReturnBook(books, "Хоббит");
        ReturnBook(books, "Преступление и наказание");

        ShowBooks(books);

        CountBooksAfter2000(books);
        
    }

    static void ShowBooks(Book[] books)
    {
        Console.WriteLine("Список книг:");
        foreach (var book in books)
        {
            string status = book.IsTaken ? "Взята" : "Доступна";
            Console.WriteLine($"{book.Title} ({book.Year}) - {status}");
        }
        Console.WriteLine();
    }

    static void BorrowBook(Book[] books, string title)
    {
        foreach (var book in books)
        {
            if (book.Title == title)
            {
                if (!book.IsTaken)
                {
                    book.IsTaken = true;
                    Console.WriteLine($"Взяли книгу: {title}");
                }
                else
                {
                    Console.WriteLine($"Книга {title} уже взята.");
                }
                return;
            }
        }
        Console.WriteLine($"Книга {title} не найдена.");
    }

    static void ReturnBook(Book[] books, string title)
    {
        foreach (var book in books)
        {
            if (book.Title == title)
            {
                if (book.IsTaken)
                {
                    book.IsTaken = false;
                    Console.WriteLine($"Вернули книгу: {title}");
                }
                else
                {
                    Console.WriteLine($"Книга {title} не была взята.");
                }
                return;
            }
        }
        Console.WriteLine($"Книга {title} не найдена.");
    }

static void CountBooksAfter2000(Book[] books)
{
    int count = 0;
    foreach (var book in books)
    {
        if (book.Year > 2000)
        {
            count++;
        }
    }
    Console.WriteLine($"Количество книг, изданных после 2000 года: {count}");
}

}

