/*
 1.


Access modifiers:
Alle fields private fordi det er best practice for fields (encapsulation).
Properties bruges til at give adgang til fields udefra, så data kan valideres eller evt. ændres på en kontrolleret måde, f.eks. via et metodekald.


BOOK

Title
Field: private string _title
Property: Title – kan læses og ændres udefra

Author
Field: private string _author
Property: Author – kan læses og ændres udefra

Publication Year
Field: private int _publicationYear
Property: PublicationYear – kan læses og ændres udefra

Genre
Field: private string _genre
Property: Genre – kan læses og ændres udefra

ISBN
Field: private string _isbn
Property: ISBN – kan læses udefra

Number of Pages
Field: private int _numberOfPages
Property: NumberOfPages – kan læses udefra

Language
Field: private string _language
Property: Language – kan læses og ændres udefra

Publisher
Field: private string _publisher
Property: Publisher – kan læses og ændres udefra

Is on Loan:
Field: private bool _isOnLoan
Property: IsOnLoan – kan læses udefra

Due Date:
Field: private DateTime _dueDate
Property: DueDate – kan læses udefra


BORROWER

Name
Field: private string _name
Property: Name – kan læses og ændres udefra

Address
Field: private string _address
Property: Address – kan læses og ændres udefra

Phone Number
Field: private string _phoneNumber
Property: PhoneNumber – kan læses og ændres udefra

Email
Field: private string _email
Property: Email – kan læses og ændres udefra

Borrower ID
Field: private int _borrowerID
Property: BorrowerID – kan læses udefra


LIBRARY

Books
Field: private List<Book> _books
Property: Books – kan læses udefra

Borrowers
Field : private List<Borrower> _borrowers
Property: Borrowers – kan læses udefra

BorrowedBooks
Frield: private List<BorrowedBook> _borrowedBooks
Property: BorrowedBooks – kan læses udefra

Borrowed Books
Field: private List<BorrowedBook> _borrowedBooks
Property: BorrowedBooks – kan læses udefra


BORROWED BOOK

Book
Field: private Book _book
Property: Book – kan læses udefra

Borrower
Field: private Borrower _borrower
Property: Borrower – kan læses udefra

Borrow Date
Field: private DateTime _borrowDate
Property: BorrowDate – kan læses udefra

Due Date
Field: private DateTime _dueDate
Property: DueDate – kan læses udefra


 */