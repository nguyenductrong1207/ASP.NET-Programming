namespace LibraryManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Carousel
    {
        [Key]
        public int CarouselId { get; set; }

        [Required, StringLength(200)]
        public string ImageUrl { get; set; }  

        [Required, StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string LinkUrl { get; set; }  

        [Required]
        public int Order { get; set; }  

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }

}
