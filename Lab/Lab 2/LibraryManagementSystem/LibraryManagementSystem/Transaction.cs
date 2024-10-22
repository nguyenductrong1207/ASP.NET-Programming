using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    abstract class Transaction
    {
        private string TransactionID { get; set; }
        private DateTime TransactionDate { get; set; }
        private Member Member;

        public abstract void Execute();

        public Transaction(string transactionID, DateTime transactionDate, Member member)
        {
            this.TransactionID = transactionID;
            this.TransactionDate = transactionDate;
            this.Member = member;
        }
    }
}
