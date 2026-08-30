# Access modifiers:
Alle fields private for at sikre encapsulation. Det betyder, at andre klasser ikke kan ændre
objekternes interne data direkte. Properties bruges til at give adgang til fields udefra, og
da jeg gerne vil kontrollere adgangen til data en smule mere strengt end med en {get; set;}-property,
bruger jeg en expression-bodied property uden set accessor:

For eksempel:
`private string _title;`
`internal string Title => _title;`

En expression-bodied property som her har kun en getter, og kan derfor kun læses udefra.
I praksis bliver den, som nævnt, en read-only property (eller en short-form get'er), der svarer til at skrive:

```
internal string Title
{
    get { return _title; }
}
```

Udefra kan man altså kun læse title:
`Console.WriteLine(book.Title);`

men man kan IKKE ændre title direkte:
`book.Title = "New Title";`

da Title kun har en get accessor, vil det resultere i en compiler error at forsøge at bryde den regel.
Derfor: Hvis title skal ændres udefra, skal det gøres via et metodekald:

`book.ChangeTitle("New Title");`

Det kan f.eks. sikre, at title ikke kan sættes til en tom string eller null - eller implementere andre relevante begrænsnigner.
En metode til at ændre title kunne se sådan ud:

```
internal void ChangeTitle(string title)
{
    if (string.IsNullOrWhiteSpace(title))
    {
        throw new ArgumentException("Title cannot be empty or whitespace.");
    }
    _title = title;
}
```


På samme måde, kan man kontrollere udlån af bøger, og sikre, at en bog ikke kan udlånes, hvis den allerede er udlånt,
eller at den ikke kan returneres, hvis den ikke allerede er udlånt:

I stedet for:
`book.IsOnLoan = true;`

kan man have en metode:
`library.CheckOut(book);`

CheckOut-metoden kan så tjekke, om bogen allerede er udlånt, og evt. smide en exception.
Metoden i Library-klassen kunne se sådan ud:

```
internal void CheckOut(Book book, Borrower borrower)
{
    if (book.IsOnLoan)
    {
        throw new InvalidOperationException("Book is already on loan.");
    }

    DateTime borrowDate = DateTime.Now;
    DateTime dueDate = borrowDate.AddDays(book.LoanPeriod);
//(hvis bøger kan have forskellige låneperioder - ellers kan det bare være feks: borrowDate.AddDays(30);)


    book.CheckOut();
    _borrowedBooks.Add(new BorrowedBook(book, borrower, borrowDate, dueDate));
}
```

Og metoden i Book:
```
internal void CheckOut()
{
    _isOnLoan = true;
    _dueDate = dueDate;    
}
```

og evt. udvide metoden i Library-klassen med et tjek for, om låner har nået sin lånegrænse:

```
internal void CheckOut(Book book, Borrower borrower)
{
    if (book.IsOnLoan)
    {
        throw new InvalidOperationException("Book is already on loan.");
    }

    if (GetCurrentBorrowedCount(borrower) >= borrower.MaxBorrowLimit)
    {
        throw new InvalidOperationException("Borrower has reached the maximum borrow limit.");
    }

    DateTime borrowDate = DateTime.Now;
    DateTime dueDate = borrowDate.AddDays(book.LoanPeriod);

    book.CheckOut();
    _borrowedBooks.Add(new BorrowedBook(book, borrower, borrowDate, dueDate));
}
```

```
internal int GetCurrentBorrowedCount(Borrower borrower)
{
    return _borrowedBooks.Count(borrowedBook => borrowedBook.Borrower == borrower);
}
```


# Fields & Properties

## BOOK

### Loan Period
Field: `private int _loanPeriod`  
Property: LoanPeriod – kan læses udefra  
Method: ChangeLoanPeriod(int loanPeriod) – kan ændre loan period udefra  

### Title
Field: `private string _title`  
Property: Title – kan læses udefra  
Method: ChangeTitle(string title) – kan ændre title udefra  

### Author
Field: `private string _author`  
Property: Author – kan læses udefra  
Method: ChangeAuthor(string author) – kan ændre author udefra  

### Publication Year
Field: `private int _publicationYear`  
Property: PublicationYear – kan læses udefra  
Method: ChangePublicationYear(int publicationYear) – kan ændre publication year udefra  

### Genre
Field: `private string _genre`  
Property: Genre – kan læses udefra  
Method: ChangeGenre(string genre) – kan ændre genre udefra  

### ISBN
Field: `private string _isbn`  
Property: ISBN – kan læses udefra  

### Number of Pages
Field: `private int _numberOfPages`  
Property: NumberOfPages – kan læses udefra  

### Language
Field: `private string _language`  
Property: Language – kan læses udefra  
Method: ChangeLanguage(string language) – kan ændre language udefra  

### Publisher
Field: `private string _publisher`  
Property: Publisher – kan læses udefra  
Method: ChangePublisher(string publisher) – kan ændre publisher udefra

### Is on Loan:
Field: `private bool _isOnLoan`     
Property: IsOnLoan – kan læses udefra  
Method: Borrow(DateTime dueDate) – kan ændre isOnLoan udefra  
Method: Return() – kan ændre isOnLoan udefra  

### Due Date:
Field: `private DateTime? _dueDate`  
Property: DueDate – kan læses udefra (og kan være null)  
Method: CheckOut() – kan ændre dueDate udefra  
Method: Return() – kan ændre dueDate udefra  


## BORROWER

### Borrower ID
Field: `private int _borrowerID`  
Property: BorrowerID – kan læses udefra  

### Borrow Limit
Field: `private int _maxBorrowLimit`  
Property: MaxBorrowLimit – kan læses udefra  

### Name
Field: `private string _name`  
Property: Name – kan læses udefra  
Method: ChangeName(string name) – kan ændre name udefra  

### Address
Field: `private string _address`  
Property: Address – kan læses udefra  
Method: ChangeAddress(string address) – kan ændre address udefra  

### Phone Number
Field: `private string _phoneNumber`  
Property: PhoneNumber – kan læses udefra  
Method: ChangePhoneNumber(string phoneNumber) – kan ændre phone number udefra  

### Email
Field: `private string _email`  
Property: Email – kan læses udefra  
Method: ChangeEmail(string email) – kan ændre email udefra



## LIBRARY

### Books
Field: `private List<Book> _books`  
( evt. `IReadOnlyList<Book>` )  
Property: Books – kan læses udefra

###  Borrowers
Field : `private List<Borrower> _borrowers`  
( evt. `IReadOnlyList<Borrower>` )  
Property: Borrowers – kan læses udefra

###  Borrowed Books
Field: `private List<BorrowedBook> _borrowedBooks`  
( evt. `IReadOnlyList<BorrowedBook>` )  
Property: BorrowedBooks – kan læses udefra


## BORROWED BOOK

### Book
Field: `private Book _book`  
Property: Book – kan læses udefra

### Borrower
Field: `private Borrower _borrower`  
Property: Borrower – kan læses udefra

### Borrow Date
Field: `private DateTime _borrowDate`  
Property: BorrowDate – kan læses udefra

### Due Date
Field: `private DateTime _dueDate`  
Property: DueDate – kan læses udefra (og kan være null)