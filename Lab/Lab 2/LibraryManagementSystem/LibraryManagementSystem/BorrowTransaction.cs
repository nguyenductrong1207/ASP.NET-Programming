using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class BorrowTransaction : Transaction
    {
        private Book BookBorrowed {  get; set; }

        public BorrowTransaction(string transactionID, DateTime transactionDate, Member member, Book bookBorrowed)
            : base(transactionID, transactionDate, member)
        {
            BookBorrowed = bookBorrowed;
        }

        public override void Execute()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Here are your borrow transaction's's information: ");
            BookBorrowed.DisplayInfo();
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
