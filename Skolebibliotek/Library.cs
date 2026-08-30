namespace Skolebibliotek
{
    internal class Library
    {
        private List<Book> _books = new List<Book>();
        internal IReadOnlyList<Book> Books => _books.AsReadOnly();
        private List<Borrower> _borrowers = new List<Borrower>();
        internal IReadOnlyList<Borrower> Borrowers => _borrowers.AsReadOnly();
        private List<BorrowedBook> _borrowedBooks = new List<BorrowedBook>();
        internal IReadOnlyList<BorrowedBook> BorrowedBooks => _borrowedBooks.AsReadOnly();

        internal (IReadOnlyList<Book> Books, IReadOnlyList<Borrower> Borrowers, IReadOnlyList<BorrowedBook> BorrowedBooks) ReadLibrary()
        {
            return (Books, Borrowers, BorrowedBooks);
        }

        internal void CheckOut(Book book, Borrower borrower)
        {
            DateTime borrowDate = DateTime.Now;
            DateTime dueDate = borrowDate.AddDays(book.LoanPeriod);

            book.CheckOut();
            borrower.BorrowBook();
            _borrowedBooks.Add(new BorrowedBook(book, borrower, borrowDate, dueDate));
        }

        internal void ReturnBook(Book book, Borrower borrower)
        {
            var borrowedBook = _borrowedBooks.FirstOrDefault(bb => bb.Book == book && bb.Borrower == borrower);
            if (borrowedBook == null)
            {
                Console.WriteLine($"{book.Title} was not borrowed by {borrower.Name}.");
                return;
            }
            book.Return();
            borrower.ReturnBook();
            _borrowedBooks.Remove(borrowedBook);
        }

        internal void AddBook(Book book)
        {
            _books.Add(book);
        }
        internal void RemoveBook(Book book) { 
            _books.Remove(book);
        }
        internal void AddBorrower(Borrower borrower)
        {
            _borrowers.Add(borrower);
        }
        internal void RemoveBorrower(Borrower borrower)
        {
            _borrowers.Remove(borrower);
        }
        internal void AddBorrowedBook(BorrowedBook borrowedBook)
        {
            _borrowedBooks.Add(borrowedBook);
        }
        internal void RemoveBorrowedBook(BorrowedBook borrowedBook)
        {
            _borrowedBooks.Remove(borrowedBook);
        }
    }
}
