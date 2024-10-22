using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Member : IPrintable, IMemberActions
    {
        public string MemberID {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Member(string memberID, string name, string email) 
        {
            this.MemberID = memberID;
            this.Name = name;
            this.Email = email;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Here are your member's information: ");
            Console.WriteLine("MemberID: " + MemberID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Email: " + Email);
        }

        public void PrintDetails()
        {
            Console.WriteLine("Here are your member's detail: ");
            Console.WriteLine("MemberID: " + MemberID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Email: " + Email);
        }

        public virtual void BorrowBook(Book book)
        {
            if (book.CopiesAvailable > 0)
            {
                book.CopiesAvailable--;
                Console.WriteLine($"{Name} borrowed the book '{book.Title}'. Copies left: {book.CopiesAvailable}");
            }
            else
            {
                Console.WriteLine($"No copies available for the book '{book.Title}'.");
            }
        }

        public virtual void ReturnBook(Book book)
        {
            book.CopiesAvailable++;
            Console.WriteLine($"{Name} returned the book '{book.Title}'. Copies available now: {book.CopiesAvailable}");
        }
    }
}
