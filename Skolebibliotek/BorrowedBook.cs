namespace Skolebibliotek
{
    internal class BorrowedBook
    {
        private Book _book;
        internal Book Book => _book;
        private Borrower _borrower;
        internal Borrower Borrower => _borrower;
        private DateTime _borrowDate;
        internal DateTime BorrowDate => _borrowDate;
        private DateOnly _dueDate;
        internal DateOnly DueDate => _dueDate;

        internal BorrowedBook(Book book, Borrower borrower, DateTime borrowDate, DateTime dueDate)
        {
            _book = book;
            _borrower = borrower;
            _borrowDate = borrowDate;
            _dueDate = DateOnly.FromDateTime(dueDate);
        }

    }
}
