using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    // Inheritance by using ":" symbol
    // PremiumMember : Member => PremiumMember is inherit from Member
    internal class PremiumMember : Member
    {
        public DateTime MembershipExpiry {  get; set; }
        public int MaxBooksAllowed { get; set; }

        public PremiumMember(string memberID, string name, string email, DateTime membershipExpiry, int maxBooksAllowed)
            : base(memberID, name, email) // Calls base class constructor
        {
            MembershipExpiry = membershipExpiry;
            MaxBooksAllowed = maxBooksAllowed;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("MembershipExpiry: " + MembershipExpiry);
            Console.WriteLine("MaxBooksAllowed: " + MaxBooksAllowed);
        }

        public override void BorrowBook(Book book)
        {
            if (MaxBooksAllowed > 0)
            {
                base.BorrowBook(book);  // Use the base class implementation
                MaxBooksAllowed--;
                Console.WriteLine($"Books allowed for borrowing: {MaxBooksAllowed}");
            }
            else
            {
                Console.WriteLine("You have reached the maximum number of borrowed books.");
            }
        }

        public override void ReturnBook(Book book)
        {
            base.ReturnBook(book);
            MaxBooksAllowed++;
            Console.WriteLine($"Books allowed for borrowing: {MaxBooksAllowed}");
        }
    }
}
