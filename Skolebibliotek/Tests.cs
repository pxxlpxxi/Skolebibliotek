using System;
using System.Collections.Generic;
using System.Text;

namespace Skolebibliotek
{

    internal static class Tests
    {
        private static Library _library = new Library();

        internal static void RunAllTests()
        {
            TestBook();
            TestBorrower();
            TestLibrary();
            TestBorrowedBook();
        }

        private static void TestBook()
        {
            CreateTestBooks();


            WriteHeadline("Books added:");


            foreach (var b in _library.Books)
            {
                WriteBookDetails(b);
                Console.WriteLine();
            }
        }

        private static void WriteHeadline(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Environment.NewLine + message + Environment.NewLine);
            Console.ResetColor();
        }

        private static void CreateTestBooks()
        {
            _library.AddBook(new Book("The Binding", "Bridget Collins"));
            _library.AddBook(new Book("Tomorrow, and Tomorrow, and Tomorrow", "Gabrielle Zevin", "978-0593321218", 2022));
            _library.AddBook(new Book("The Poppy War", "R. F. Kuang", "978-0062662583", 2019, "Fantasy", 544, "English", "HarperCollins", 30));
            _library.AddBook(new Book("The Adventures of Amina Al-Sirafi", "Shannon Chakraborty", "978-0008381387", 2024, "Fantasy", 483, "English", "HarperCollins", 30));

        }
        private static void WriteBookDetails(Book book)
        {
            Console.Write(
                $"Title: {book.Title}\n" +
                $"Author: {book.Author}\n" +
                $"ISBN: {book.ISBN}\n" +
                $"Publication Year: {book.PublicationYear}\n" +
                $"Genre: {book.Genre}\n" +
                $"Pages: {book.NumberOfPages}\n" +
                $"Language: {book.Language}\n" +
                $"Publisher: {book.Publisher}\n" +
                $"Loan Period: {book.LoanPeriod}\n"
                );
        }

        private static void TestBorrower()
        {
            CreateTestBorrowers();

            Console.WriteLine("Borrowers added:");

            foreach (var b in _library.Borrowers)
            {
                WriteBorrowerDetails(b);
                Console.WriteLine();
            }
        }
        private static void CreateTestBorrowers()
        {
            _library.AddBorrower(new Borrower(1, "John Doe"));
            _library.AddBorrower(new Borrower(2, "Jane Doe", "123 Main St", "12348271", "jane.smith@example.com", 3));
        }
        private static void WriteBorrowerDetails(Borrower borrower)
        {
            Console.Write($"Borrower Number: {borrower.BorrowerNumber}\n" +
                $"Name: {borrower.Name}\n" +
                $"Address: {borrower.Address}\n" +
                $"Phone Number: {borrower.PhoneNumber}\n" +
                $"Email: {borrower.Email}\n" +
                $"Max Borrow Limit: {borrower.MaxBorrowLimit}\n" +
                $"Number of Books Loaned: {borrower.NumberOfBooksLoaned}\n");
        }
        private static void TestLibrary()
        {
            IReadOnlyList<Book> Books = _library.ReadLibrary().Books;
            IReadOnlyList<Borrower> borrowers = _library.ReadLibrary().Borrowers;

            //test checking out a book
            WriteHeadline("Checkout:");
            _library.CheckOut(Books[0], borrowers[0]);
            Console.WriteLine($"Book '{Books[0].Title}' checked out by {borrowers[0].Name}.");
            Console.WriteLine($"Number of books loaned by {borrowers[0].Name}: {borrowers[0].NumberOfBooksLoaned}");

            //test returning a book
            WriteHeadline("Return:");
            _library.ReturnBook(Books[0], borrowers[0]);
            Console.WriteLine($"'{Books[0].Title}' returned by {borrowers[0].Name}.");
            Console.WriteLine($"Number of books loaned by {borrowers[0].Name}: {borrowers[0].NumberOfBooksLoaned}");
        }

        private static void TestBorrowedBook()
        {
            IReadOnlyList<Book> Books = _library.ReadLibrary().Books;
            IReadOnlyList<Borrower> borrowers = _library.ReadLibrary().Borrowers;

            WriteHeadline("Checkout:");

            //test checking out a book
            _library.CheckOut(Books[1], borrowers[1]);
            var borrowedBook = _library.ReadLibrary().BorrowedBooks[0];

            Console.WriteLine($"Book '{borrowedBook.Book.Title}' \n" +
                $"checked out by {borrowedBook.Borrower.Name} \n" +
                $"on {borrowedBook.BorrowDate}. \n" +
                $"Due on {borrowedBook.DueDate}.");

            //test checking out a book that is already on loan
            WriteHeadline("Checkout attempt:");
            try
            {
                _library.CheckOut(Books[1], borrowers[0]);
            }
            catch (InvalidOperationException ex)
            {
                DateOnly available = DateOnly.FromDateTime(Books[1].DueDate?.AddDays(1) ?? DateTime.Now);
                Console.WriteLine($"Sorry, the book '{Books[1].Title}' is already on loan until {available}.");
            }

            
            try
            {
                WriteHeadline("Return attempt, try-catch (in try block):");
                _library.ReturnBook(Books[1], borrowers[0]);
            }
            catch (InvalidOperationException ex)
            {
                //kode er unreachable her fordi jeg allerede har fejlhåndteringen andre steder :(

                Console.WriteLine($"Sorry, the book '{Books[1].Title}' was not borrowed by {borrowers[0].Name}.");
            }
            finally
            {
                WriteHeadline("Return:");
                _library.ReturnBook(Books[1], borrowers[1]);
                Console.WriteLine($"'{Books[1].Title}' returned by {borrowers[1].Name}.");

            }
            var borrowedBooks = _library.BorrowedBooks;

            WriteHeadline("Checkout multiple books:");
            _library.CheckOut(Books[0], borrowers[0]);
            _library.CheckOut(Books[1], borrowers[0]);
            _library.CheckOut(Books[2], borrowers[0]);
            _library.CheckOut(Books[3], borrowers[1]);

            Console.WriteLine($"The following books are currently on loan:");

            foreach (BorrowedBook b in borrowedBooks)
            {
                Console.WriteLine($"'{b.Book.Title}'\n"
                    + $"Borrowed by {b.Borrower.Name}\n" +
                    $"Due date: {b.DueDate}\n");
            }


            WriteHeadline($"Total number of books on loan is currently: {borrowedBooks.Count()}");

        }
    }
}
