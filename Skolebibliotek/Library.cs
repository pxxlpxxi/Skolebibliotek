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
                throw new InvalidOperationException("This book was not borrowed by this borrower.");
            }
            book.Return();
            borrower.ReturnBook();
            _borrowedBooks.Remove(borrowedBook);
        }
    }
}
