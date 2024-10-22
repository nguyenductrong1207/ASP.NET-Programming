using System;
using System.Collections;
using System.Security.Claims;
using LibraryManagementSystem;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1: Encapsulation - Book Class
            Book book = new Book("123", "Book 1", "Duc Trong", 1999, 12);
            //book.DisplayInfo();

            // Exercise 2: Inheritance - Member and PremiumMember Classes
            Member member = new Member("1", "Member 1", "member@gmail.com");
            //member.DisplayInfo();

            PremiumMember premiumMember = new PremiumMember("2", "Premium Member", "premium@gmail.com", DateTime.Now.AddYears(1), 50);
            //premiumMember.DisplayInfo();

            // Exercise 3: Abstraction - Transaction class and subclasses
            BorrowTransaction borrowTransaction = new BorrowTransaction("BT1", DateTime.Now, member, book);
            //borrowTransaction.Execute();

            ReturnTransaction returnTransaction = new ReturnTransaction("RT1", DateTime.Now.AddDays(10), member, book);
            //returnTransaction.Execute();

            // Exercise 4: Polymorphism - Handling Transactions
            List<Transaction> transactions = new List<Transaction>
            {
                borrowTransaction,
                new BorrowTransaction("BT2", DateTime.Now.AddDays(2), member, book),
                returnTransaction,
                new ReturnTransaction("RT2", DateTime.Now.AddDays(20), member, book)
            };

            foreach (Transaction transaction in transactions)
            {
                transaction.Execute();
            }

            // Exercise 5: Interfaces - IPrintable and IMemberActions
            // Member borrows and returns books
            member.BorrowBook(book);   
            member.ReturnBook(book);  

            // Premium Member borrows and returns books
            premiumMember.BorrowBook(book);  
            premiumMember.ReturnBook(book);

            //  Exercise 6: Constructors - Library Class
            Library defaultLibrary = new Library();
            defaultLibrary.DisplayLibraryInfo();

            List<Book> initialBooks = new List<Book>
            {
                new Book("123", "Book 1", "Duc Trong", 1999, 5),
                new Book("456", "Book 2", "Alice", 2005, 8)
            };
            Library customLibrary = new Library("Custom Library", initialBooks);
            customLibrary.DisplayLibraryInfo();

            customLibrary.Members.Add(new Member("1", "John Doe", "john@example.com"));
            customLibrary.DisplayLibraryInfo();

            Library copiedLibrary = new Library(customLibrary);
            copiedLibrary.DisplayLibraryInfo();

            // Exercise 7: Overloading and Overriding - NotificationService Class

            NotificationService notificationService = new NotificationService();

            notificationService.SendNotification("System maintenance scheduled.");
            notificationService.SendNotification("System maintenance scheduled.", "John Doe");

            List<string> recipients = new List<string> { "John Doe", "Jane Smith", "Alice Brown" };
            notificationService.SendNotification("System maintenance scheduled.", recipients);

            Console.WriteLine("\n");

            AdvancedNotificationService advancedNotificationService = new AdvancedNotificationService();

            advancedNotificationService.SendNotification("System maintenance scheduled.");

            // Exercise 8: Properties with Access Modifiers - LibraryCard Class
            LibraryCard libraryCard = new LibraryCard("LC123456", member, DateTime.Now.AddYears(-1));

            // Display initial card information
            libraryCard.DisplayCardInfo();

            // Renew the card and display updated information
            libraryCard.RenewCard();
            libraryCard.DisplayCardInfo();

            // Exercise 9: Difference Between Class and Record - BookClass vs BookRecord
            BookClass bookClass1 = new BookClass("123", "C# Programming", "John Doe");
            BookClass bookClass2 = new BookClass("123", "C# Programming", "John Doe");

            BookRecord bookRecord1 = new BookRecord("123", "C# Programming", "John Doe");
            BookRecord bookRecord2 = new BookRecord("123", "C# Programming", "John Doe");

            // Comparison using == operator
            Console.WriteLine($"bookClass1 == bookClass2: {bookClass1 == bookClass2}"); // Reference comparison
            Console.WriteLine($"bookRecord1 == bookRecord2: {bookRecord1 == bookRecord2}"); // Value comparison

            // Using 'with' expression for records
            BookRecord updatedBookRecord = bookRecord1 with { Title = "Advanced C#" };
            Console.WriteLine($"Original Record: {bookRecord1}");
            Console.WriteLine($"Updated Record: {updatedBookRecord}");

            // Attempting to do a similar operation for class (no built-in support for 'with')
            BookClass updatedBookClass = new BookClass(bookClass1.ISBN, "Advanced C#", bookClass1.Author);
            Console.WriteLine($"Original Class: {bookClass1}");
            Console.WriteLine($"Updated Class: {updatedBookClass}");

            // Exercise 10: Delegates and Events in OOP - Library and NotificationService Classes
            Library library = new Library();

            library.OnBookBorrowed += notificationService.OnBookBorrowed;
            library.OnBookBorrowed += notificationService.SendEmailNotification;

            library.Books.Add(book);
            library.Members.Add(member);

            // Borrow a book, triggering the event
            library.BorrowBook(book, member);
        }
    }
}