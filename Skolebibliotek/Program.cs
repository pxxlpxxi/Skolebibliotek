/*
 1.

BOOK
Fields:
- title
- author
- publicationYear
- genre
- ISBN
- numberOfPages
- language
- publisher
- isOnLoan
- dueDate

BORROWER
Fields:
- name
- address
- phoneNumber
- email
- borrowerID
- borrowedBooks (list of Book objects)
- membershipDate

Access modifiers: alle private fordi det er best practice for fields (encapsulation).

LIBRARY

Books: list of Book objects
Borrowers: list of Borrower objects
BorrowedBooks: list of BorrowedBook objects

BORROWEDBOOK
Fields:
- Book
- Borrower
- borrowDate
- dueDate


 */