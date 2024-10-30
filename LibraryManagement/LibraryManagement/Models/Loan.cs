using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Loan
    {
        public int LoanId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Status { get; set; }
    }

}
