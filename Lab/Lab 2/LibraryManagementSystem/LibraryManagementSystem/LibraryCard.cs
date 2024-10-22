using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class LibraryCard
    {
        public string CardNumber { get; } // Read-only property
        public Member Owner { get; set; } // Read and write property
        public DateTime IssueDate { get; private set; } // Read-only externally

        public LibraryCard(string cardNumber, Member owner, DateTime issueDate)
        {
            CardNumber = cardNumber;
            Owner = owner;
            IssueDate = issueDate;
        }

        public void RenewCard()
        {
            IssueDate = DateTime.Now; // Only the class can modify the IssueDate
            Console.WriteLine($"Card renewed. New issue date: {IssueDate}");
        }

        public void DisplayCardInfo()
        {
            Console.WriteLine($"Library Card Number: {CardNumber}");
            Console.WriteLine($"Owner: {Owner.Name}");
            Console.WriteLine($"Issue Date: {IssueDate}");
        }
    }
}
