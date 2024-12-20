﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext _LibraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            _LibraryDbContext = libraryDbContext;
        }

        [Authorize]
        public IActionResult BookDetail(int id)
        {
            var book = _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefault(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult List(string category)
        {
            List<Book> books = _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.Category != null && b.Category.Name.ToLower() == category.ToLower())
                .OrderBy(b => b.BookId)
                .ToList();

            ViewBag.Books = books;
            ViewBag.Category = category;
            return View();
        }

        [Authorize]
        public IActionResult ReadPdf(int id)
        {
            var book = _LibraryDbContext.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null || string.IsNullOrEmpty(book.Pdf))
            {
                return NotFound("This book has not have the PDF version.");
            }

            var pdfUrl = Url.Content($"/{book.Pdf}");
            ViewBag.PdfPath = pdfUrl;
            return View();
        }

        // Book Management

        // GET: Book
        public async Task<IActionResult> Index()
        {
            var libraryDbContext = _LibraryDbContext.Books.Include(b => b.Author).Include(b => b.Category);
            return View(await libraryDbContext.ToListAsync());
        }

        // GET: Book/Details/Id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_LibraryDbContext.Authors, "AuthorId", "FirstName");
            ViewData["CategoryId"] = new SelectList(_LibraryDbContext.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Description,BookCode,Publisher,PublishedYear,CategoryId,AuthorId,TotalCopies,AvailableCopies,CreatedDate,Pdf")] Book book, IFormFile avatarFile)
        {
            if (ModelState.IsValid)
            {
                if (avatarFile != null && avatarFile.Length > 0)
                {
                    // Get the path to save the image
                    string folderPath = Path.Combine("wwwroot", "images", "books");
                    string fileName = Path.GetFileName(avatarFile.FileName);
                    string filePath = Path.Combine(folderPath, fileName);

                    // Ensure the directory exists
                    Directory.CreateDirectory(folderPath);

                    // Save the image file to the folder
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await avatarFile.CopyToAsync(stream);
                    }

                    // Set the Avatar property to the relative path
                    book.Avatar = Path.Combine("images", "books", fileName);
                }

                _LibraryDbContext.Add(book);
                await _LibraryDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_LibraryDbContext.Authors, "AuthorId", "FirstName", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(_LibraryDbContext.Categories, "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Book/Edit/Id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _LibraryDbContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_LibraryDbContext.Authors, "AuthorId", "FirstName", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(_LibraryDbContext.Categories, "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // POST: Book/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Description,BookCode,Publisher,PublishedYear,CategoryId,AuthorId,TotalCopies,AvailableCopies,CreatedDate,Avatar,Pdf")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _LibraryDbContext.Update(book);
                    await _LibraryDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_LibraryDbContext.Authors, "AuthorId", "FirstName", book.AuthorId);
            ViewData["CategoryId"] = new SelectList(_LibraryDbContext.Categories, "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Book/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _LibraryDbContext.Books.FindAsync(id);
            if (book != null)
            {
                _LibraryDbContext.Books.Remove(book);
            }

            await _LibraryDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _LibraryDbContext.Books.Any(e => e.BookId == id);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return Json(new List<object>());
            }

            var books = await _LibraryDbContext.Books
                .Where(b => EF.Functions.Like(b.Title, $"%{search}%"))
                .Select(b => new
                {
                    bookId = b.BookId,
                    title = b.Title,
                    authorFirstName = b.Author != null ? b.Author.FirstName : "Unknown Author",
                    categoryName = b.Category != null ? b.Category.Name : "Uncategorized"
                })
                .ToListAsync();

            return Json(books);
        }

    }
}
