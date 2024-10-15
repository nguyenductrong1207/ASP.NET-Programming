using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class ReturnTransaction : Transaction
    {
        private Book BookReturned { get; set; }


        public ReturnTransaction(string transactionID, DateTime transactionDate, Member member, Book bookReturned)
            : base(transactionID, transactionDate, member)
        {
            BookReturned = bookReturned;
        }

        public override void Execute()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Here are your return transaction's's information: ");
            BookReturned.DisplayInfo();
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
