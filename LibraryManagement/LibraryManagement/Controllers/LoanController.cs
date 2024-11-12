using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;

namespace LibraryManagement.Controllers
{
    public class LoanController : Controller
    {
        private readonly LibraryDbContext _LibraryDbContext;

        public LoanController(LibraryDbContext libraryDbContext)
        {
            _LibraryDbContext = libraryDbContext;
        }

        // GET: Loan
        public async Task<IActionResult> Index()
        {
            var libraryDbContext = _LibraryDbContext.Loans.Include(l => l.Book).Include(l => l.User);
            return View(await libraryDbContext.ToListAsync());
        }

        // GET: Loan/Details/Id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _LibraryDbContext.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // GET: Loan/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_LibraryDbContext.Books, "BookId", "BookCode");
            ViewData["UserId"] = new SelectList(_LibraryDbContext.Users, "UserId", "Email");
            return View();
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanId,UserId,BookId,LoanDate,DueDate,ReturnDate,Status")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                _LibraryDbContext.Add(loan);
                await _LibraryDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BookId"] = new SelectList(_LibraryDbContext.Books, "BookId", "BookCode", loan.BookId);
            ViewData["UserId"] = new SelectList(_LibraryDbContext.Users, "UserId", "Email", loan.UserId);
            return View(loan);
        }

        // GET: Loan/Edit/Id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _LibraryDbContext.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_LibraryDbContext.Books, "BookId", "BookCode", loan.BookId);
            ViewData["UserId"] = new SelectList(_LibraryDbContext.Users, "UserId", "Email", loan.UserId);
            return View(loan);
        }

        // POST: Loan/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanId,UserId,BookId,LoanDate,DueDate,ReturnDate,Status")] Loan loan)
        {
            if (id != loan.LoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _LibraryDbContext.Update(loan);
                    await _LibraryDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanExists(loan.LoanId))
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
            ViewData["BookId"] = new SelectList(_LibraryDbContext.Books, "BookId", "BookCode", loan.BookId);
            ViewData["UserId"] = new SelectList(_LibraryDbContext.Users, "UserId", "Email", loan.UserId);
            return View(loan);
        }

        // GET: Loan/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _LibraryDbContext.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }

        // POST: Loan/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loan = await _LibraryDbContext.Loans.FindAsync(id);
            if (loan != null)
            {
                _LibraryDbContext.Loans.Remove(loan);
            }

            await _LibraryDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanExists(int id)
        {
            return _LibraryDbContext.Loans.Any(e => e.LoanId == id);
        }
    }
}
