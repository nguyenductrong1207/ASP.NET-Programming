using System;
using System.Collections;
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

        }
    }
}