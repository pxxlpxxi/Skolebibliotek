namespace Skolebibliotek
{
    internal class Borrower
    {
        private int _borrowerNumber;
        internal int BorrowerNumber => _borrowerNumber;
        private int _maxBorrowLimit;
        internal int MaxBorrowLimit => _maxBorrowLimit;
        private int _numberOfBooksLoaned;
        internal int NumberOfBooksLoaned => _numberOfBooksLoaned;
        private string _name;
        internal string Name => _name;
        private string _address;
        internal string Address => _address;
        private string _phoneNumber;
        internal string PhoneNumber => _phoneNumber;
        private string _email;
        internal string Email => _email;

        public Borrower(int borrowerNumber, string name)
            : this(borrowerNumber, name, address: "Unknown", phoneNumber: "0", email: "unknown@unknown.null", maxBorrowLimit: 5)
        {
        }

        public Borrower(int borrowerNumber, string name, string address, string phoneNumber, string email, int maxBorrowLimit = 5)
        {
            if (borrowerNumber <= 0)
            {
                throw new ArgumentException($"Borrower number {borrowerNumber} is invalid.");
            }
            ThrowExceptionIfNullOrWhitespace(name, "Name");
            ThrowExceptionIfNullOrWhitespace(address, "Address");
            ThrowExceptionIfNullOrWhitespace(phoneNumber, "Phone Number");
            ThrowExceptionIfNullOrWhitespace(email, "Email");
            if (maxBorrowLimit < 0 || maxBorrowLimit > 5) //allowing 0 as a valid limit, meaning the borrower is banned from borrowing books.
            {
                throw new ArgumentException($"Max borrow limit {maxBorrowLimit} is invalid.");
            }

            if (!int.TryParse(phoneNumber, out _))
            {
                throw new ArgumentException($"Invalid phone number: {phoneNumber}");
            }

            _borrowerNumber = borrowerNumber;
            _name = name;
            _address = address;
            _phoneNumber = phoneNumber;
            _email = email;
            _maxBorrowLimit = maxBorrowLimit;
            _numberOfBooksLoaned = 0;
        }

        internal void BorrowBook()
        {
            if (_numberOfBooksLoaned >= _maxBorrowLimit)
            {
                throw new InvalidOperationException($"Borrower {_name} has reached the maximum limit of {_maxBorrowLimit} borrowed books.");
            }
            _numberOfBooksLoaned++;
        }

        internal void ReturnBook()
        {
            if (_numberOfBooksLoaned <= 0)
            {
                throw new InvalidOperationException($"Borrower {_name} has no borrowed books to return.");
            }
            _numberOfBooksLoaned--;
        }

        private void ThrowExceptionIfNullOrWhitespace(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{fieldName} cannot be empty or whitespace.");
            }
        }
        internal void ChangeName(string name)
        {
            ThrowExceptionIfNullOrWhitespace(name, "Name");
            _name = name;
        }
        internal void ChangeAddress(string address)
        {
            ThrowExceptionIfNullOrWhitespace(address, "Address");
            _address = address;
        }
        internal void ChangePhoneNumber(string phoneNumber)
        {
            ThrowExceptionIfNullOrWhitespace(phoneNumber, "Phone Number");

            if (!int.TryParse(phoneNumber, out _))
            {
                throw new ArgumentException($"Invalid phone number: {phoneNumber}");
            }
            _phoneNumber = phoneNumber;
        }
        internal void ChangeMaxBorrowLimit(int maxBorrowLimit)
        {
            if (maxBorrowLimit < 0 || maxBorrowLimit > 5)
            {
                throw new ArgumentException($"Max borrow limit {maxBorrowLimit} is invalid.");
            }
            _maxBorrowLimit = maxBorrowLimit;
        }   
        internal void ChangeEmail(string email)
        {
            ThrowExceptionIfNullOrWhitespace(email, "Email");
            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new ArgumentException($"Invalid email address: {email}");
            }
            _email = email;
        }
    }
}
