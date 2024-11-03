namespace LibraryManagement.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Carousel> CarouselItems { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
