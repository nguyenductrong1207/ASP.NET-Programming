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
        private DateTime MembershipExpiry {  get; set; }
        private int MaxBooksAllowed { get; set; }

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


    }
}
