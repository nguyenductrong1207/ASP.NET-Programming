using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Tesst
    {
        [Key]
        public int TestId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
