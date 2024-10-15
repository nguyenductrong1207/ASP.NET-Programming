using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Member : IPrintable, IMemberActions
    {
        private string MemberID {  get; set; }
        private string Name { get; set; }
        private string Email { get; set; }

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
            Console.WriteLine("Here are your borrowed book");
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("CopiesAvailable: " + CopiesAvailable);
        }

        public virtual void ReturnBook(Book book)
        {
            Console.WriteLine("Here are your returned book");
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("CopiesAvailable: " + CopiesAvailable);
        }
    }
}
