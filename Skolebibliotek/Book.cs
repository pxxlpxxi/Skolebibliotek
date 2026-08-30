using System;

namespace Skolebibliotek
{
    internal class Book
    {
        private string _title;
        internal string Title => _title;
        private string _author;
        internal string Author => _author;
        private int _publicationYear;
        internal int PublicationYear => _publicationYear;
        private string _genre;
        internal string Genre => _genre;
        private string _isbn;
        internal string ISBN => _isbn;
        private int _numberOfPages;
        internal int NumberOfPages => _numberOfPages;
        private string _language;
        internal string Language => _language;
        private string _publisher;
        internal string Publisher => _publisher;
        private int _loanPeriod;
        internal int LoanPeriod => _loanPeriod;
        private bool _isOnLoan;
        internal bool IsOnLoan => _isOnLoan;
        private DateTime? _dueDate;
        internal DateTime? DueDate => _dueDate;

        public Book(string title, string author)
             : this(title, author, isbn: "Unknown", publicationYear: 0, genre: "Unknown", numberOfPages: 0, language: "Unknown", publisher: "Unknown", loanPeriod: 30)
        {
        }
        public Book(string title, string author, string isbn, int publicationYear)
            : this(title, author, isbn, publicationYear, genre: "Unknown", numberOfPages: 0, language: "Unknown", publisher: "Unknown", loanPeriod: 30)
        {
        }

        public Book(string title, string author, string isbn, int publicationYear, string genre, int numberOfPages, string language, string publisher, int loanPeriod = 30)
        {
            ThrowExceptionIfNullOrWhitespace(title, "Title");
            ThrowExceptionIfNullOrWhitespace(author, "Author");
            ThrowExceptionIfNullOrWhitespace(isbn, "ISBN");
            ThrowExceptionIfNullOrWhitespace(genre, "Genre");
            ThrowExceptionIfNullOrWhitespace(language, "Language");
            ThrowExceptionIfNullOrWhitespace(publisher, "Publisher");


            if (publicationYear < 0 || publicationYear > DateTime.Now.Year)
            {
                throw new ArgumentException($"Publication year {publicationYear} is invalid.");
            }

            if (numberOfPages < 0)
            {
                throw new ArgumentException($"Number of pages {numberOfPages} is invalid.");
            }

            if (loanPeriod <= 0)
            {
                throw new ArgumentException($"Loan period of {loanPeriod} days is invalid.");
            }

            _title = title;
            _author = author;
            _isbn = isbn;
            _publicationYear = publicationYear;
            _genre = genre;
            _numberOfPages = numberOfPages;
            _language = language;
            _publisher = publisher;
            _loanPeriod = loanPeriod;

            _isOnLoan = false;
            _dueDate = null;
        }

        internal void CheckOut()
        {
            if (_isOnLoan)
            {
                throw new InvalidOperationException("Book is already on loan.");
            }
            _isOnLoan = true;
            _dueDate = DateTime.Now.AddDays(_loanPeriod);
        }

        internal void Return()
        {
            if (!_isOnLoan)
            {
                throw new InvalidOperationException("Book is not currently on loan.");
            }
            _isOnLoan = false;
            _dueDate = null;
        }
        private void ThrowExceptionIfNullOrWhitespace(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"{fieldName} cannot be empty or whitespace.");
            }
        }

        internal void ChangeTitle(string title)
        {
            ThrowExceptionIfNullOrWhitespace(title, "Title");
            _title = title;
        }

        internal void ChangeAuthor(string author)
        {
            ThrowExceptionIfNullOrWhitespace(author, "Author");
            _author = author;
        }
        internal void ChangeLanguage(string language)
        {
            ThrowExceptionIfNullOrWhitespace(language, "Language");
            _language = language;
        }

        internal void ChangePublicationYear(int publicationYear)
        {
            if (publicationYear < 0 || publicationYear > DateTime.Now.Year)
            {
                throw new ArgumentException($"Publication year {publicationYear} is invalid.");
            }
            _publicationYear = publicationYear;
        }
        internal void ChangeGenre(string genre)
        {
            ThrowExceptionIfNullOrWhitespace(genre, "Genre");
            _genre = genre;
        }
        internal void ChangeISBN(string isbn)
        {
            ThrowExceptionIfNullOrWhitespace(isbn, "ISBN");
            _isbn = isbn;
        }
        internal void ChangeNumberOfPages(int numberOfPages)
        {
            if (numberOfPages < 0)
            {
                throw new ArgumentException($"Number of pages {numberOfPages} is invalid.");
            }
            _numberOfPages = numberOfPages;
        }
        internal void ChangePublisher(string publisher)
        {
            ThrowExceptionIfNullOrWhitespace(publisher, "Publisher");
            _publisher = publisher;
        }
        internal void ChangeLoanPeriod(int loanPeriod)
        {
            if (loanPeriod <= 0)
            {
                throw new ArgumentException($"Loan period of {loanPeriod} days is invalid.");
            }
            _loanPeriod = loanPeriod;
        }


    }
}
