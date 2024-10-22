using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Library
    {
        public string LibraryName { get; set; }
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }

        // Parameterless Constructor
        public Library()
        {
            LibraryName = "Default Library";
            Books = new List<Book>();
            Members = new List<Member>();
        }

        // Parameterized Constructor
        public Library(string libraryName, List<Book> books)
        {
            LibraryName = libraryName;
            Books = books;
            Members = new List<Member>();  
        }

        // Copy Constructor
        public Library(Library existingLibrary)
        {
            LibraryName = existingLibrary.LibraryName;
            Books = new List<Book>(existingLibrary.Books);  
            Members = new List<Member>(existingLibrary.Members); 
        }

        public void DisplayLibraryInfo()
        {
            Console.WriteLine($"Library Name: {LibraryName}");
            Console.WriteLine($"Number of Books: {Books.Count}");
            Console.WriteLine($"Number of Members: {Members.Count}");
        }

        public delegate void BookBorrowedEventHandler(Book book, Member member);

        // Define an event based on the delegate
        public event Action<Book, Member> OnBookBorrowed;

        // Method to borrow a book
        public void BorrowBook(Book book, Member member)
        {
            Console.WriteLine($"{member.Name} borrowed the book: {book.Title}");

            // Trigger the OnBookBorrowed event
            OnBookBorrowed?.Invoke(book, member);
        }
    }
}
