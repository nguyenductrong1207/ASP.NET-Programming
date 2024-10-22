using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Book : IPrintable
    {
        public string ISBN { get; set; } // Short Hand GET/SET method
        public string Title { get; set; }
        public string Author { get; set; }
        public int year; // field
        public int Year   // GET/SET method property with accessors
        {
            get => year;
            set
            {
                if (value > 0) 
                {
                    year = value;
                }
            }
        }

        private int copiesAvailable;
        public int CopiesAvailable
        {
            get => copiesAvailable;
            set
            {
                if (value > 0)
                {
                    copiesAvailable = value;
                }
            }
        }

        public Book(string isbn, string title, string author, int year, int copiesAvailable)
        {
            this.ISBN = isbn;
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.CopiesAvailable = copiesAvailable;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Here are your book's information: ");
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("CopiesAvailable: " + CopiesAvailable);
            Console.WriteLine("------------------------------------");
        }

        public void PrintDetails()
        {
            Console.WriteLine("Here are your book's detail: ");
            Console.WriteLine("ISBN: " + ISBN);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("Year: " + Year);
            Console.WriteLine("CopiesAvailable: " + CopiesAvailable);
        }

    }
}